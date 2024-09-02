using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour
{
    //Controls
    private PlayerControls Controls;
    private InputAction ShootButton1;
    private InputAction ShootButton2;

    //Current Weapon Handling
    [SerializeField] private Weapon Weapon1;
    public Weapon Weapon2; //WeaponSlot 2 is public so it can be accessed by Tutorial Mission. TO DO: Set private and refactor this into an event.
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Transform WeaponRoot1;
    [SerializeField] private Transform WeaponRoot2;

    void Awake()
    {
        Controls = new PlayerControls();
    }

    private void Start()
    {
        Weapon1 = PlayerInventoryData.Instance.EquipSlot[0];
        Weapon2 = PlayerInventoryData.Instance.EquipSlot[1];

        if (Weapon1 != null)
        {
            Weapon1 = Instantiate(Weapon1, WeaponRoot1);
            Weapon1.WeaponRoot = WeaponRoot1;
        }
        if (Weapon2 != null)
        {
            EquipWeapon2();
        }
    }
    void Update()
    {
        if (Weapon1 != null)
        {
            Attack(ShootButton1, Weapon1);
        }
        if (Weapon2 != null)
        {
            Attack(ShootButton2, Weapon2);
        }
    }

    void OnEnable()
    {
        ShootButton1 = Controls.Player.Shoot;
        ShootButton2 = Controls.Player.SubShoot;
        ShootButton1.Enable();
        ShootButton2.Enable();
    }
    void OnDisable()
    {
        ShootButton1.Disable();
        ShootButton2.Disable();
    }

    /* TO DO: The Attack handling is very confusing which is due the problems I had when trying Unitys new input system.
    /* Refactoring will change that the actual shooting of the Weapon (Weapon Script) will trigger the Sound and Muzzle Flash, also remove
    /* the seperation between "WasPressedThisFrame" and "IsPressed" Condition.*/
    public void Attack(InputAction _attackButton, Weapon _weapon)
    {
        if (_weapon.rapidFire)
        {
            //plays attack Sound and muzzle flash while holding attack
            if (_attackButton.WasPressedThisFrame())
            {
                _weapon.Source.loop = true;
                _weapon.Source.Play();
                _weapon.ShootAnim.SetActive(true);
            }
            //release
            else if (_attackButton.WasReleasedThisFrame())
            {
                _weapon.Source.loop = false;
                _weapon.ShootAnim.SetActive(false);
                _weapon.HitAnim.SetActive(false);
            }
            //Triggers Attack while the button is pressed.
            if (_attackButton.IsPressed())
            {
                _weapon.Shoot();
            }
        }
        //If Weapon of type Bullet, every Shoot needs a single input
        else if (_attackButton.triggered)
        {
            _weapon.Shoot();
        }
    }
    public void EquipWeapon2()
    {
        Weapon2 = Instantiate(Weapon2, WeaponRoot2);
        Weapon2.WeaponRoot = WeaponRoot2;
    }

}

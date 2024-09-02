using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerControls controls;
    private InputAction move;
    private InputAction dash;
    private Vector3 input;
    private Vector3 smoothMovement;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lerpSpeed;
    [Header("Dash")]
    [SerializeField] private float boost;
    [SerializeField] private float boostCoolDown;
    [SerializeField] private float boostTimer;
    [SerializeField] private GameObject dashEffect;


    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovementHandling();
        DashBoost();

    }
    void MovementHandling()
    {
        //Get Input
        input.x = move.ReadValue<Vector3>().x;
        input.y = move.ReadValue<Vector3>().y;

        input *= moveSpeed;
        smoothMovement = Vector3.Lerp(rb.velocity, input, lerpSpeed * Time.deltaTime);

        rb.velocity = smoothMovement;

        //if Player moves faster than regular move speed, activate dash Effect
        if (rb.velocity.x >= moveSpeed || rb.velocity.x <= -moveSpeed || rb.velocity.z >= moveSpeed || rb.velocity.z <= -moveSpeed)
        {
            if (!dashEffect.activeSelf)
            {
                dashEffect.SetActive(true);
            }
        }
        else
            if (dashEffect.activeSelf)
        {
            dashEffect.SetActive(false);
        }
    }

    void DashBoost()
    {
        if (boostTimer >= 0)
        {
            boostTimer -= Time.deltaTime;
        }
        if (dash.triggered && boostTimer <= 0)
        {
            AudioManager.instance.SFX[5].Source.Play();
            rb.AddForce(rb.velocity * boost, ForceMode.Impulse);
            boostTimer = boostCoolDown;
        }
    }


    private void OnEnable()
    {
        move = controls.Player.Move;
        dash = controls.Player.DashBoost;
        move.Enable();
        dash.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        dash.Disable();
    }

}

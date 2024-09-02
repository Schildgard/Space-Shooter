using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour
{

    Vector3 rot = Vector3.zero;
   // float rotSpeed = 40f;
    Animator anim;

    public bool animTriggered;
    public bool EnemyStands;

    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        gameObject.transform.eulerAngles = rot;
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimation();
        gameObject.transform.eulerAngles = rot;
    }

    void HandleAnimation()
    {
        // Walk
        //if (Input.GetKey(KeyCode.W))
        //{
        //	anim.SetBool("Walk_Anim", true);
        //}
        //else if (Input.GetKeyUp(KeyCode.W))
        //{
        //	anim.SetBool("Walk_Anim", false);
        //}

        //// Rotate Left
        //if (Input.GetKey(KeyCode.A))
        //{
        //	rot[1] -= rotSpeed * Time.fixedDeltaTime;
        //}

        //// Rotate Right
        //if (Input.GetKey(KeyCode.D))
        //{
        //	rot[1] += rotSpeed * Time.fixedDeltaTime;
        //}

        // Roll
        if (animTriggered) // change to Bool Check
        {
            if (!anim.GetBool("Roll_Anim"))
            {
                anim.SetBool("Roll_Anim", true);
            }
        }
        else 
        {
            if (anim.GetBool("Roll_Anim")) 
            {
                anim.SetBool("Roll_Anim", false);
            }
        }
        

        // Close
        if (EnemyStands) // change to when Stop
        {
            if (!anim.GetBool("Open_Anim"))
            {
                anim.SetBool("Open_Anim", true);
            }
            else
            {
                anim.SetBool("Open_Anim", false);
            }
        }
    }

}

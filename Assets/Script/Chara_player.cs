using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Chara_player : MonoBehaviour
{
    public Camera Cam;
    GameObject Model;
    Animator Anim;
    enum MOVE : int { I = 0, F = 1, B = 2, R = 3, L = 4, FF = 5};
    MOVE move;

    public float Speed = 4f;
    public float Speed_fast = 4f;

    // Use this for initialization
    void Start()
    {
        Model = GameObject.FindGameObjectWithTag("Chara_model");
        Anim = Model.GetComponent<Animator>();
//        Cam = GetComponent<Camera>();
        move = MOVE.I;
    }

    // Update is called once per frame
    void Update()
    {
        float l_x = Input.GetAxis("GamePad1_L_Stick_Horizontal");
        float l_y = Input.GetAxis("GamePad1_L_Stick_Vertical");

        float r_x = Input.GetAxis("GamePad1_R_Stick_Horizontal");
        float r_y = Input.GetAxis("GamePad1_R_Stick_Vertical");

        float speed = Speed;

        if (l_x * l_x + l_y * l_y > 0.25)
        {
            float dir = Mathf.Atan(l_y / l_x) * Mathf.Rad2Deg;

            if (Mathf.Abs(dir) >= 45)
            {
                if (l_y > 0)
                {
                    if(l_y > 0.6)
                    {
                        speed = Speed_fast;
                        Anim.SetInteger("Move", (int)MOVE.FF);
                    }
                    else
                    {
                        Anim.SetInteger("Move", (int)MOVE.F);
                    }
                }
                else
                {
                    Anim.SetInteger("Move", (int)MOVE.B);
                }
            }
            else
            {
                if (l_x > 0)
                {
                    Anim.SetInteger("Move", (int)MOVE.R);
                }
                else
                {
                    Anim.SetInteger("Move", (int)MOVE.L);
                }
            }

        }
        else
        {
            Anim.SetInteger("Move", 0);
        }
        
        if (Mathf.Abs(r_x) > 0.2)
        {
            Vector3 axis = new Vector3(0f, 1, 0f);
            transform.Rotate(axis, r_x);
        }

        if (Mathf.Abs(r_y) > 0.2)
        {
            Vector3 axis = new Vector3(1, 0, 0);
            Cam.transform.Rotate(axis, r_y);
        }

        Debug.Log(r_y);

        transform.position += transform.forward * speed * l_y * Time.deltaTime;
        transform.position += transform.right * Speed * l_x * Time.deltaTime;
    }
}

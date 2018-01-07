using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Chara_player : MonoBehaviour
{
    public Camera Camera;
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
        move = MOVE.I;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("GamePad1_Horizontal");
        float y = Input.GetAxis("GamePad1_Vertical");
        float speed = Speed;
                
        if (x * x + y * y > 0.25)
        {
            float dir = Mathf.Atan(y / x) * Mathf.Rad2Deg;

            if (Mathf.Abs(dir) >= 45)
            {
                if (y > 0)
                {
                    if(y > 0.6)
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
                if (x > 0)
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

        transform.position += transform.forward * speed * y * Time.deltaTime;
        transform.position += transform.right * Speed * x * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class gamepad_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    
	void Update () {
        float h = Input.GetAxis("GamePad1_Horizontal");
        float v = Input.GetAxis("GamePad1_Vertical");
        float x = Input.GetAxis("GamePad1_Cross_X");
        float y = Input.GetAxis("GamePad1_Cross_Y");
        if ( h*h+v*v > 0.25 ) Debug.Log("h:" + h + ",v:" + v);
        if ( x*x+y*y > 0.25) Debug.Log("x:" + x + ",y:" + y);
        if (Input.GetButton("GamePad1_A")) Debug.Log("A");
        if (Input.GetButton("GamePad1_B")) Debug.Log("B");
        if (Input.GetButton("GamePad1_X")) Debug.Log("X");
        if (Input.GetButton("GamePad1_Y")) Debug.Log("Y");
        if (Input.GetButton("GamePad1_R1")) Debug.Log("R1");
        if (Input.GetButton("GamePad1_L1")) Debug.Log("L1");
        if (Input.GetButton("GamePad1_R2")) Debug.Log("R2");
        if (Input.GetButton("GamePad1_L2")) Debug.Log("L2");
        if (Input.GetButton("GamePad1_Start")) Debug.Log("Start");
        if (Input.GetButton("GamePad1_Select")) Debug.Log("Select");
    }

    /*
    void Update()
    {
        DownKeyCheck();
    }


    void DownKeyCheck()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    //処理を書く
                    Debug.Log(code);
                    break;
                }
            }
        }
    }
    */
}

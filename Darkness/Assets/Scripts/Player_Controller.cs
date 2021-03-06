﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
    public KeyCode forward = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode back = KeyCode.S;

    public static bool freeze;
    public Transform Camera;
    public float lerpspeed;
    public float walkspeed;
    private Rigidbody rb;
    private bool forwardb, leftb, rightb, backb;

   
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
        if(freeze)
        {
            forwardb = false;
            forwardb = false;
            rightb = false;
            backb = false;
        }
        if (Input.GetKeyDown(forward) && !freeze)
        {
            forwardb = true;
        }
        if (Input.GetKeyUp(forward))
        {
            forwardb = false;
        }

        if (Input.GetKeyDown(left) && !freeze)
        {
            leftb = true;
        }
        if (Input.GetKeyUp(left))
        {
            leftb = false;
        }

        if (Input.GetKeyDown(right) && !freeze)
        {
            rightb = true;
        }
        if (Input.GetKeyUp(right))
        {
            rightb = false;
        }

        if (Input.GetKeyDown(back) && !freeze)
        {
            backb = true;
        }
        if (Input.GetKeyUp(back))
        {
            backb = false;
        }

    }

    private void LateUpdate()
    {
        Quaternion camrotation = Quaternion.Euler(0, Camera.transform.eulerAngles.y, 0);
        if (forwardb)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, camrotation, Time.time * lerpspeed);
            rb.MovePosition(transform.position + (transform.forward * Time.deltaTime * walkspeed));
            //transform.Translate(Vector3.forward * walkspeed * Time.deltaTime);
        }
        if (rightb)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, camrotation, Time.time * lerpspeed);
            rb.MovePosition(transform.position + (transform.right * Time.deltaTime * walkspeed));
        }


        if (leftb)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, camrotation, Time.time * lerpspeed);
            rb.MovePosition(transform.position + (-transform.right * Time.deltaTime * walkspeed));
        }
        if (backb)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, camrotation, Time.time * lerpspeed);
            rb.MovePosition(transform.position + (-transform.forward * Time.deltaTime * walkspeed));
        }
    }
}

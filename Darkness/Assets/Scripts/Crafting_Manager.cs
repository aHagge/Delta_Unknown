using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting_Manager : MonoBehaviour {
    
    public static RaycastHit Hit;

    public GameObject craftdisplay;
    void Start () {
		
	}
	

	void Update () {
		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out Hit, 15.0f) && Hit.transform.gameObject.tag == "Crafting" && Input.GetKeyDown(KeyCode.F))
        {
            if(!craftdisplay.activeInHierarchy)
            {
            craftdisplay.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Player_Controller.freeze = true;
            } else
            {
                craftdisplay.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Player_Controller.freeze = false;
            }
        }
         else if (Input.GetKeyDown(KeyCode.F))
        {
            craftdisplay.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Player_Controller.freeze = false;
        }
	}
}
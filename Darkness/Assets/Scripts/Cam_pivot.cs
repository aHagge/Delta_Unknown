using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_pivot : MonoBehaviour {

    public Transform player;
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * 10f);
    }
}

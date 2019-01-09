using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public Material red, green;
    private Renderer[] own_Mat;
    public static bool canbuild = true;

    
	void Start () {
    }
    public LayerMask layerstoexclude;
    public static RaycastHit Hit;

    private void OnTriggerEnter(Collider other)
    {
        own_Mat = GetComponentsInChildren<Renderer>();
        if (other.gameObject.tag == "Building" || other.gameObject.tag == "Player")
        {
            canbuild = false;
            foreach (Renderer a in own_Mat)
            {
                a.material.color = red.color;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Building" || other.gameObject.tag == "Player")
        {
            canbuild = true;
            foreach (Renderer a in own_Mat)
            {
                a.material.color = green.color;
            }
        }
    }
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out Hit, 15.0f, layerstoexclude) && Hit.collider.gameObject.tag == "BuildDot" && transform.childCount != 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.position = new Vector3(Hit.collider.gameObject.transform.position.x, Hit.collider.gameObject.transform.position.y, Hit.collider.gameObject.transform.position.z);
        } else if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out Hit, 15.0f, layerstoexclude) && transform.childCount != 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.position = Hit.point;
        } else if(transform.childCount != 0)
        {
            
            transform.GetChild(0).gameObject.SetActive(false);
        }   
    }
}

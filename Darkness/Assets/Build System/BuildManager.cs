using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public BuildScriptableObject[] Buildings;
    public static BuildScriptableObject Selbuild;
    public GameObject buildprellok;
    private GameObject preview;
    private int number;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if ((number + 1) != Buildings.Length)
            {
                number++;
            }
            else
            {
                number = 0;
            }
            Selbuild = Buildings[number];
            Destroy(preview);
            preview = Instantiate(Buildings[number].Buildprefab, buildprellok.transform);
            buildprellok.transform.localScale = Buildings[number].Buildprefab.transform.lossyScale;
            buildprellok.transform.eulerAngles = Buildings[number].Buildprefab.transform.eulerAngles;
        }
        if(Building.Hit.transform == null)
        {
            return;
        }
         else if(Input.GetMouseButtonDown(0) && Building.Hit.collider.gameObject.tag == "BuildDot" && Building.canbuild)
        {
            Instantiate(Buildings[number].Building_Prefab, buildprellok.transform.GetChild(0).position, buildprellok.transform.rotation);
            Destroy(Building.Hit.collider.gameObject);
        } else if (Input.GetMouseButtonDown(0) && Building.canbuild)
        {
            Instantiate(Buildings[number].Building_Prefab, buildprellok.transform.GetChild(0).position, Quaternion.identity);
        }
    }
}

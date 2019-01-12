using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craft_slot : MonoBehaviour {

    public Inventory invenscript;
    public Craftrecipe recipe;

	void Start () {
		
	}
	

	void Update () {
		
	}

    public void craft()
    {
        foreach(Itemrecipe rp in recipe.ingredients)
        {
            foreach (GameObject slot in invenscript.Slots)
            {
                if (slot.GetComponent<Slot>().iteminit == rp.item.Name)
                {
                }
            }
        }  
    }
}

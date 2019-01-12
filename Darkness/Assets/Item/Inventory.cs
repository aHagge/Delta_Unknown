using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Inventory : MonoBehaviour {

    // Item array with all items able to go into the inventory
    public Items[] Alltheitems;

    public GameObject Inventoryobject;

    //the actual item in the inventory, later being set too the item of choice
    public GameObject itemdisplayerprefab;
    public GameObject slotselectUI;
    public static string Itemselected;

    public GameObject[] Slots;



    private void Update()
    {
        //Item selected when pressed the number keys for selecting hotbar slots
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotselectUI.transform.position = Slots[0].transform.position;
            Itemselected = Slots[0].GetComponent<Slot>().iteminit;
            print(Itemselected);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotselectUI.transform.position = Slots[1].transform.position;
            Itemselected = Slots[1].GetComponent<Slot>().iteminit;
            print(Itemselected);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotselectUI.transform.position = Slots[2].transform.position;
            Itemselected = Slots[2].GetComponent<Slot>().iteminit;
            print(Itemselected);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotselectUI.transform.position = Slots[3].transform.position;
            Itemselected = Slots[3].GetComponent<Slot>().iteminit;
            print(Itemselected);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            slotselectUI.transform.position = Slots[4].transform.position;
            Itemselected = Slots[4].GetComponent<Slot>().iteminit;
            print(Itemselected);
        }



        //temporary settup too add item
        if (Input.GetKeyDown(KeyCode.P))
        {
            Additem(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Additem(1, 1);
        }

        //opening and closing the inventory UI
        if (Input.GetKeyDown(KeyCode.Tab) && Inventoryobject.activeInHierarchy)
        {
            Inventoryobject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            //if the player should move or not
            Player_Controller.freeze = false;
        } else if(Input.GetKeyDown(KeyCode.Tab) && !Player_Controller.freeze)
        {
            Inventoryobject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            //if the player should move or not
            Player_Controller.freeze = true;
        }
    }
    // being able too call this function and just typing in what item id too add
    public void Additem(int id , int amount)
    {
        foreach(GameObject slot in Slots)
        {
            //if nothing is in the slot
            if (!slot.GetComponent<Slot>().somethingin)
            {
                //spawn the object in that slot
                Instantiate(itemdisplayerprefab, slot.transform.localPosition, Quaternion.identity, slot.gameObject.transform);
                slot.GetComponent<Slot>().somethingin = true;
                slot.GetComponentInChildren<a_Item>().itemdisplaying = Alltheitems[id];
                slot.GetComponentInChildren<a_Item>().itemsinit += amount;
                slot.GetComponent<Slot>().iteminit = Alltheitems[id].Name;
                break;
            }
            //if there is something in the slot and its the same as the one u are trying too add
            else if (slot.GetComponent<Slot>().iteminit == Alltheitems[id].Name && !slot.GetComponent<Slot>().full && slot.transform.childCount != 0)
            {
                slot.GetComponentInChildren<a_Item>().itemsinit += amount;

                //if it is then full after u have added the amount of items
                if(slot.GetComponentInChildren<a_Item>().itemsinit >= Alltheitems[id].HowManyCanStack)
                {
                    slot.GetComponent<Slot>().full = true;
                }
                break;
            }
        }
      
    }
}

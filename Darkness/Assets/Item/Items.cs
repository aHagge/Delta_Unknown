using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Items : ScriptableObject
{

    public string Name;
    public Sprite Icon;
    public int HowManyCanStack;
    public bool Suit, co2, helmet, shoes, backpack, item;
    public string description;
}
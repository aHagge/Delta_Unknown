using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Craftrecipe : ScriptableObject
{

    public Items result;
    public Itemrecipe[] ingredients;
}

[System.Serializable]
public class Itemrecipe
{
    public string name;
    public Items item;
    public int amount;
}

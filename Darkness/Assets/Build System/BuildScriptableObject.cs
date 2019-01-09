using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building")]
public class BuildScriptableObject : ScriptableObject
{

    public string Name;
    public Sprite Thumbnail;

    public GameObject Building_Prefab;
    public GameObject Buildprefab;
    //Need to build materials
    public int StoneAmount, WoodAmount, IronAmount, GlassAmount;

    public string description;
}
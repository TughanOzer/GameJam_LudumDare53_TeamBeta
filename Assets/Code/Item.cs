using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/item")]
public class Item : ScriptableObject
{
    [Header("Only UI")]
    // lets you define an image for the item 
    public Sprite image;
    
}

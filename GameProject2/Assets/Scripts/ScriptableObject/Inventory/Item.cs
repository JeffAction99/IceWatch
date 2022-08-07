using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT BY LEA

[CreateAssetMenu(fileName = "Item", menuName = "Assets/Item")]
public class Item : ScriptableObject
{
    [Header("Item Fields")]
    public GameObject type;
    public string title;
    public bool stackable;
    public Sprite sprite;
    public bool isHighlighted;
}

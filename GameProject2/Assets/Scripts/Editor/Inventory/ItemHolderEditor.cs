using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemHolder))]
public class ItemHolderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemHolder inventory = target as ItemHolder;
        if(GUILayout.Button("Clear slots"))
        {
            for(int i = 0; i < inventory.slots.Count; i++)
            {
                inventory.slots[i].Clear();
            }
        }
        DrawDefaultInspector();
    }
}

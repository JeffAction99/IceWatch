using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NoteDescription", menuName = "Assets/NoteDescription")]
public class NoteDescriptions : ScriptableObject
{
    [TextArea(10, 100)]
    public string[] text = new string[] {};

}


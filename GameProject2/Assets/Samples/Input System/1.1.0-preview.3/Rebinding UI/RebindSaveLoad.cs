using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RebindSaveLoad : MonoBehaviour
{
    public InputActionAsset actions;

    private void Start()
    {
        if(this.gameObject.activeSelf)
        {
            var rebinds = PlayerPrefs.GetString("rebinds");
            if (!string.IsNullOrEmpty(rebinds))
                actions.LoadBindingOverridesFromJson(rebinds);
        }
    }
    public void OnEnable()
    {
        //var rebinds = PlayerPrefs.GetString("rebinds");
        //if (!string.IsNullOrEmpty(rebinds))
        //    actions.LoadBindingOverridesFromJson(rebinds);
    }

    public void OnDisable()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("rebinds", rebinds);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButtonHandler : MonoBehaviour
{
    [SerializeField] private Image leftImage;
    [SerializeField] private ItemHolder item;
    [SerializeField] private Item jacket;
    [SerializeField] private PlayerStatManagement temp;

    public BothButtonHandler state;
    private float curState;

    public void SetLeftImage(Sprite newLeftImage)
    {
        leftImage.sprite = newLeftImage;
    }

    public void LeftButtonClicked()
    {
        
        if (curState <= 1f)
        {
            print("put jacket into inventory");
            item.Add(jacket);
            temp.setTempTick(1f);
        }
    }

    public void Update()
    {
        curState = state.GetCurState();
    }
}

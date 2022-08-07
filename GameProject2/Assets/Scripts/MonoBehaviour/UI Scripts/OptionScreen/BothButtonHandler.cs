using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BothButtonHandler : MonoBehaviour
{
    public float curState;
    public LeftButtonHandler leftImage;
    public RightButtonHandler rightImage;

    [SerializeField] private Text textBoxL;
    [SerializeField] private Text textBoxR;

    [SerializeField] private Sprite leftIm01;
    [SerializeField] private Sprite rightIm01;

    [SerializeField] public Sprite leftIm02;
    [SerializeField] public Sprite rightIm02;

    [SerializeField] private GameObject choiceCanvas;
    public void ButtonPressed()
    {
        choiceCanvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        curState++;

        if (curState > 1)
        {
            leftImage.SetLeftImage(leftIm02);
            rightImage.SetRightImage(rightIm02);

            textBoxL.text = "Gain 10 snacks!";
            textBoxR.text = "Your stamina will decrease less overtime";
        }
    }

    public void Start()
    {
        curState = 0.5f;
        if (curState == 0.5f)
        {
            leftImage.SetLeftImage(leftIm01);
            rightImage.SetRightImage(rightIm01);

            textBoxL.text = "Your body temperature will decrease slower";
            textBoxR.text = "Your stamina decreases half as less when you activate your boost";
        }
    }

    public float GetCurState()
    {
        return curState;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HistoryInput : MonoBehaviour
{
    public Image InputIcon;
    public Image InputBackground;
    public Text InputText;

    public void SetHistoryInput(Mobile_GridButton gridButton)
    {
        InputBackground.color = gridButton.background.color;
        InputBackground.sprite = gridButton.background.sprite;
        InputIcon.color = gridButton.icon.color;
        InputIcon.sprite = gridButton.icon.sprite;
        InputText.text = gridButton.text.text;
    }
}

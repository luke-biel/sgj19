using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Mobile_GridButton : MonoBehaviour
{
    [FormerlySerializedAs("Background")] public Image background;
    [FormerlySerializedAs("Icon")] public Image icon;
    [FormerlySerializedAs("Button")] public Button button;
    [FormerlySerializedAs("Text")] public Text text;
    public AudioSource audioSource;

    private void Start()
    {
        button.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        if (GameplayController.Instance.CheckWithSequence(this))
        {
            if (audioSource.clip != null)
            {
                audioSource.Play();
            }
        }
    }
}

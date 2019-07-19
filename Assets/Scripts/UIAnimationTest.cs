using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimationTest : MonoBehaviour
{
    public Image TestImage;
    public float ScaleFactor = 1.5f;
    public Animator ImageAnimator;
    private Coroutine _coroutine;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ShowCurrentInput();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowCurrentInput();
        }
    }

    private void ShowCurrentInput()
    {
        ImageAnimator.SetTrigger("GotInput");
    }
}

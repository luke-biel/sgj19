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
<<<<<<< HEAD

=======
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
>>>>>>> f70477407d74f7b7d3a73e5a8c92ba92478367bc

    private void ShowCurrentInput()
    {
        ImageAnimator.SetTrigger("GotInput");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimationTest : MonoBehaviour
{
    public Image testImage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PunchImage();
        }
    }

    private void PunchImage()
    {
        
    }
}

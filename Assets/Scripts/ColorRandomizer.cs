using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorRandomizer : MonoBehaviour
{
    public List<Image> images;
    void Awake()
    {
        foreach (Image image in images)
        {
            image.color = Random.ColorHSV();
            Color tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
        }
    }

    public static Color InverseColor(Color ColorToInverse)
    {
      return new Color(1f-ColorToInverse.r,1f-ColorToInverse.g,1f-ColorToInverse.b);
    }
    
}

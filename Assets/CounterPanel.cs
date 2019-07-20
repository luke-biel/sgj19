using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterPanel : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Text counterText;
    // Start is called before the first frame update
    void Start()
    {
        counterText.color = ColorRandomizer.InverseColor(backgroundImage.color);
    }

    public void UpdateText(int currentSequenceIndex, int sequenceCount)
    {
        counterText.text = currentSequenceIndex + "/" + sequenceCount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundNumber : MonoBehaviour
{
    // Start is called before the first frame update
    Container container;
    [SerializeField] Text numberText;
    void Start()
    {
        container = FindObjectOfType<Container>().GetComponent<Container>();
        UpdateText();
    }

    // Update is called once per frame
     public void AddRound(bool positive)
     {
        if (positive)
            container.RoundNumber++;
        else if (!positive && container.RoundNumber > 1)
            container.RoundNumber--;
        UpdateText();
    }
    public void UpdateText()
    {
        numberText.text = container.RoundNumber.ToString();
    }
}

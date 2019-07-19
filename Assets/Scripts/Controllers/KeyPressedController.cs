using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputActions;

public class KeyPressedController : MonoBehaviour//, IMissingKeysActions
{
    List<string> sentence = new List<string>();
    bool _lastInputAxisState;
    void Update()
    {
        string keyPressed=string.Empty;
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                keyPressed = kcode.ToString();
                break;
            }
        }
        if (keyPressed == string.Empty)
            keyPressed = CheckTriggersAndAnalogs();

        if(keyPressed!=string.Empty)
        {
            sentence.Add(keyPressed);
            Debug.Log("zdanie:" + keyPressed);
        }
    }

    private string CheckTriggersAndAnalogs()
    {
        string keyPressed = string.Empty;
        string[] namesToCheck = new string[] {"Fire1","Fire2"};
        foreach(string name in namesToCheck)
        {
            if (GetAxisInputLikeOnKeyDown(name))
            {
                keyPressed = name;
                break;
            }
        }
        return keyPressed;
    }

    private bool GetAxisInputLikeOnKeyDown(string axisName)
    {
        var currentInputValue = Input.GetAxis(axisName) > 0.1;
        if (currentInputValue && _lastInputAxisState)
        {
            return false;
        }
        _lastInputAxisState = currentInputValue;
        return currentInputValue;
    }

}


using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputActions;

public class KeyPressedController : MonoBehaviour
{
    string _lastInputAxisState = string.Empty;
    public delegate void ButtonPressedDelegate(string buttonPressed);
    public event ButtonPressedDelegate ButtonPressedEvent;
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
            LastButtonPressed = keyPressed;
            if (ButtonPressedEvent != null)
                ButtonPressedEvent.Invoke(LastButtonPressed);
        }
    }

    private string CheckTriggersAndAnalogs()
    {
        string[] axisNames = new string[] { "Axis 1", "Axis 2", "Axis 4", "Axis 5", "Axis 6", "Axis 7" };
        string[,] names = new string[,]{{"leftAnalogLeft","leftAnalogRight"},{"leftAnalogUp","leftAnalogDown"},{"rightAnalogLeft","rightAnalogRight"},{"rightAnalogUp","rightAnalogDown"},{"dpadLeft","dpadRight"},{"dpadDown","dpadUp"}};

        if (_lastInputAxisState != string.Empty && CheckIfPreviousPressed())
            return string.Empty;

        string keyPressed = string.Empty;
        if (GetAxisInputLikeOnKeyDown("Axis 9"))
        {
            keyPressed = "LeftTrigger";
            return keyPressed;
        }
        else if(GetAxisInputLikeOnKeyDown("Axis 10"))
        {
            keyPressed = "RightTrigger";
            return keyPressed;
        }
        for(int i=0;i<axisNames.Length;i++)
        {
            if(GetAxisInputLikeOnKeyDown(axisNames[i]))
            {
                return names[i,1];
            }
            else if(GetAxisInputLikeOnKeyDownNegative(axisNames[i]))
            {
                return names[i, 0];
            }
        }
        _lastInputAxisState = string.Empty;
        return keyPressed;
    }

    private bool GetAxisInputLikeOnKeyDown(string axisName)
    {
        var currentInputValue = Input.GetAxis(axisName) > 0.7;
        if (axisName == _lastInputAxisState)
        {
            return false;
        }
        if (currentInputValue)
            _lastInputAxisState = axisName;
        return currentInputValue;
    }

    private bool GetAxisInputLikeOnKeyDownNegative(string axisName)
    {
        var currentInputValue = Input.GetAxis(axisName) < -0.7;
        if (axisName == _lastInputAxisState)
        {
            return false;
        }
        if(currentInputValue)
            _lastInputAxisState = axisName;
        return currentInputValue;
    }

    private bool CheckIfPreviousPressed()
    {
        return Input.GetAxis(_lastInputAxisState) > 0.7 || Input.GetAxis(_lastInputAxisState) < -0.7;
    }
    public string LastButtonPressed { get; set; }
}

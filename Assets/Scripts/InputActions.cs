// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputActions : IInputActionCollection
{
    private InputActionAsset asset;
    public InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""MissingKeys"",
            ""id"": ""1f6bf10c-32ba-4823-9ff0-d5e8a5d89ba6"",
            ""actions"": [
                {
                    ""name"": ""Gameplay"",
                    ""id"": ""5c14fc71-e47d-4386-88ac-aed425c1f957"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""11c3e950-75a2-45ef-ba0a-41f1fde315df"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""26d5aead-fb0f-4826-ab13-d2c6945a4a8a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""6e525470-1334-4c1e-a817-b4b2cd7ba385"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""2df81f4e-0bbd-4302-a97d-1a0722758f27"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""8af550f3-ecf4-46fd-a197-e1c059fec1c4"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""e6b1e406-0b2e-48b0-9bd8-2ca77bd2dd7c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""c4320083-1d99-439e-a5cc-1e61239a116e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""4b69d04f-e0cc-45bd-984b-1c0c117ecd34"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""438e88ca-a42a-43b1-82bf-ef5b9f3f99f0"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""7fed6a60-3468-4f9c-b4e8-e63978dc758b"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""d086b5f0-518e-43c0-b34a-dbefb74cfe93"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""d0c987a6-f45f-4c3b-a1ac-69374b5e85b9"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gameplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MissingKeys
        m_MissingKeys = asset.GetActionMap("MissingKeys");
        m_MissingKeys_Gameplay = m_MissingKeys.GetAction("Gameplay");
    }

    ~InputActions()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // MissingKeys
    private InputActionMap m_MissingKeys;
    private IMissingKeysActions m_MissingKeysActionsCallbackInterface;
    private InputAction m_MissingKeys_Gameplay;
    public struct MissingKeysActions
    {
        private InputActions m_Wrapper;
        public MissingKeysActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Gameplay { get { return m_Wrapper.m_MissingKeys_Gameplay; } }
        public InputActionMap Get() { return m_Wrapper.m_MissingKeys; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(MissingKeysActions set) { return set.Get(); }
        public void SetCallbacks(IMissingKeysActions instance)
        {
            if (m_Wrapper.m_MissingKeysActionsCallbackInterface != null)
            {
                Gameplay.started -= m_Wrapper.m_MissingKeysActionsCallbackInterface.OnGameplay;
                Gameplay.performed -= m_Wrapper.m_MissingKeysActionsCallbackInterface.OnGameplay;
                Gameplay.canceled -= m_Wrapper.m_MissingKeysActionsCallbackInterface.OnGameplay;
            }
            m_Wrapper.m_MissingKeysActionsCallbackInterface = instance;
            if (instance != null)
            {
                Gameplay.started += instance.OnGameplay;
                Gameplay.performed += instance.OnGameplay;
                Gameplay.canceled += instance.OnGameplay;
            }
        }
    }
    public MissingKeysActions @MissingKeys
    {
        get
        {
            return new MissingKeysActions(this);
        }
    }
    public interface IMissingKeysActions
    {
        void OnGameplay(InputAction.CallbackContext context);
    }
}

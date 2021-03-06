//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/Controls/KeyboardControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @KeyboardControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyboardControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyboardControls"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""6770a990-4526-400c-8315-13da804a75dc"",
            ""actions"": [
                {
                    ""name"": ""LeftSwing"",
                    ""type"": ""Button"",
                    ""id"": ""1add1b37-172d-4c48-a55a-0aabf26ff1c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightSwing"",
                    ""type"": ""Button"",
                    ""id"": ""7f60693e-0955-4037-a7b5-042e226cbc0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UpSwing"",
                    ""type"": ""Button"",
                    ""id"": ""96e930a1-13a2-42eb-b5c2-fe3ec400db2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HoldingEscape"",
                    ""type"": ""Button"",
                    ""id"": ""43f4e3bd-38f5-40d0-b91c-47217a3afab8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""69418dcb-9be2-4c6e-9531-78f27dc29e88"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftSwing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""839929f3-97c4-4458-9870-fc547a087cd0"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSwing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a0e1457-4a02-4d8b-9196-37e8f0a9de76"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpSwing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a22d56e-c182-4972-9d3f-c65587c358f7"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Hold(duration=3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HoldingEscape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_LeftSwing = m_Default.FindAction("LeftSwing", throwIfNotFound: true);
        m_Default_RightSwing = m_Default.FindAction("RightSwing", throwIfNotFound: true);
        m_Default_UpSwing = m_Default.FindAction("UpSwing", throwIfNotFound: true);
        m_Default_HoldingEscape = m_Default.FindAction("HoldingEscape", throwIfNotFound: true);
    }

    public void Dispose()
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

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_LeftSwing;
    private readonly InputAction m_Default_RightSwing;
    private readonly InputAction m_Default_UpSwing;
    private readonly InputAction m_Default_HoldingEscape;
    public struct DefaultActions
    {
        private @KeyboardControls m_Wrapper;
        public DefaultActions(@KeyboardControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftSwing => m_Wrapper.m_Default_LeftSwing;
        public InputAction @RightSwing => m_Wrapper.m_Default_RightSwing;
        public InputAction @UpSwing => m_Wrapper.m_Default_UpSwing;
        public InputAction @HoldingEscape => m_Wrapper.m_Default_HoldingEscape;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @LeftSwing.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftSwing;
                @LeftSwing.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftSwing;
                @LeftSwing.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftSwing;
                @RightSwing.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightSwing;
                @RightSwing.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightSwing;
                @RightSwing.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightSwing;
                @UpSwing.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnUpSwing;
                @UpSwing.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnUpSwing;
                @UpSwing.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnUpSwing;
                @HoldingEscape.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnHoldingEscape;
                @HoldingEscape.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnHoldingEscape;
                @HoldingEscape.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnHoldingEscape;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftSwing.started += instance.OnLeftSwing;
                @LeftSwing.performed += instance.OnLeftSwing;
                @LeftSwing.canceled += instance.OnLeftSwing;
                @RightSwing.started += instance.OnRightSwing;
                @RightSwing.performed += instance.OnRightSwing;
                @RightSwing.canceled += instance.OnRightSwing;
                @UpSwing.started += instance.OnUpSwing;
                @UpSwing.performed += instance.OnUpSwing;
                @UpSwing.canceled += instance.OnUpSwing;
                @HoldingEscape.started += instance.OnHoldingEscape;
                @HoldingEscape.performed += instance.OnHoldingEscape;
                @HoldingEscape.canceled += instance.OnHoldingEscape;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnLeftSwing(InputAction.CallbackContext context);
        void OnRightSwing(InputAction.CallbackContext context);
        void OnUpSwing(InputAction.CallbackContext context);
        void OnHoldingEscape(InputAction.CallbackContext context);
    }
}

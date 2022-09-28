//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""controls"",
    ""maps"": [
        {
            ""name"": ""controller"",
            ""id"": ""867bb9dd-553e-4530-a65a-1ca63f695269"",
            ""actions"": [
                {
                    ""name"": ""card1"",
                    ""type"": ""Button"",
                    ""id"": ""6b736900-a47f-4472-93b3-71262aafa53b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""card2"",
                    ""type"": ""Button"",
                    ""id"": ""4689b5d1-6aa5-4fe2-a8c5-f78243654d58"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""card3"",
                    ""type"": ""Button"",
                    ""id"": ""946c2118-1add-4f1e-8bad-d1b8f7079a99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""card4"",
                    ""type"": ""Button"",
                    ""id"": ""b857a4cf-f1de-43d6-9257-8dc97773016f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""roleDice"",
                    ""type"": ""Button"",
                    ""id"": ""e8518de4-4df7-45d8-a2f8-d594bb9801b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""exitGame"",
                    ""type"": ""Button"",
                    ""id"": ""5bfd8aaa-fd7f-41a9-909c-dee6e29ff84b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d2f850ac-f156-4849-bbaf-1de76deed51d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""card1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c258d993-b5b4-4765-a233-030a23f4b022"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""card1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8e64d6c-9120-41c3-9385-78b80d738be5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""card2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b9ef6d1-ccff-477e-9ec1-15cdfdab0393"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""card2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29d11377-5f3c-425f-b89a-e9b0829ebd6b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""card3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1864a8c-3a02-428d-bf53-b53b5adcde0b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""card3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""560e0e69-757c-469c-bf27-ed762b6ae16c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""card4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9502d6bb-ee02-4e87-8214-a06ac2ba105c"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""card4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8459ace-a7d6-403e-889d-74a262de8484"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""roleDice"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e553c47-3fe1-49b4-af0d-9852161b6e07"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""roleDice"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42e7a727-436d-41b8-ad56-98bc74a6ea40"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;controller"",
                    ""action"": ""exitGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""controller"",
            ""bindingGroup"": ""controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // controller
        m_controller = asset.FindActionMap("controller", throwIfNotFound: true);
        m_controller_card1 = m_controller.FindAction("card1", throwIfNotFound: true);
        m_controller_card2 = m_controller.FindAction("card2", throwIfNotFound: true);
        m_controller_card3 = m_controller.FindAction("card3", throwIfNotFound: true);
        m_controller_card4 = m_controller.FindAction("card4", throwIfNotFound: true);
        m_controller_roleDice = m_controller.FindAction("roleDice", throwIfNotFound: true);
        m_controller_exitGame = m_controller.FindAction("exitGame", throwIfNotFound: true);
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

    // controller
    private readonly InputActionMap m_controller;
    private IControllerActions m_ControllerActionsCallbackInterface;
    private readonly InputAction m_controller_card1;
    private readonly InputAction m_controller_card2;
    private readonly InputAction m_controller_card3;
    private readonly InputAction m_controller_card4;
    private readonly InputAction m_controller_roleDice;
    private readonly InputAction m_controller_exitGame;
    public struct ControllerActions
    {
        private @Controls m_Wrapper;
        public ControllerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @card1 => m_Wrapper.m_controller_card1;
        public InputAction @card2 => m_Wrapper.m_controller_card2;
        public InputAction @card3 => m_Wrapper.m_controller_card3;
        public InputAction @card4 => m_Wrapper.m_controller_card4;
        public InputAction @roleDice => m_Wrapper.m_controller_roleDice;
        public InputAction @exitGame => m_Wrapper.m_controller_exitGame;
        public InputActionMap Get() { return m_Wrapper.m_controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerActions set) { return set.Get(); }
        public void SetCallbacks(IControllerActions instance)
        {
            if (m_Wrapper.m_ControllerActionsCallbackInterface != null)
            {
                @card1.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard1;
                @card1.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard1;
                @card1.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard1;
                @card2.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard2;
                @card2.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard2;
                @card2.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard2;
                @card3.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard3;
                @card3.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard3;
                @card3.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard3;
                @card4.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard4;
                @card4.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard4;
                @card4.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCard4;
                @roleDice.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRoleDice;
                @roleDice.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRoleDice;
                @roleDice.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRoleDice;
                @exitGame.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnExitGame;
                @exitGame.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnExitGame;
                @exitGame.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnExitGame;
            }
            m_Wrapper.m_ControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @card1.started += instance.OnCard1;
                @card1.performed += instance.OnCard1;
                @card1.canceled += instance.OnCard1;
                @card2.started += instance.OnCard2;
                @card2.performed += instance.OnCard2;
                @card2.canceled += instance.OnCard2;
                @card3.started += instance.OnCard3;
                @card3.performed += instance.OnCard3;
                @card3.canceled += instance.OnCard3;
                @card4.started += instance.OnCard4;
                @card4.performed += instance.OnCard4;
                @card4.canceled += instance.OnCard4;
                @roleDice.started += instance.OnRoleDice;
                @roleDice.performed += instance.OnRoleDice;
                @roleDice.canceled += instance.OnRoleDice;
                @exitGame.started += instance.OnExitGame;
                @exitGame.performed += instance.OnExitGame;
                @exitGame.canceled += instance.OnExitGame;
            }
        }
    }
    public ControllerActions @controller => new ControllerActions(this);
    private int m_controllerSchemeIndex = -1;
    public InputControlScheme controllerScheme
    {
        get
        {
            if (m_controllerSchemeIndex == -1) m_controllerSchemeIndex = asset.FindControlSchemeIndex("controller");
            return asset.controlSchemes[m_controllerSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IControllerActions
    {
        void OnCard1(InputAction.CallbackContext context);
        void OnCard2(InputAction.CallbackContext context);
        void OnCard3(InputAction.CallbackContext context);
        void OnCard4(InputAction.CallbackContext context);
        void OnRoleDice(InputAction.CallbackContext context);
        void OnExitGame(InputAction.CallbackContext context);
    }
}

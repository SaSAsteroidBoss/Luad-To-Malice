//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.2
//     from Assets/MASTERCONTROLLER.inputactions
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
using UnityEngine;

public partial class @MASTERCONTROLLER: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MASTERCONTROLLER()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MASTERCONTROLLER"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""6a4955f4-fc4a-4330-b4e7-f96a23fe3c62"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""826421b6-b78e-4269-ac64-5b0818e1427d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CastTwo"",
                    ""type"": ""Button"",
                    ""id"": ""11825099-fc2e-46b3-b079-0e168f083aaf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CastOne"",
                    ""type"": ""Button"",
                    ""id"": ""f5ccaa30-6a85-4e34-b25f-f6d592ea6c54"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d1179b93-03cb-469e-9a57-5d8fa1f6595c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1a67c7c8-0927-4d91-bad2-28ea0b5f3c00"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""81b5ff12-42cc-4804-8dcb-e1292f1b619e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c1a0b246-6cf2-41f4-9341-4e277061591b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""60f92689-70aa-4316-9c37-64b4891e2061"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d5a65910-2995-4e5d-982c-e707af4a354a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b960144d-5181-4653-838c-891addff4dbb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b825143f-7286-4f67-8958-8bec718ce7fc"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d07fcc3f-a249-4ad6-9a14-35d6a2944e3e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""94f80f7d-0aef-49d1-9ea8-a3437fdbdf58"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e8ee21c3-59a6-4ee6-a9e8-0ce1bdd8b3c7"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2b8a4efd-a253-4a86-8590-01967e1a39c5"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CastTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da066c9a-3257-467b-acae-739d8694c103"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CastOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6ec63b5-52ea-42ed-a9cc-edc1a176abf0"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49ed60c9-1720-4cb3-8180-6eccbd4f8d01"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Touch"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c27f20c0-4c84-47f5-b46a-87e5f5b8db19"",
                    ""path"": ""<Joystick>/{Hatswitch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""60346a46-f176-4a51-bd68-3b5b04175f79"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c96ed5a4-3c06-471a-8baf-c67504a601ef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CastTwo"",
                    ""type"": ""Button"",
                    ""id"": ""246fde26-af41-4fc7-994a-2701d26d547d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CastOne"",
                    ""type"": ""Button"",
                    ""id"": ""f975826a-05e5-4816-bf9c-49349203ff50"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""15f9c4ee-19d8-48f2-90e4-641242af2910"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d8f3c574-3f9e-4e1b-9d66-fcc2eee9f079"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""40a385c7-7921-404b-829a-2bc71df7e9d1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c080903a-1e45-4fc3-b5d7-d0c1177e20d5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""64cda294-6576-45cf-9f7f-c599c5ce8398"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""11f5668e-6a4c-46bd-b73a-53071f3a8e6a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e375f89e-2244-4068-a976-ad1bde32198e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0acb9c1f-8ea2-4c6d-bf5d-488e690b3aeb"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2103876c-9a54-47de-9c7e-90990881aafa"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""db15efbd-a63e-40a0-a3a3-8e9b1b20a93e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e5f7ccf3-53b2-4843-879a-625c776b2cfa"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""25da2eee-a8ee-4a81-9b98-aa381c47a759"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CastTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""785699e5-c959-48d2-bb07-2aeb1d45fa11"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CastOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""904d9fd2-2938-4c47-8979-4ac3f7286b52"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23f37f8e-fa9a-4ef2-ba05-ac4c5de94046"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Touch"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34f857b3-ec52-4882-8683-ebfcf1e80fed"",
                    ""path"": ""<Joystick>/{Hatswitch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""All Control Scemes"",
            ""bindingGroup"": ""All Control Scemes"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Move = m_Player1.FindAction("Move", throwIfNotFound: true);
        m_Player1_CastTwo = m_Player1.FindAction("CastTwo", throwIfNotFound: true);
        m_Player1_CastOne = m_Player1.FindAction("CastOne", throwIfNotFound: true);
        m_Player1_Look = m_Player1.FindAction("Look", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Move = m_Player2.FindAction("Move", throwIfNotFound: true);
        m_Player2_CastTwo = m_Player2.FindAction("CastTwo", throwIfNotFound: true);
        m_Player2_CastOne = m_Player2.FindAction("CastOne", throwIfNotFound: true);
        m_Player2_Look = m_Player2.FindAction("Look", throwIfNotFound: true);
    }

    ~@MASTERCONTROLLER()
    {
        Debug.Assert(!m_Player1.enabled, "This will cause a leak and performance issues, MASTERCONTROLLER.Player1.Disable() has not been called.");
        Debug.Assert(!m_Player2.enabled, "This will cause a leak and performance issues, MASTERCONTROLLER.Player2.Disable() has not been called.");
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

    // Player1
    private readonly InputActionMap m_Player1;
    private List<IPlayer1Actions> m_Player1ActionsCallbackInterfaces = new List<IPlayer1Actions>();
    private readonly InputAction m_Player1_Move;
    private readonly InputAction m_Player1_CastTwo;
    private readonly InputAction m_Player1_CastOne;
    private readonly InputAction m_Player1_Look;
    public struct Player1Actions
    {
        private @MASTERCONTROLLER m_Wrapper;
        public Player1Actions(@MASTERCONTROLLER wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player1_Move;
        public InputAction @CastTwo => m_Wrapper.m_Player1_CastTwo;
        public InputAction @CastOne => m_Wrapper.m_Player1_CastOne;
        public InputAction @Look => m_Wrapper.m_Player1_Look;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void AddCallbacks(IPlayer1Actions instance)
        {
            if (instance == null || m_Wrapper.m_Player1ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player1ActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @CastTwo.started += instance.OnCastTwo;
            @CastTwo.performed += instance.OnCastTwo;
            @CastTwo.canceled += instance.OnCastTwo;
            @CastOne.started += instance.OnCastOne;
            @CastOne.performed += instance.OnCastOne;
            @CastOne.canceled += instance.OnCastOne;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
        }

        private void UnregisterCallbacks(IPlayer1Actions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @CastTwo.started -= instance.OnCastTwo;
            @CastTwo.performed -= instance.OnCastTwo;
            @CastTwo.canceled -= instance.OnCastTwo;
            @CastOne.started -= instance.OnCastOne;
            @CastOne.performed -= instance.OnCastOne;
            @CastOne.canceled -= instance.OnCastOne;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
        }

        public void RemoveCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer1Actions instance)
        {
            foreach (var item in m_Wrapper.m_Player1ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player1ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private List<IPlayer2Actions> m_Player2ActionsCallbackInterfaces = new List<IPlayer2Actions>();
    private readonly InputAction m_Player2_Move;
    private readonly InputAction m_Player2_CastTwo;
    private readonly InputAction m_Player2_CastOne;
    private readonly InputAction m_Player2_Look;
    public struct Player2Actions
    {
        private @MASTERCONTROLLER m_Wrapper;
        public Player2Actions(@MASTERCONTROLLER wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player2_Move;
        public InputAction @CastTwo => m_Wrapper.m_Player2_CastTwo;
        public InputAction @CastOne => m_Wrapper.m_Player2_CastOne;
        public InputAction @Look => m_Wrapper.m_Player2_Look;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void AddCallbacks(IPlayer2Actions instance)
        {
            if (instance == null || m_Wrapper.m_Player2ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player2ActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @CastTwo.started += instance.OnCastTwo;
            @CastTwo.performed += instance.OnCastTwo;
            @CastTwo.canceled += instance.OnCastTwo;
            @CastOne.started += instance.OnCastOne;
            @CastOne.performed += instance.OnCastOne;
            @CastOne.canceled += instance.OnCastOne;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
        }

        private void UnregisterCallbacks(IPlayer2Actions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @CastTwo.started -= instance.OnCastTwo;
            @CastTwo.performed -= instance.OnCastTwo;
            @CastTwo.canceled -= instance.OnCastTwo;
            @CastOne.started -= instance.OnCastOne;
            @CastOne.performed -= instance.OnCastOne;
            @CastOne.canceled -= instance.OnCastOne;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
        }

        public void RemoveCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer2Actions instance)
        {
            foreach (var item in m_Wrapper.m_Player2ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player2ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
    private int m_AllControlScemesSchemeIndex = -1;
    public InputControlScheme AllControlScemesScheme
    {
        get
        {
            if (m_AllControlScemesSchemeIndex == -1) m_AllControlScemesSchemeIndex = asset.FindControlSchemeIndex("All Control Scemes");
            return asset.controlSchemes[m_AllControlScemesSchemeIndex];
        }
    }
    public interface IPlayer1Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCastTwo(InputAction.CallbackContext context);
        void OnCastOne(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCastTwo(InputAction.CallbackContext context);
        void OnCastOne(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}

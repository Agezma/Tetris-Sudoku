// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""5c91e59e-861c-495d-8e6b-691587e9eb44"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""4a7bd81e-bfce-4778-a139-b3e7c54ac49a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hold"",
                    ""type"": ""PassThrough"",
                    ""id"": ""302d42ca-d211-4257-a651-54b3ceda6146"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swipe"",
                    ""type"": ""Button"",
                    ""id"": ""4e6253db-a188-4fd8-b2fd-93a141fda1da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpaceBar"",
                    ""type"": ""Button"",
                    ""id"": ""dc941222-f1da-4304-a5fc-df0a20700665"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""297595e2-c22f-4912-966d-9a3369cdc967"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d320fac-690c-4c6e-8999-a292939d58fd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e06504d-de82-49f0-9637-407db807db0e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e72be9b3-1fdf-49e3-bf78-4dcd456ba00d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""29c57547-ca80-463e-9c16-1608c881a9c7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dc912fe2-2694-4fb5-913c-6216108e9a3e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c5c4a795-12c4-43cb-ac52-c7dacd813f16"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpaceBar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_Hold = m_Player.FindAction("Hold", throwIfNotFound: true);
        m_Player_Swipe = m_Player.FindAction("Swipe", throwIfNotFound: true);
        m_Player_SpaceBar = m_Player.FindAction("SpaceBar", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Rotate;
    private readonly InputAction m_Player_Hold;
    private readonly InputAction m_Player_Swipe;
    private readonly InputAction m_Player_SpaceBar;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @Hold => m_Wrapper.m_Player_Hold;
        public InputAction @Swipe => m_Wrapper.m_Player_Swipe;
        public InputAction @SpaceBar => m_Wrapper.m_Player_SpaceBar;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Hold.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHold;
                @Hold.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHold;
                @Hold.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHold;
                @Swipe.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwipe;
                @Swipe.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwipe;
                @Swipe.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwipe;
                @SpaceBar.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpaceBar;
                @SpaceBar.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpaceBar;
                @SpaceBar.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpaceBar;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Hold.started += instance.OnHold;
                @Hold.performed += instance.OnHold;
                @Hold.canceled += instance.OnHold;
                @Swipe.started += instance.OnSwipe;
                @Swipe.performed += instance.OnSwipe;
                @Swipe.canceled += instance.OnSwipe;
                @SpaceBar.started += instance.OnSpaceBar;
                @SpaceBar.performed += instance.OnSpaceBar;
                @SpaceBar.canceled += instance.OnSpaceBar;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnHold(InputAction.CallbackContext context);
        void OnSwipe(InputAction.CallbackContext context);
        void OnSpaceBar(InputAction.CallbackContext context);
    }
}

// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input System/InputMaster.inputactions'

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
            ""id"": ""03594e4b-ab28-494e-a70c-8f203a849c43"",
            ""actions"": [
                {
                    ""name"": ""MovementKeys"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a3a854ea-4e3d-49b1-aa57-b17f1ff05135"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MovementMouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e51ade82-e035-4f66-b27d-8501e67ac768"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e474ffbb-b40c-45a4-a8ab-f6db85a80bb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5204e76d-3dc8-41a6-89dd-2dbf8d481ed8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UsePower "",
                    ""type"": ""PassThrough"",
                    ""id"": ""438c1b5e-b8d8-4456-b83f-69281b168479"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LoadLeftPower"",
                    ""type"": ""PassThrough"",
                    ""id"": ""66a82024-530e-4fa9-bf4c-f867e9b21ae7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LoadRightPower"",
                    ""type"": ""PassThrough"",
                    ""id"": ""147d7f9b-d805-4e06-93bd-ffe7f9128069"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset Ball"",
                    ""type"": ""PassThrough"",
                    ""id"": ""66517c36-2645-4ba6-93fe-ac8bafd9290e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""531a061a-adad-4f75-8e37-401c28fbb5be"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse;Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e250caf-97e6-4360-82d0-1e82c67faba6"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""d1dda606-2191-4604-b30a-a4536012ac88"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""2f03e849-dca9-4cea-a214-ad001a485daa"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""dd29ef2f-6295-4060-a4f5-718d4f7e8e83"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""c3028872-5480-4bc3-ae4e-559f4495a439"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""7a2992db-4634-4b9f-8f56-d56af322c200"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""58a20152-a856-40ca-b73c-bf4e90e07372"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""2c671610-b216-44a2-ba6f-93b858e71a8a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""414111a7-0d86-4fed-bcf8-5dd48953e6e2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""44c80491-3661-494c-b40c-21584e1bbac8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""510ea4a7-d738-4ddc-b0fd-d2b79947bdaf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""c1a27ff8-3cf1-4e58-b7e4-caba34d5cb8b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""3cf2999e-329a-4508-8b87-faea495f1ce8"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""475db9d4-e8c4-4705-8804-2fe51fb5f1c4"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""a764ddb7-9300-4dcb-8848-f988ac9ffe9a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""349c9eb8-dd8c-4916-8a54-efaa201923cf"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0db493fe-94f5-4e99-8726-27938472614c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UsePower "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29350123-0e59-4b20-ac4d-6a155d2f0498"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""UsePower "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71536ab0-3a6b-4de3-9001-4ea421a193a0"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""UsePower "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75bd2b83-ce51-4d1c-af65-e7b25bb0ca2d"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""MovementMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58d99baf-0826-4260-90fd-efbcc550f360"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""131db775-a3bc-48c3-b50f-7585fbb7900c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fee18fd-f5fb-41b3-ac64-2780e04d94be"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3019c9b-d792-410c-9ad8-8de8e4372938"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LoadLeftPower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62060339-4529-427c-b233-b8434859c9fa"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LoadLeftPower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db4ef2aa-955b-4950-bad0-ce026a2ccd0d"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""LoadLeftPower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96ed5cec-bfbb-43b5-9518-f459447dac1f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LoadRightPower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b421ebe8-ff0e-4f0b-a607-59edf59b85a4"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LoadRightPower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43a36d16-8482-4d84-983a-013942f2c951"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""LoadRightPower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca30fa4b-58d0-4cef-aad3-91c892c9565d"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reset Ball"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c074393-45b7-4dd4-bb76-4e1098364d55"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Reset Ball"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MovementKeys = m_Player.FindAction("MovementKeys", throwIfNotFound: true);
        m_Player_MovementMouse = m_Player.FindAction("MovementMouse", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_UsePower = m_Player.FindAction("UsePower ", throwIfNotFound: true);
        m_Player_LoadLeftPower = m_Player.FindAction("LoadLeftPower", throwIfNotFound: true);
        m_Player_LoadRightPower = m_Player.FindAction("LoadRightPower", throwIfNotFound: true);
        m_Player_ResetBall = m_Player.FindAction("Reset Ball", throwIfNotFound: true);
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
    private readonly InputAction m_Player_MovementKeys;
    private readonly InputAction m_Player_MovementMouse;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_UsePower;
    private readonly InputAction m_Player_LoadLeftPower;
    private readonly InputAction m_Player_LoadRightPower;
    private readonly InputAction m_Player_ResetBall;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementKeys => m_Wrapper.m_Player_MovementKeys;
        public InputAction @MovementMouse => m_Wrapper.m_Player_MovementMouse;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @UsePower => m_Wrapper.m_Player_UsePower;
        public InputAction @LoadLeftPower => m_Wrapper.m_Player_LoadLeftPower;
        public InputAction @LoadRightPower => m_Wrapper.m_Player_LoadRightPower;
        public InputAction @ResetBall => m_Wrapper.m_Player_ResetBall;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MovementKeys.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementKeys;
                @MovementKeys.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementKeys;
                @MovementKeys.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementKeys;
                @MovementMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementMouse;
                @MovementMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementMouse;
                @MovementMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementMouse;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @UsePower.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePower;
                @UsePower.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePower;
                @UsePower.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePower;
                @LoadLeftPower.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadLeftPower;
                @LoadLeftPower.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadLeftPower;
                @LoadLeftPower.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadLeftPower;
                @LoadRightPower.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadRightPower;
                @LoadRightPower.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadRightPower;
                @LoadRightPower.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadRightPower;
                @ResetBall.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetBall;
                @ResetBall.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetBall;
                @ResetBall.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetBall;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementKeys.started += instance.OnMovementKeys;
                @MovementKeys.performed += instance.OnMovementKeys;
                @MovementKeys.canceled += instance.OnMovementKeys;
                @MovementMouse.started += instance.OnMovementMouse;
                @MovementMouse.performed += instance.OnMovementMouse;
                @MovementMouse.canceled += instance.OnMovementMouse;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @UsePower.started += instance.OnUsePower;
                @UsePower.performed += instance.OnUsePower;
                @UsePower.canceled += instance.OnUsePower;
                @LoadLeftPower.started += instance.OnLoadLeftPower;
                @LoadLeftPower.performed += instance.OnLoadLeftPower;
                @LoadLeftPower.canceled += instance.OnLoadLeftPower;
                @LoadRightPower.started += instance.OnLoadRightPower;
                @LoadRightPower.performed += instance.OnLoadRightPower;
                @LoadRightPower.canceled += instance.OnLoadRightPower;
                @ResetBall.started += instance.OnResetBall;
                @ResetBall.performed += instance.OnResetBall;
                @ResetBall.canceled += instance.OnResetBall;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
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
    public interface IPlayerActions
    {
        void OnMovementKeys(InputAction.CallbackContext context);
        void OnMovementMouse(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnUsePower(InputAction.CallbackContext context);
        void OnLoadLeftPower(InputAction.CallbackContext context);
        void OnLoadRightPower(InputAction.CallbackContext context);
        void OnResetBall(InputAction.CallbackContext context);
    }
}

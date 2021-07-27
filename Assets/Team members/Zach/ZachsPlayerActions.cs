// GENERATED AUTOMATICALLY FROM 'Assets/Team members/Zach/ZachsPlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ZachsPlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ZachsPlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ZachsPlayerActions"",
    ""maps"": [
        {
            ""name"": ""General Movement"",
            ""id"": ""d8102bd5-e1c8-4612-952e-9639eba5920d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""aef8d1e3-ba9c-46da-ac23-489cfd7f98f8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""acb9f070-cfe9-4eb9-8a39-73c5425c0f08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WS"",
                    ""id"": ""eae64148-e7ca-4a4c-a459-11b9dc12c387"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a058fe63-271d-4afc-9338-f7492d4da63e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""68ae0e61-0d53-45e2-8d28-71768117896f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""313b94c5-3a7c-4222-9d8a-175a06dd73c8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0870d717-2e71-46bc-a05d-c6571ada1eec"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ed5a4e00-183c-42a1-beb9-65d3e162193a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // General Movement
        m_GeneralMovement = asset.FindActionMap("General Movement", throwIfNotFound: true);
        m_GeneralMovement_Move = m_GeneralMovement.FindAction("Move", throwIfNotFound: true);
        m_GeneralMovement_Rotate = m_GeneralMovement.FindAction("Rotate", throwIfNotFound: true);
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

    // General Movement
    private readonly InputActionMap m_GeneralMovement;
    private IGeneralMovementActions m_GeneralMovementActionsCallbackInterface;
    private readonly InputAction m_GeneralMovement_Move;
    private readonly InputAction m_GeneralMovement_Rotate;
    public struct GeneralMovementActions
    {
        private @ZachsPlayerActions m_Wrapper;
        public GeneralMovementActions(@ZachsPlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GeneralMovement_Move;
        public InputAction @Rotate => m_Wrapper.m_GeneralMovement_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_GeneralMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralMovementActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralMovementActions instance)
        {
            if (m_Wrapper.m_GeneralMovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GeneralMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GeneralMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GeneralMovementActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_GeneralMovementActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GeneralMovementActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GeneralMovementActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_GeneralMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public GeneralMovementActions @GeneralMovement => new GeneralMovementActions(this);
    public interface IGeneralMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}

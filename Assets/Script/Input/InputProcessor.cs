using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputProcessor : MonoBehaviour, DefaultInput.IDefaultActions {
    [SerializeField] private UnityEvent<float> player1Move;
    [SerializeField] private UnityEvent<float> player2Move;
    
    private DefaultInput _defaultInput;
    public void OnPlayer1(InputAction.CallbackContext context) {
        player1Move.Invoke(context.ReadValue<float>());
    }

    public void OnPlayer2(InputAction.CallbackContext context) {
        if (GameSettings.Instance.IS_PLAYER2_AI) return;

        player2Move.Invoke(context.ReadValue<float>());
    }

    private void OnEnable() {
        _defaultInput ??= new DefaultInput();
        _defaultInput.Default.SetCallbacks(this);
        _defaultInput.Default.Enable();
    }

    private void OnDisable() {
        _defaultInput = null;
    }
}
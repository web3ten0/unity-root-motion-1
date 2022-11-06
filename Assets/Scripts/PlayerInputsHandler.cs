using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsHandler : MonoBehaviour
{
    private PlayerInput _input;
    private Vector2 _move, _look;
    private bool _sprint, _crouch, _jump;

    private void Awake()
    {
        TryGetComponent(out _input);
    }

    private void OnEnable()
    {
        _input.actions["Move"].performed += OnMove;
        _input.actions["Move"].canceled += OnMove;
        _input.actions["Look"].performed += OnLook;
        _input.actions["Look"].canceled += OnLook;
        _input.actions["Sprint"].started += OnSprintStart;
        _input.actions["Sprint"].canceled += OnSprintStop;
        _input.actions["Crouch"].started += OnCrouchStart;
        _input.actions["Crouch"].canceled += OnCrouchStop;
        _input.actions["Jump"].started += OnJumpStart;
        _input.actions["Jump"].canceled += OnJumpStop;
    }

    private void OnDisable()
    {
        _input.actions["Move"].performed -= OnMove;
        _input.actions["Move"].canceled -= OnMove;
        _input.actions["Look"].performed -= OnLook;
        _input.actions["Look"].canceled -= OnLook;
        _input.actions["Sprint"].started -= OnSprintStart;
        _input.actions["Sprint"].canceled -= OnSprintStop;
        _input.actions["Crouch"].started -= OnCrouchStart;
        _input.actions["Crouch"].canceled -= OnCrouchStop;
        _input.actions["Jump"].started -= OnJumpStart;
        _input.actions["Jump"].canceled -= OnJumpStop;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }
    private void OnLook(InputAction.CallbackContext context)
    {
        _look = context.ReadValue<Vector2>();
    }

    private void OnSprintStart(InputAction.CallbackContext context)
    {
        _sprint = true;
    }

    private void OnSprintStop(InputAction.CallbackContext context)
    {
        _sprint = false;
    }

    private void OnCrouchStart(InputAction.CallbackContext context)
    {
        _crouch = true;
    }

    private void OnCrouchStop(InputAction.CallbackContext context)
    {
        _crouch = false;
    }

    private void OnJumpStart(InputAction.CallbackContext context)
    {
        _jump = true;
    }

    private void OnJumpStop(InputAction.CallbackContext context)
    {
        _jump = false;
    }

    public Vector2 GetMove()
    {
        return _move;
    }

    public Vector2 GetLook()
    {
        return _look;
    }

    public bool GetSprint()
    {
        return _sprint;
    }

    public bool GetCrouch()
    {
        return _crouch;
    }

    public bool GetJump()
    {
        return _jump;
    }

}

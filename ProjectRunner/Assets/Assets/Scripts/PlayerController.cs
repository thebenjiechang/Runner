using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CustomInput input = null;
    float moveVector;
    Vector3 m_velocity = Vector3.zero;
    PlayerMovement playerMovement;

    private void Awake()
    {
        input = new CustomInput();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementPerformed;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementPerformed;
    }

    void OnMovementPerformed(InputAction.CallbackContext inputValue)
    {
        moveVector = inputValue.ReadValue<float>();
    }

    void OnMovementCancelled(InputAction.CallbackContext inputValue)
    {
        moveVector = 0;
    }

    private void FixedUpdate()
    {
        playerMovement.Move(moveVector, false, false);
    }

}

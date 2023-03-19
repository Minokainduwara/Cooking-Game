using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    public event EventHandler OnInteractAction;
    private void Awake()
    {
        playerInputActions =  new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException(); 
        OnInteractAction?.Invoke(this, EventArgs.Empty);    
    }

    public Vector2 GetMovementVectorNormalized()
    {
        //Inputs
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        /*
         * old input method
         * 
         * 
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }


        */

        inputVector = inputVector.normalized;
        return inputVector;
    }
}

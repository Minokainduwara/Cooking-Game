using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 7f;

    [SerializeField]
    private GameInputs gameInput;

    private bool isWalking;
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteractions()
    {
        //Get Inputs
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();


        //move the player
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        //Raycast 
        float interactDistance = 2f;
        Physics.Raycast(transform.position, moveDir, interactDistance);
    }

    private void HandleMovement()
    {
        //Get Inputs
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();


        //move the player
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        //Raycast or Capsule cast
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            // Cannot move towards moveDir

            //Attempt only x movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                //Can move only x
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only on the X

                //Attempt only z movements
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    // can move only on z
                    moveDir = moveDirZ;
                }
                else
                {
                    //cannot move in any direction

                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        //is player moving ?
        isWalking = moveDir != Vector3.zero;

        //Rotate the player into moving direction
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);


    }
}

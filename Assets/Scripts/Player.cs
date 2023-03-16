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
        //Get Inputs
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();


        //move the player
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        //is player moving ?
        isWalking = moveDir != Vector3.zero;

        //Rotate the player into moving direction
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}

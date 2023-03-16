using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private const string IS_WALKING = "isWalking";

    [SerializeField]
    private Player player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        //Play walking Animation
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}

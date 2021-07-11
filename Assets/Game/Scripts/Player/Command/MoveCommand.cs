using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MoveCommand : ICommand
{
    [SerializeField]
    private PlayerMovement2D playerMovement = null;
    private Animator animator = null;
    private Transform transform = null;
    private float direction = 0;

    public MoveCommand(PlayerMovement2D playerMovement, Animator animator, Transform transform, float direction)
    {
        this.playerMovement = playerMovement;
        this.animator = animator;
        this.transform = transform;
        this.direction = direction;
    }

    public void Execute()
    {
        playerMovement.Move(direction);
        SetAnimation();
        if (direction != 0)
            PlayerFlip();
    }

    void SetAnimation()
    {
        if (direction != 0)
        {
            animator.SetBool("Run", true);
            animator.SetFloat("RunState", 0.5f);
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetFloat("RunState", 0f);
        }
    }

    void PlayerFlip()
    {
        float scaleX = transform.localScale.x;
        if (direction > 0)
        {
            if (scaleX > 0)
                scaleX *= -1;

            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (direction < 0)
        {
            if (scaleX < 0)
                scaleX *= -1;

            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

}

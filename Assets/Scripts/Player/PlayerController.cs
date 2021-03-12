using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private PlayerMovement2D movement2D;

    [SerializeField]
    private Animator animator;

    private float fDirection = 0f;

    // Start is called before the first frame update
    void Start()
    {
        movement2D = GetComponent<PlayerMovement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        fDirection = Input.GetAxisRaw("Horizontal");
        movement2D.Move(fDirection);

        if (fDirection != 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                movement2D.TryDash(fDirection);
            }

            animator.SetBool("Run", true);
            animator.SetFloat("RunState", 0.5f);
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetFloat("RunState", 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(movement2D.IsFlatformer && Input.GetKey(KeyCode.DownArrow))
            {
                movement2D.DownJump();
            }
            else
            {
                movement2D.Jump();
            }
        }

        PlayerFlip(fDirection);
    }

    void PlayerFlip(float _fDir)
    {
        float scaleX = transform.localScale.x;
        if (_fDir > 0)
        {
            if (scaleX > 0)
                scaleX *= -1;

            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (_fDir < 0)
        {
            if (scaleX < 0)
                scaleX *= -1;

            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

}

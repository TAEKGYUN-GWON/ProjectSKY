using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Movement2D movement2D;

    [SerializeField]
    private Animator animator;

    private float direction = 0f;

    // Start is called before the first frame update
    void Start()
    {
        movement2D = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        direction = Input.GetAxisRaw("Horizontal");
        movement2D.Move(direction);

        if (direction != 0)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                movement2D.TryDash(direction);
            }
            else
            {
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
            movement2D.Jump();
        }

        PlayerFlip(direction);
    }

    void PlayerFlip(float dir)
    {
        float scaleX = transform.localScale.x;
        if (dir > 0)
        {
            if (scaleX > 0)
                scaleX *= -1;

            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (dir < 0)
        {
            if (scaleX < 0)
                scaleX *= -1;

            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

}

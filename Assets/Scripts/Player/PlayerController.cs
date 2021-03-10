using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Movement2D movement2D;

    [SerializeField]
    private Animator animator;

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
        float x = Input.GetAxisRaw("Horizontal");

        movement2D.Move(x);

        if(x != 0)
        {
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

        PlayerFlip(x);
    }

    void PlayerFlip(float x)
    {
        if (x > 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }

}

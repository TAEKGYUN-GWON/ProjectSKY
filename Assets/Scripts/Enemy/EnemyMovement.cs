using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    EnemyState enemyState;
    public bool bCanMove;
    float fScaleX;
    [SerializeField]
    private Animator animator;
    


    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        enemyState = GetComponent<EnemyState>();
        bCanMove = true;
        fScaleX = transform.localScale.x;

    }

    public void Move(float _x)
    {
        if (_x.Equals(0))
        {
            rigid2D.velocity = new Vector2(_x * enemyState.fMoveSpeed, rigid2D.velocity.y);
            animator.SetBool("Run", false);
            animator.SetFloat("RunState", 0);
            return;
        }
        if (_x > 0)
        {
            transform.localScale = new Vector3(-fScaleX, transform.localScale.y, transform.localScale.z);
        }
        else if(_x <0)
        {
            transform.localScale = new Vector3(fScaleX, transform.localScale.y, transform.localScale.z);

        }
        animator.SetBool("Run", true);
        animator.SetFloat("RunState", 0.5f);
        rigid2D.velocity = new Vector2(_x * enemyState.fMoveSpeed, rigid2D.velocity.y);


    }
    void EnemyDirection(float _fDir)
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


    public void Hit(float _x)
    {
        if (_x > 0)
            rigid2D.velocity = new Vector2(-1, rigid2D.velocity.y);
        
        else
            rigid2D.velocity = new Vector2(1, rigid2D.velocity.y);


    }

    private void Update()
    {
        //Move(-1);
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    EnemyMovement enemyMovement;
    [SerializeField]
    EnemyState EnemyState;
    [SerializeField]
    public int selectPattern;

    public BoxCollider2D Tracer;
    int nPlayerLayer;
    LayerMask playerMask;
    private float fLastMoveTime;
    private float fDelay;
    private int nParameter;
    private bool bInPlayer;
    Vector3 playerTransform;

    bool bisIdle;
    bool bisTrace;
    


    private void Start()
    {
        Tracer = GetComponent<BoxCollider2D>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
        nPlayerLayer = LayerMask.NameToLayer("Player");
        fLastMoveTime = 0;
        bInPlayer = false;
    }


    private void Update()
    {
        Pattern1();




    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bInPlayer = true;
            playerTransform = collision.transform.position;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            playerTransform = collision.transform.position;

        }
        if (enemyMovement.bCanMove && bInPlayer)
        {
            if (transform.position.x > playerTransform.x)        //플레이어가 왼쪽
            {
                enemyMovement.Move(-0.7f);

            }
            else if (transform.position.x < playerTransform.x)    //플레이어가 오른쪽
            {
                enemyMovement.Move(0.7f);
            }
            else
            {
                enemyMovement.Move(0f);

            }


        }


    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            bInPlayer = false;
    }


    public void Pattern1()
    {
        fDelay = Random.Range(1.5f, 3.0f);

        if (!bInPlayer && enemyMovement.bCanMove)
        {
            if (Time.time > fLastMoveTime + 3f)
            {
                nParameter = Random.Range(1, 10);

                if (nParameter <= 4)
                {
                    enemyMovement.Move(0.7f);
                }
                else if (nParameter > 5 && nParameter <= 8)
                {
                    enemyMovement.Move(-0.7f);
                }
                else
                {
                    enemyMovement.Move(0);

                }
                fLastMoveTime = Time.time;
            }

        }

    }

    public void Pattern2()
    {



    }




}

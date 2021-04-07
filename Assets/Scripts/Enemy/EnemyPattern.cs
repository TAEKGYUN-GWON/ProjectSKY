using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour
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
    int a;



    private void Start()
    {
        Tracer = GetComponent<BoxCollider2D>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
        nPlayerLayer = LayerMask.NameToLayer("Player");
        fLastMoveTime = 0;
        bInPlayer = false;
        a = 1;



    }


    private void Update()
    {
        // if (Time.time > fLastMoveTime + 2.0f)
         Pattern1();
        if(Input.GetKeyDown(KeyCode.F1))
        {
            bInPlayer = true;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            bInPlayer = false;
        }

        
        //if (a == 1)
        //{
        //    enemyMovement.Move(-0.5f);
        //    a = 0;
        //}

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
        if (bInPlayer)
        {
            if (transform.position.x > playerTransform.x)        //플레이어가 왼쪽
            {
                enemyMovement.Move(-0.7f);
                Debug.Log("왼쪽으로");

            }
            else if (transform.position.x < playerTransform.x)    //플레이어가 오른쪽
            {
                enemyMovement.Move(0.7f);
                Debug.Log("오른쪽으로");
                Debug.Log("trans  "+transform.position.x);
                Debug.Log("player  "+playerTransform);
                //Debug.Log(collision.transform.position);

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
        Debug.Log("test");



        if (!bInPlayer)
        {
            Debug.Log("움직여");
            if (Time.time > fLastMoveTime + 3f)
            {
                nParameter = Random.Range(1, 10);

                if (nParameter <= 2)
                {
                    enemyMovement.Move(0.7f);
                }
                else if (nParameter > 2 && nParameter <= 4)
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

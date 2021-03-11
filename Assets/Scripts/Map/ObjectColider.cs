using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColider : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(gameObject);
       // Debug.Log("asdf");
       // if(tag == "Player")
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("충돌");
            GetComponent<Explosion>().Ex();
            
        }
    }



    //public float explosionStrength = 100;
    //void OnCollisionEnter2D(Collision2D _other)
    //{
    //    if(tag == "Player")
    //    GetComponent<Rigidbody2D>().AddExplosionForce(explosionStrength, this.transform.position, 5);

    //}


}

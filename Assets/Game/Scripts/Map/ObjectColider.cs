using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColider : MonoBehaviour
{
    [SerializeField]
    public int nDurability = 1;


    //private void OnCollisionEnter2D(Collision2D _collision)
    //{


    //    if (_collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("충돌");
    //        nDurability--;
    //        if(nDurability <1)
    //        {
    //            GetComponent<Explosion>().Ex();
    //        }

    //    }
    //}


   



    //public float explosionStrength = 100;
    //void OnCollisionEnter2D(Collision2D _other)
    //{
    //    if(tag == "Player")
    //    GetComponent<Rigidbody2D>().AddExplosionForce(explosionStrength, this.transform.position, 5);

    //}


}

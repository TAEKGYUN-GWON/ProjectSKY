using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRealAttack : MonoBehaviour
{
    [SerializeField]
    EnemyState ES;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            var _entity = collision.GetComponent<LivingEntity>();

            if (_entity == null)
                return;
            collision.GetComponent<LivingEntity>().OnDamage(ES.fPhysicalDamage);
            Debug.Log("어택 끝날라함");
        }

    }

}

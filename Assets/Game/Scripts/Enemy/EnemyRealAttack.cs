using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRealAttack : MonoBehaviour
{
    [SerializeField]
    EnemyState ES;



    private void OnTriggerEnter2D(Collider2D collision)                 //실제로 플레이어가 영역에 있으면 데미지를 주는 코드
    {
        if(collision.tag == "Player")
        {
            var _entity = collision.GetComponent<LivingEntity>();

            if (_entity == null)
                return;
            collision.GetComponent<LivingEntity>().OnDamage(ES.fPhysicalDamage);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    [SerializeField]
    PlayerInfo playerInfo = null;
    [SerializeField]
    CapsuleCollider2D capsuleCollider2D = null;

    public void Attack()
    {
        capsuleCollider2D.enabled = true;
    }

    public void AttackEnd()
    {
        capsuleCollider2D.enabled = false;
    }

    public void Hit(LivingEntity _livingEntity)
    {
        if(playerInfo == null)
        {
            Debug.LogError("Player Info Missing");
            return;
        }

        playerInfo.OnDamage(_livingEntity.fAttDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            var _entity = collision.GetComponent<LivingEntity>();



        }
    }




}

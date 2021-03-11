using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;

public static class Rigidbody2DExt
{

    public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
    {
        var explosionDir = rb.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;

        // Normalize without computing magnitude again
        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else
        {
            // From Rigidbody.AddExplosionForce doc:
            // If you pass a non-zero value for the upwardsModifier parameter, the direction
            // will be modified by subtracting that value from the Y component of the centre point.
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }

        rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
    }
}

public class Explosion : MonoBehaviour
{
    [SerializeField]
    GameObject exPrefab = null;
    [SerializeField]
    float exForce = 0f;
    [SerializeField]
    Vector3 exOffset = Vector3.zero;



    public void Ex()
    {
        GameObject exClone = Instantiate(exPrefab, transform.position, Quaternion.identity);
        Rigidbody2D[] exRigids = exClone.GetComponentsInChildren<Rigidbody2D>();
        for(int i =0;i<exRigids.Length;i++)
        {
            exRigids[i].AddExplosionForce(exForce, transform.position + exOffset, 1f);
        }
        gameObject.SetActive(false);


    }




}

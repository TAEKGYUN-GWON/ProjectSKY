using System.Collections;
using System.Collections.Generic;
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
    GameObject exFragments = null;
    [SerializeField]
    GameObject exOrigin = null;

    [SerializeField]
    float fExForce = 0f;
    [SerializeField]
    Vector3 exOffset = Vector3.zero;



    public void Ex()
    {
        var colider = GetComponent<BoxCollider2D>();
        colider.enabled = false;
        exOrigin.SetActive(false);
        exFragments.SetActive(true);
        Rigidbody2D[] exRigids = exFragments.GetComponentsInChildren<Rigidbody2D>();
        for(int i =0;i<exRigids.Length;i++)
        {
            exRigids[i].AddExplosionForce(fExForce, transform.position + exOffset, 1f);
        }
    }




}

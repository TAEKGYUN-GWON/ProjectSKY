using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fragments : MonoBehaviour
{
    int iPlayerLayer, iFragmentsLayer;
    

    private void Start()
    {
        iPlayerLayer = LayerMask.NameToLayer("Player");
        iFragmentsLayer = LayerMask.NameToLayer("Fragments");


        Physics2D.IgnoreLayerCollision(iPlayerLayer, iFragmentsLayer, true);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fragments : MonoBehaviour
{
    int nPlayerLayer, nFragmentsLayer;


    private void Start()
    {
        nPlayerLayer = LayerMask.NameToLayer("Player");
        nFragmentsLayer = LayerMask.NameToLayer("Fragments");


        Physics2D.IgnoreLayerCollision(nPlayerLayer, nFragmentsLayer, true);
    }

}
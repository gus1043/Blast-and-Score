using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpereBehavior : MonoBehaviour
{
    public int sperehp = 2;

    private void OnTriggerEnter(Collider other)
    {
        sperehp--;

        if (sperehp <= 0)
        {

            Destroy(gameObject);
        }
    }
}

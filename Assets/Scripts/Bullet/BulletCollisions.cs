using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target") 
        {
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}

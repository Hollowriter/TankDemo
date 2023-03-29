using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target") 
        {
            ScoreManager.instance.AddScore(other.gameObject.GetComponent<Sphere>().GetSphereScoreValue());
            AudioManager.instance.PlayScore();
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}

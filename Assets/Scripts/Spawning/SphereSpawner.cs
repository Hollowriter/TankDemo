using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : Singleton<SphereSpawner>
{
    [SerializeField] private GameObject sphereToGenerate;
    [SerializeField] private Vector3[] spheresPositions;

    private void Generate() 
    {
        for (int i = 0; i < spheresPositions.Length && i < SpherePool.instance.GetSphereQuantity(); i++) 
        {
            GameObject newSphere = GameObject.Instantiate(sphereToGenerate);
            newSphere.transform.position = spheresPositions[i];
        }
    }

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        Generate();
    }

    private void Awake()
    {
        SingletonAwake();
    }
}

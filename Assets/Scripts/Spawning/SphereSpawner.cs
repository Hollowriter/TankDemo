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
            newSphere.transform.parent = this.transform;
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

    public Transform GetSphereTransform(int index) 
    {
        if (this.transform.childCount != 0)
        {
            if (this.transform.GetChild(index).gameObject.activeInHierarchy)
            {
                return this.transform.GetChild(index);
            }
        }
        return null;
    }

    public int GetSpheresCount() 
    {
        return this.transform.childCount;
    }

    public bool AreSpheresActive() 
    {
        if (this.transform.childCount != 0)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if (this.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

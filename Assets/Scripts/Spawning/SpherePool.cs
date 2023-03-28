using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePool : Singleton<SpherePool>
{
    [SerializeField] private int sphereQuantity;

    public int GetSphereQuantity() 
    {
        return sphereQuantity;
    }

    private void Awake()
    {
        SingletonAwake();
    }
}

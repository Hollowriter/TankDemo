using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SphereType 
{
    Bouncer,
    Follower
}

public abstract class Sphere : MonoBehaviour
{
    [SerializeField] protected int sphereImpulse;
    [SerializeField] protected int sphereScoreValue;

    protected abstract void SphereBehaviour();

    public int GetSphereScoreValue() 
    {
        return sphereScoreValue;
    }
}

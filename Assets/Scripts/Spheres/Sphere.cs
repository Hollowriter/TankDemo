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
    protected abstract void SphereBehaviour();
}

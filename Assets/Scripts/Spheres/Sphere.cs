using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sphere : MonoBehaviour
{
    [SerializeField] protected int sphereImpulse;
    protected abstract void SphereBehaviour();
}

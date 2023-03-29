using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFollower : Sphere
{
    protected override void SphereBehaviour()
    {
        float totalSpeed = sphereImpulse * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, TankMovement.instance.transform.position, totalSpeed);
    }

    private void Update()
    {
        if (!PauseManager.instance.GetPaused())
            SphereBehaviour();
    }
}

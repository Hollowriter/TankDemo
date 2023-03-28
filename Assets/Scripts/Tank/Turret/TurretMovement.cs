using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : Singleton<TurretMovement>
{
	[SerializeField] private int turretSpeed;
	[SerializeField] private float limitAngleRotation;
	private Vector3 target;
	private bool rotate;
	private const float MAXIMUMDISTANCEFROMOBJECT = 999999999999999999999f;

	public bool IsRotating() 
	{
		return rotate;
	}

	private void RotateTowardsTarget()
	{
		if (rotate) 
		{
			Vector3 targetDirection = target - this.transform.position;
			float totalSpeed = turretSpeed * Time.deltaTime;
			Vector3 toRotate = Vector3.RotateTowards(this.transform.forward, targetDirection, totalSpeed, 0);
			this.transform.rotation = Quaternion.LookRotation(toRotate);
			if (Vector3.Dot(this.transform.forward, targetDirection.normalized) >= limitAngleRotation)
				rotate = false;
		}
	}

	private void StartRotation() 
	{
		float closerDistance = MAXIMUMDISTANCEFROMOBJECT;
		float distanceToCheck = 0f;
		if (!SphereSpawner.instance.AreSpheresActive())
		{
			rotate = false;
			return;
		}
		for (int i = 0; i < SphereSpawner.instance.GetSpheresCount() && i < SpherePool.instance.GetSphereQuantity(); i++) 
		{
			if (SphereSpawner.instance.GetSphereTransform(i) != null) 
			{
				distanceToCheck = Vector3.Distance(SphereSpawner.instance.GetSphereTransform(i).position, this.transform.position);
			}
            else 
			{
				distanceToCheck = MAXIMUMDISTANCEFROMOBJECT;
			}

			if (distanceToCheck < closerDistance) 
			{
				closerDistance = distanceToCheck;
				target = SphereSpawner.instance.GetSphereTransform(i).position;
			}
		}
		rotate = true;
	}

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
		rotate = false;
		TankControls.instance.RotateTurretPressed += StartRotation;
    }

    private void Awake()
	{
		SingletonAwake();
	}

    private void Update()
    {
		RotateTowardsTarget();
    }
}

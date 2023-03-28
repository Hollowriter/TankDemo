using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : Singleton<TurretMovement>
{
	[SerializeField] private int turretSpeed;
	[SerializeField] private float limitAngleRotation;
	[SerializeField] private GameObject target;
	private bool rotate;

	public bool IsRotating() 
	{
		return rotate;
	}

	private void RotateTowardsTarget()
	{
		if (rotate) 
		{
			Vector3 targetDirection = target.transform.position - this.transform.position;
			float totalSpeed = turretSpeed * Time.deltaTime;
			Vector3 toRotate = Vector3.RotateTowards(this.transform.forward, targetDirection, totalSpeed, 0);
			this.transform.rotation = Quaternion.LookRotation(toRotate);
			if (Vector3.Dot(this.transform.forward, targetDirection.normalized) >= limitAngleRotation)
				rotate = false;
		}
	}

	private void StartRotation() 
	{
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

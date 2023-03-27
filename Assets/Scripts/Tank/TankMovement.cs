using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : Singleton<TankMovement>
{
	[SerializeField] Rigidbody rb;
	[SerializeField] private int tankMovementSpeed;
	[SerializeField] private int tankRotationSpeed;

	private void MoveUp()
	{
		rb.MovePosition(transform.position + (transform.forward * tankMovementSpeed * Time.fixedDeltaTime));
	}

	private void MoveDown()
	{
		rb.MovePosition(transform.position + (transform.forward * -1 * tankMovementSpeed * Time.fixedDeltaTime));
	}

	private void RotateLeft()
	{
		Vector3 eulerMovement = new Vector3(0, -1 * tankRotationSpeed, 0);
		Quaternion deltaRotation = Quaternion.Euler(eulerMovement * Time.fixedDeltaTime);
		rb.MoveRotation(rb.rotation * deltaRotation);
	}

	private void RotateRight()
	{
		Vector3 eulerMovement = new Vector3(0, 1 * tankRotationSpeed, 0);
		Quaternion deltaRotation = Quaternion.Euler(eulerMovement * Time.fixedDeltaTime);
		rb.MoveRotation(rb.rotation * deltaRotation);
	}

	protected override void SingletonAwake()
	{
		base.SingletonAwake();
		TankControls.instance.UpPressed += MoveUp;
		TankControls.instance.DownPressed += MoveDown;
		TankControls.instance.RotateRightPressed += RotateRight;
		TankControls.instance.RotateLeftPressed += RotateLeft;
	}

	private void Awake()
	{
		SingletonAwake();
	}
}

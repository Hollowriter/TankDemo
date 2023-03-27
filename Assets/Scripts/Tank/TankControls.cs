using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : Singleton<TankControls>
{
	public delegate void ButtonPressed();
	public ButtonPressed UpPressed;
	public ButtonPressed DownPressed;
	public ButtonPressed RotateRightPressed;
	public ButtonPressed RotateLeftPressed;
	public ButtonPressed RotateTurretPressed;
	public ButtonPressed ShootPressed;

	private void Awake()
	{
		SingletonAwake();
	}

	private void ReadingControls()
	{
		if (Input.GetKey(InputManager.instance.up))
		{
			UpPressed();
		}
		if (Input.GetKey(InputManager.instance.down))
		{
			DownPressed();
		}
		if (Input.GetKey(InputManager.instance.right))
		{
			RotateRightPressed();
		}
		if (Input.GetKey(InputManager.instance.left))
		{
			RotateLeftPressed();
		}
		if (Input.GetKey(InputManager.instance.leftClick))
		{
			ShootPressed();
		}
		if (Input.GetKey(InputManager.instance.rightClick))
		{
			RotateTurretPressed();
		}
	}

	private void Update()
	{
		ReadingControls();
	}
}

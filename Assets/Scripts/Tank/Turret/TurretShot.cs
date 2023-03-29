using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShot : Singleton<TurretShot>
{
	[SerializeField] private GameObject bullet;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
		TankControls.instance.ShootPressed += Shoot;
		bullet.SetActive(false);
    }

    private void Awake()
	{
		SingletonAwake();
	}

	private void Shoot() 
	{
		if (!bullet.activeInHierarchy && !TurretMovement.instance.IsRotating())
		{
			AudioManager.instance.PlayShoot();
			bullet.SetActive(true);
			bullet.GetComponent<Bullet>().ResetLifeTime();
			bullet.GetComponent<Bullet>().SetPosition(this.gameObject.transform.position);
			bullet.GetComponent<Bullet>().SetRotation(this.gameObject.transform.rotation);
		}
	}
}

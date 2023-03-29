using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBouncer : Sphere
{
    [SerializeField] private int timeToJump;
    [SerializeField] private Rigidbody rb;
    private float _jumpTimer;

    private void Awake()
    {
        _jumpTimer = 0;
    }

    protected override void SphereBehaviour()
    {
        _jumpTimer += Time.deltaTime;
        if (_jumpTimer >= timeToJump) 
        {
            rb.AddForce(Vector3.up * sphereImpulse, ForceMode.Impulse);
            _jumpTimer = 0;
        }
    }

    private void Update()
    {
        if (!PauseManager.instance.GetPaused() && !GameOverManager.instance.GameOver())
            SphereBehaviour();
    }
}

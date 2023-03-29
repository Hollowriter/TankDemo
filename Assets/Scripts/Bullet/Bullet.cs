using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletTimer;
    [SerializeField] private float bulletLifeTime;
    [SerializeField] private int bulletSpeed;
    [SerializeField] private Rigidbody rb;

    private void Awake()
    {
        bulletTimer = 0;
        this.gameObject.SetActive(false);
    }

    private void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * bulletSpeed * Time.fixedDeltaTime));
    }

    private void Timer() 
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= bulletLifeTime) 
        {
            ResetLifeTime();
            this.gameObject.SetActive(false);
        }
    }

    public void SetPosition(Vector3 _newPosition)
    {
        this.gameObject.transform.position = _newPosition;
    }

    public void SetRotation(Quaternion _newRotation) 
    {
        this.gameObject.transform.rotation = _newRotation;
    }

    public void ResetLifeTime() 
    {
        bulletTimer = 0;
    }

    public Vector3 GetPosition()
    {
        return rb.position;
    }

    private void Update()
    {
        if (!PauseManager.instance.GetPaused())
            Timer();
    }

    private void FixedUpdate()
    {
        if (!PauseManager.instance.GetPaused() && !GameOverManager.instance.GameOver())
            Move();
    }
}

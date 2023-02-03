using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private BulletSO bulletSO;

    float speed = 10f;
    float damage = 1f;
    float lifetime = 1f;
    float timer = 0f;

    public void Awake()
    {
        if (bulletSO == null)
        {
            Debug.LogError("Bullet missing BulletSO, add missing Scriptable Object!");
            this.enabled = false;
            return;
        }

        speed = bulletSO.speed;
        damage = bulletSO.damage;
        lifetime = bulletSO.lifetime;
        if (bulletSO.destroyWhenOutOfBounds)
        {
            ScreenWrapper screenWrapper = GetComponent<ScreenWrapper>();
            if (screenWrapper == null)
            {
                Debug.LogWarning("Bullet doesn't have a ScreenWrapper and doesn't know when it's out of bounds!");
            }
            else
            {
                screenWrapper.destroyWhenOutsideOfBounds = true;
            }
        }
    }
    public void AddSpeed(float boost)
    {
        speed += boost;
        if (speed <= 1f) speed = 1f;
    }

    public void AddSpeed(Vector2 boostVector)
    {
        //Debug.Log(boostVector.magnitude);
        // ignore boost if it's too small
        if (boostVector.magnitude < 0.01f)
            return;
        float boost = boostVector.magnitude * (Vector2.Dot(transform.up, boostVector.normalized));
        speed += boost;
        if (speed <= 1f) speed = 1f;
    }


    void FixedUpdate()
    {
        bulletSO.PhysicsTick(gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;
        bulletSO.Tick(gameObject);
        if (timer > lifetime)
            bulletSO.DestroyBullet(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        IAmDamageable damageHandler = collision.gameObject.GetComponent<IAmDamageable>();
        if (damageHandler == null) return;

        damageHandler.TakeDamage(damage);
        bulletSO.DestroyBullet(gameObject);
    }

}

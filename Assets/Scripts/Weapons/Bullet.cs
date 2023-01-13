using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float damage = 1f;

    readonly float lifetime = 1f;
    float timer = 0f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
    }

    public void AddSpeed(float boost)
    {
        speed += boost;
        if (speed <= 1f) speed = 1f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifetime)
            OnBulletDestroyed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        IAmDamageable damageHandler = collision.gameObject.GetComponent<IAmDamageable>();
        if (damageHandler == null) return;

        damageHandler.TakeDamage(damage);
        OnBulletDestroyed();
    }

    private void OnBulletDestroyed()
    {
        Destroy(gameObject);
    }
}

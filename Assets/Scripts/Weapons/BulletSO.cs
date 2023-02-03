using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Bullets/BulletSO")]
public class BulletSO : ScriptableObject
{
    [field: SerializeField]
    public float speed { get; private set; } = 10f;

    [field: SerializeField]
    public float damage { get; private set; } = 1f;

    [field: SerializeField]
    public float lifetime { get; private set; } = 2f;

    [field: SerializeField]
    public bool destroyWhenOutOfBounds { get; private set; } = false;

    public void Tick(GameObject gameObject)
    {

    }

    public void PhysicsTick(GameObject gameObject)
    {
        gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
    }

    public void DestroyBullet(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private BulletPool pool;
    [SerializeField] private float bulletsp;
    private float bulletlifetime = 5f;

    
    private void OnEnable()
    {
        Invoke(nameof(ReturnPool), bulletlifetime);
    }
    public void Init(BulletPool p)
    {
        pool = p;
    }

    private void ReturnPool()
    {
        pool.pool.Release(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(bulletsp*Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ReturnPool();
        }
    }
}

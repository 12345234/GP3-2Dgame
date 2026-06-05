using UnityEngine;

public class Enemy : Charactor
{
    [SerializeField] GameObject[] enemy;

    private void OnDestroy()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            base.Die();
        }
    }
}

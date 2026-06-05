using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int sponetime;
    [SerializeField] GameObject[] enemy;

    public void SponeEnemy()
    {
        //int i = Random.Range(0, enemy.Length);
        this.gameObject.SetActive(true);
    }
    private void OnDestroy()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            this.gameObject.SetActive(false);
            Invoke(nameof(SponeEnemy), sponetime);
        }
    }
}

using UnityEngine;

public class Charactor : MonoBehaviour
{
    [SerializeField]protected float sp;//ˆÚ“®‘¬“x
    [SerializeField] protected int maxhp;//Å‘å‘Ì—Í

    [SerializeField] protected int currenthp;//Œ»İ‚Ì‘Ì—Í

    [SerializeField] float jp;

    Rigidbody2D rb;

    protected virtual void Awake()
    {
        currenthp = maxhp;
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Move(Vector2 pos)
    {
        transform.position += new Vector3(pos.x * sp, 0.0f, 0.0f);
    }

    protected virtual void TakeDamage(int damage)
    { 
        currenthp -= damage;

        if(currenthp <= 0)
        {
            Die();
        }
    }

    protected virtual void Jump()
    {
        rb.AddForce(Vector3.up*jp,ForceMode2D.Impulse);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}

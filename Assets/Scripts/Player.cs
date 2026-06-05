using UnityEngine;
using UnityEngine.InputSystem;

public class Player :Charactor
{
    Vector2 vec2;
    public LayerMask Ground;
    RaycastHit2D hit;
    Vector3 boxSize = new Vector3(1, 1, 1);
    protected override void Awake()
    {
        base.Awake();
    }

    public void OnMove(InputValue inputValue)
    {
        vec2 = inputValue.Get<Vector2>();
        
    }
    
    public void OnAttack(InputValue value)
    {
        if(value.isPressed)
        {
            SpawnBullet();
        }
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && JumpControl())
        {
            base.Jump();
        }
    }
    private void FixedUpdate()
    {
        base.Move(vec2);
    }

    protected override void Die()
    {
        base.Die();
    }
    private bool JumpControl()
    {
        hit = Physics2D.BoxCast(transform.position,boxSize,0f,Vector2.down,0.2f,Ground);
        return hit.collider != null;
    }

    [SerializeField] private BulletPool _bulletpool;
    [SerializeField] private float time;
    [SerializeField] int visible;

    [SerializeField] Transform enemy;
    void SpawnBullet()
    {
        GameObject obj = _bulletpool.pool.Get();
        obj.transform.position = this.gameObject.transform.position;



        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.Init(_bulletpool);

    }
}

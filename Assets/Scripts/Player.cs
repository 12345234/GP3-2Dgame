using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player :Charactor
{
    
    public LayerMask Ground;
    RaycastHit2D hit;
   [SerializeField] Vector2 boxSize = new Vector3(1, 1);

    PlayerInput playerInput;

    [SerializeField]int havebullet;
    int maxbullet;

    [SerializeField] private TextMeshProUGUI bullettext;

    [SerializeField] Vector3 bulletpos;

    protected override void Awake()
    {
        base.Awake();
        playerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        maxbullet = havebullet;
        bullettext.text = $"{havebullet}/{maxbullet}";
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 vec2 = playerInput.actions["Move"].ReadValue<Vector2>();
        if(vec2.x!=0f)
        {
            base.Move(vec2);

            var localscale = transform.localScale;

            if(vec2.x<0)
            {
                localscale.x = -1f;
            }
            else
            {
                localscale.x = 1f;
            }
            transform.localScale = localscale;
        }

        if (playerInput.actions["Attack"].WasPressedThisFrame()&&havebullet>0)
        {
            SpawnBullet();
            havebullet--;

            bullettext.text = $"{havebullet}/{maxbullet}";

        }
        if (playerInput.actions["Reload"].WasPressedThisFrame())
        {
            havebullet = maxbullet;
            bullettext.text = $"{havebullet}/{maxbullet}";
        }

        if (playerInput.actions["Jump"].WasPressedThisFrame() && JumpControl())
        {
            base.Jump();
        }
    }

    protected override void Die()
    {
        base.Die();
    }
    private bool JumpControl()
    {
        hit = Physics2D.BoxCast(transform.position,boxSize,0f,Vector2.down,0.5f,Ground);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, boxSize);

        Vector3 endPos = transform.position + Vector3.down * 0.5f;

        Gizmos.DrawWireCube(endPos, boxSize);

        Gizmos.DrawLine(transform.position, endPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("flag")&& GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            SceneManager.LoadScene(1);
        }
    }


    [SerializeField] private BulletPool _bulletpool;
    [SerializeField] private float time;
    [SerializeField] int visible;

    [SerializeField] Transform enemy;
    void SpawnBullet()
    {
        GameObject obj = _bulletpool.pool.Get();
        obj.transform.position = this.gameObject.transform.position + bulletpos;

        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.Init(_bulletpool);
    }
}

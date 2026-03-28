using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected Entity_FVX entityVfx;
    [SerializeField] protected AudioSource destroySound;
    [SerializeField] protected ObjectPooler destroyEffectPool;

    [SerializeField] protected int maxHp;
    [SerializeField] protected int hp;
    

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        entityVfx = GetComponent<Entity_FVX>();
        hp = maxHp;
    }

    protected virtual void Start()
    {
        
    }


    protected virtual void Update()
    {
        
    }

    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        //AudioManager.Instance.PlaySound(hitSound);
        if (hp > 0)
        {
            entityVfx.PlayOnDamageVfx();
        } else
        {
            //AudioManager.Instance.PlaySound(destroySound);
            GameObject destroyEffect = destroyEffectPool.GetPooledObject();
            destroyEffect.transform.position = transform.position;
            destroyEffect.transform.rotation = transform.rotation;
            destroyEffect.SetActive(true);
            Destroy(gameObject);
        }
    }
}

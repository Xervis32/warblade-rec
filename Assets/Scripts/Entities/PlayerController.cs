using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Entity
{
    public static PlayerController Instance;

    private Animator anim;
    [SerializeField] private PLayerBulletsPool bulletPool;

    [Header("Stats")]
    [SerializeField] private float moveSpeed;
    [SerializeField] public int bullets;
    [SerializeField] public float bulletSpeed;

    private Vector2 moveInput;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
     
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    protected override void Start()
    {

    }

    protected override void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //AudioManager.Instance.PlaySound(AudioManager.Instance.shoot);
        if (bulletPool.GetPooledObject() != null)
        {
            GameObject bullet = bulletPool.GetPooledObject();
            bullet.transform.position = new Vector2(transform.position.x, -4);
            bullet.SetActive(true);
        }
    }
}
using UnityEngine;

public class SingleShot : MonoBehaviour
{
    PlayerController player;

    [SerializeField] private int damage;

    void Start()
    {
        player = PlayerController.Instance;
    }

    void Update()
    {
        transform.position += new Vector3(0f, player.bulletSpeed * Time.deltaTime);
        if (transform.position.y > 5.5f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy) enemy.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}

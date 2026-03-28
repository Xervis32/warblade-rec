using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    void Update()
    {
        transform.position += new Vector3(0f, -3f * Time.deltaTime);
        if (transform.position.y < -5.5f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player) player.TakeDamage(1);
            gameObject.SetActive(false);
        }
    }
}

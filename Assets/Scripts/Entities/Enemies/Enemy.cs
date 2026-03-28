using UnityEngine;

public class Enemy : Entity
{

    [SerializeField] private ObjectPooler bulletPool;

    private float shootInterval = 2f;
    private float shootTimer;

    protected override void Update()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        else
        {
            Shoot();

        }
    }

    private void Shoot()
    {
        //AudioManager.Instance.PlaySound(AudioManager.Instance.shoot);
        GameObject bullet = bulletPool.GetPooledObject();
        bullet.transform.position = new Vector2(transform.position.x, transform.position.y -0.5f);
        bullet.SetActive(true);
        shootInterval = Random.Range(0.3f, 2f);
        shootTimer = shootInterval;
    }
}

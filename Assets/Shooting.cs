using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    // public float bulletSpeed = 5f;
    
    private float nextFireTime = 0f;

    void Start()
    {
        nextFireTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();
        // if (bulletMovement == null)
        // {
        //     bulletMovement = bullet.AddComponent<BulletMovement>();
        // }
        // bulletMovement.speed = bulletSpeed;
        // bulletMovement.direction = Vector2.right; // Change this if you need different directions
    }
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [Header("Settings")]
    public Collider2D ignoredCollider;  // Assign the PLAYER'S Collider2D here

    private Collider2D bulletCollider;
    public GameObject blood;

    void Start()
    {
        bulletCollider = GetComponent<Collider2D>();
        if (ignoredCollider != null)
        {
            Physics2D.IgnoreCollision(bulletCollider, ignoredCollider, true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet hit: " + collision.gameObject.name);
        if (ignoredCollider != null)
        {   
            Instantiate(blood, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(bulletCollider, ignoredCollider, false);
        }

    }
}
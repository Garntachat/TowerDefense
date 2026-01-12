using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 direction = Vector2.right;
    public float lifetime = 7f; // Time before bullet is automatically destroyed
    public bool melee = false;
    private void Start()
    {
        // Destroy the bullet after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bullet in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Optional: Add collision detection
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Add your collision logic here
        // For example:
        if (!other.CompareTag("pikachu")) // Don't destroy when hitting player
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && melee == false)
        {
            Debug.Log("bullet hit enemy: " + collision.gameObject.name);
            Destroy(gameObject); // Or other logic (e.g., take damage)
        }
    }
}
using UnityEngine;
using System.Collections;

public class enemymovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float knockbackSpeed = 2f;  // How fast to knockback right
    public float knockbackDuration = 0.2f;  // How long knockback lasts
    
    private Rigidbody2D rb;
    private bool isKnockedBack = false;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    
    // Ignore collisions with other enemies
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
    foreach (GameObject enemy in enemies)
    {
        if (enemy != gameObject) // Don't ignore collision with self
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
        }
    }
}

    void Update()
    {
        if (!isKnockedBack)
        {
            // Normal left movement (negative right)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        
        if (collision.gameObject.CompareTag("pikachu") && !isKnockedBack)
        {
            StartCoroutine(KnockbackRight());
        }
    }

    IEnumerator KnockbackRight()
    {
        isKnockedBack = true;
        rb.velocity = Vector2.right * knockbackSpeed;  // Push right
        
        yield return new WaitForSeconds(knockbackDuration);
        
        rb.velocity = Vector2.zero;  // Stop knockback
        isKnockedBack = false;
    }
}
using UnityEngine;
using System.Collections;

public class EnemyKnockback : MonoBehaviour
{
    [Header("Pause Settings")]
    public float pauseDuration = 0.5f; // How long to pause (seconds)
    public bool disableMovementScript = true; // Whether to disable movement script during pause

    private Rigidbody2D rb;
    private enemymovement movementScript; // Reference to your movement script
    private Vector2 prePauseVelocity; // Stores velocity before pausing

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementScript = GetComponent<enemymovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PauseAndResume());
        }
    }

    private IEnumerator PauseAndResume()
    {
        // Store current movement state
        prePauseVelocity = rb.linearVelocity;
        
        // Stop the zombie
        rb.linearVelocity = Vector2.zero;
        if (disableMovementScript && movementScript != null)
        {
            movementScript.enabled = false;
        }

        // Wait for pause duration
        yield return new WaitForSeconds(pauseDuration);

        // Resume movement
        rb.linearVelocity = prePauseVelocity;
        if (disableMovementScript && movementScript != null)
        {
            movementScript.enabled = true;
        }
    }
}
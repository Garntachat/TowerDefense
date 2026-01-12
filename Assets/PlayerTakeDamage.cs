using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{   
    public PlayerHealth p;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            TakeDamage(1);
        }
    }
    void TakeDamage(int damage)
    {
        p.currentHealth -= damage;
        p.SetHealth(p.currentHealth);

    }
}

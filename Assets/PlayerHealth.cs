using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public Healthbar healthbar;
    public int currentHealth;
    //public float RegenRate = 1f;
    
   // private float nextRegenTime = 0f;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }


    public int GetHealth()
    {
        return currentHealth;
    }       

    public void SetHealth(int i)
    {
        healthbar.SetHealth(i);
    }
    
    //     void Update()
    // {
    //     if (Time.time >= nextRegenTime)
    //     {
    //         Regen();
    //         nextRegenTime = Time.time + RegenRate;
    //     }
    // }

    // void Regen()
    // {           
    //     if (currentHealth < 10){
    //         currentHealth += 1;
    //     }
    //     SetHealth(currentHealth);

    // }
}
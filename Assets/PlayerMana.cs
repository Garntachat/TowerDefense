using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int maxHealth = 10;
    public Healthbar healthbar;
    public int currentMana;
    public float RegenRate = 1f;
    
    private float nextRegenTime = 0f;
    void Start()
    {
        currentMana = 0;
        healthbar.SetMaxHealth(maxHealth);
    }


    public int GetHealth()
    {
        return currentMana;
    }       

    public void SetHealth(int i)
    {
        healthbar.SetHealth(i);
    }

    void Update()
    {
        if (Time.time >= nextRegenTime)
        {
            Regen();
            nextRegenTime = Time.time + RegenRate;
        }
    }

    void Regen()
    {           
        if (currentMana < 10){
            currentMana += 1;
        }
        SetHealth(currentMana);

    }
    

}
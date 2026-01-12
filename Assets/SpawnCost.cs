using UnityEngine;

public class SpawnCost : MonoBehaviour
{
    public int ManaRequired = 1;
    private PlayerMana playerMana; 

    void Start()
    {
        // Automatically find the PlayerMana component
        playerMana = FindObjectOfType<PlayerMana>();
        if (playerMana == null)
        {
            Debug.LogError("PlayerMana component not found in scene!");
        }
        PayCost(1);
    }
    void PayCost(int cost)
    {
        playerMana.currentMana -= cost;
        playerMana.SetHealth(playerMana.currentMana); 
    }
}

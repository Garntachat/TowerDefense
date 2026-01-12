using UnityEngine;

public class Evolution : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int ManaRequired = 1;
    private PlayerMana playerMana; // Changed from public to private

    void Start()
    {
        // Automatically find the PlayerMana component
        playerMana = FindObjectOfType<PlayerMana>();
        if (playerMana == null)
        {
            Debug.LogError("PlayerMana component not found in scene!");
        }
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && playerMana != null)
            {
                if (playerMana.currentMana >= ManaRequired) // Check mana first
                {
                    Vector2 spawnPosition = hit.collider.transform.position;
                    Destroy(hit.collider.gameObject);

                    if (objectToSpawn != null)
                    {
                        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                        PayCost(ManaRequired);
                    }
                    else
                    {
                        Debug.LogWarning("No object to spawn assigned!");
                    }
                }
                else
                {
                    Debug.Log("Not enough mana!");
                }
            }
        }
    }

    void PayCost(int cost)
    {
        playerMana.currentMana -= cost;
        playerMana.SetHealth(playerMana.currentMana); // Make sure this matches your PlayerMana script
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class spawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 2f;
    private int amountspawn= 0;

    public GameObject wave;

    void Start()
    {
        StartCoroutine(SpawnZombies());
    }
    void Update(){

        if (amountspawn > 10){
            spawnRate  = 1;
            Debug.Log("wave2");
            wave.GetComponent<Text>().text = "Wave 2";

        }
    }

    IEnumerator SpawnZombies()
    {
        while (true)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject newZombie = Instantiate(zombiePrefab, randomPoint.position, Quaternion.identity);
            amountspawn +=1;
            
            // Ensure components exist (critical for collisions)
            ValidateZombieComponents(newZombie);
            
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void ValidateZombieComponents(GameObject zombie)
    {
        // Add Rigidbody2D if missing
        if (!zombie.GetComponent<Rigidbody2D>())
        {
            Rigidbody2D rb = zombie.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0; // Disable gravity for top-down
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // Prevent phasing
            rb.freezeRotation = true; // Stop zombie rotation
        }

        // Add BoxCollider2D if missing
        if (!zombie.GetComponent<BoxCollider2D>())
        {
            BoxCollider2D col = zombie.AddComponent<BoxCollider2D>();
            col.size = new Vector2(1f, 1f); // Adjust to match sprite size
        }
    }
}
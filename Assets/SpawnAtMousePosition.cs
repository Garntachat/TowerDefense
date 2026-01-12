using UnityEngine;

public class SpawnAtMousePosition : MonoBehaviour
{

    public int ManaRequired;
    public PlayerMana p;
    private GameObject targetObject; // Assign the specific GameObject you want to spawn at in the inspector
    public SelectUnit select;
    public GameObject[] spawnPoints;
    public bool[] availableCardSlots;
   
    void Update()
    {   
        targetObject = select.GetUnit();
        if (Input.GetMouseButtonDown(1) && p.GetHealth() != 0) // Left mouse button click
        {
            SpawnAtNearestSpawnPointToMouse();
            //SpawnPrefabAtTargetPosition();

        }
    }
    void paycost(int damage)
    {
        p.currentMana -= damage;
        p.SetHealth(p.currentMana);
    }


    void SpawnAtNearestSpawnPointToMouse()
{
    if (spawnPoints.Length > 0)
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        GameObject nearestSpawnPoint = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject spawnPoint in spawnPoints)
        {
            float distance = Vector3.Distance(spawnPoint.transform.position, mouseWorldPos);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestSpawnPoint = spawnPoint;
            }
        }
        int index = System.Array.IndexOf(spawnPoints, nearestSpawnPoint);

        Debug.Log("The index of the target object is: " + index);
        if (nearestSpawnPoint != null && availableCardSlots[index])
        {
            Vector3 spawnPosition = nearestSpawnPoint.transform.position;
            spawnPosition.z = 0;
            availableCardSlots[index] = false;
            Instantiate(targetObject, spawnPosition, Quaternion.identity);
        }
    }
    else
    {
        Debug.LogWarning("No spawn points assigned!");
    }
}
    void SpawnPrefabAtTargetPosition()
    {
        if (targetObject != null)
        {
            // Get the center position of the target object
            Vector3 spawnPosition = targetObject.transform.position;
            spawnPosition.z = 0; // Ensure z-position is 0 for 2D

            // Instantiate the prefab
            Instantiate(targetObject, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Target object not assigned for spawning!");
        }
    }
}
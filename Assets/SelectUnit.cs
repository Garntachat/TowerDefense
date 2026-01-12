using UnityEngine;
using UnityEngine.UI;

public class SelectUnit : MonoBehaviour
{   
    public int type = 1;
    public GameObject prefabToSpawn;
    public GameObject prefabToSpawn2; // Assign your 2D prefab in the inspector
    private GameObject spawn;
    public Text chosen;
    void Start()
    {
        spawn = prefabToSpawn;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            type = 1;
            Debug.Log(type);
            spawn = prefabToSpawn;
            chosen.text = "Selected: Pikachu";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            type = 2;
            Debug.Log(type);
            spawn = prefabToSpawn2;
            chosen.text = "Selected: Bulbasuar";
        }      
    }
    public GameObject GetUnit(){

        return spawn;
     
        
    }
}

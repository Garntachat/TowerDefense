using UnityEngine;

public class lifetime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

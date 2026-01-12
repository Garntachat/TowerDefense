using UnityEngine;

public class Takedamage : MonoBehaviour
{   
    public float hp = 3f;
    private float taken = 0f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(taken == hp){
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            taken+=1;
        }
    }
}

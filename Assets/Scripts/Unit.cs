using UnityEngine;

public class Unit : MonoBehaviour
{

    public int Health;
    public int attackDamage;
    
    public Sprite selectedSprite;
    public Sprite originalSprite; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}

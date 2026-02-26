using UnityEngine;

public class SizeCheck : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        Debug.Log(bc.name + " " + bc.size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
     

    // Called when a collider enters the trigger zone of the GameObject
    void OnTriggerEnter2D(Collider2D other)
    {
        
                
            Destroy(gameObject);

            Destroy(other.gameObject);

        
    }
}

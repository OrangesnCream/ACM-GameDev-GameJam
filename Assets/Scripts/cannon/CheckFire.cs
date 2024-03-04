using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other){
    // Check if the collided object is fire
        if (other.CompareTag("Fire")){
            // If it is fire, extinguish the fire
            Fire fire = other.GetComponent<Fire>();
            if (fire != null){
                fire.Extinguish(); 
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeControll : MonoBehaviour
{
    private ParticleSystem ps;
     private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        lifetimeToMouse();
    }
    //makes it so water splashes where it is aimed 
    public void lifetimeToMouse(){
        Vector2 mousePos= cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition =transform.position;
        float distance = Vector2.Distance(playerPosition,mousePos);
        float lifetime = distance * 0.055f; 
        var main=ps.main;
        main.startLifetime = lifetime;
    }
}

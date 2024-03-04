using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : MonoBehaviour
{   
    private Camera cam;
    private Vector3 mousePos;
   
    public Transform firePoint;
    public bool canFire = true;
    private PlayerController pc;
    private ParticleSystem partSys;


    void Start()
    {
        partSys=firePoint.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        pc = transform.parent.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        //flips gun
        /* got annoying so I turned it off  
        if(mousePos.x > transform.position.x){
            firePoint.localScale = new Vector3(1f, 1f, 1f);
        } else {
            firePoint.localScale = new Vector3(1f, -1f, 1f);
        }
        */

        if(Input.GetMouseButton(0)){
            partSys.enableEmission=true;
        }else{
            partSys.enableEmission=false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fire : MonoBehaviour
{
    private Vector3Int position;
    private TileData data;
    private FireManager fireManager;

    private float burnTimeCounter,spreadIntervallCounter;
    private float burnEnd=0; //
    private bool isBeingExtinguished=false;//if it is then call FireExtinguished()
    private float totalBurnTime;
    private void Start(){
        totalBurnTime=data.burnTime;
    }
     public void StartBurning(Vector3Int position,TileData data, FireManager fm){
        this.position=position;
        this.data=data;
        fireManager=fm;
        burnTimeCounter=data.burnTime;
        spreadIntervallCounter=data.spreadIntervall;
    }
      private void Update(){
        burnTimeCounter -= Time.deltaTime;
        if(burnTimeCounter<=burnEnd)
        {   if(isBeingExtinguished){
            fireManager.FireExtinguished(position);
            }else{
            fireManager.FinishedBurning(position);
            }
            Destroy(gameObject);
        }

        spreadIntervallCounter -= Time.deltaTime;
        if(spreadIntervallCounter <=0)//raise this when extinguishing the flame
        {
            spreadIntervallCounter = data.spreadIntervall;
            fireManager.TryToSpread(position, data.spreadChance);
        }
        isBeingExtinguished=false;
    }
    public void Extinguish(){
        burnEnd+=.03f*totalBurnTime;
        spreadIntervallCounter+=Time.deltaTime;
       isBeingExtinguished=true;
    }



}

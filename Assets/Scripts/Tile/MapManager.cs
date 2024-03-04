using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;
    [SerializeField]
    private List<TileData> tileDatas;
    private Dictionary<TileBase,TileData> dataFromTiles;
    // Start is called before the first frame update
    private void Awake(){
        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach(var tileData in tileDatas){
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile,tileData);
            }
        }
    } 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition= map.WorldToCell(mousePosition);
            TileBase clickedTile=map.GetTile(gridPosition);
            float walkingSpeed=dataFromTiles[clickedTile].walkingSpeed;
            //print("walking speed on "+clickedTile+" is "+walkingSpeed);
        
        }
    
    }
    public TileData GetTileData(Vector3Int tilePosition){
        TileBase tile = map.GetTile(tilePosition);

        if (tile == null)
            return null;
        else
            return dataFromTiles[tile];


    }

}

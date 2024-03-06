using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class TileCounter : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileBase> targetTile;

    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    int totalCount;
    void Start(){
        totalCount=CountTiles();
    }
    void Update()
    {
        int tileCount = CountTiles();
        float percentage= ((float)tileCount/(float)totalCount)*100;
        textMeshPro.text = "Bushes: " + ((int)percentage).ToString()+"%";
    }

    private int CountTiles()
    {
        int count = 0;
        foreach (Vector3Int pos in map.cellBounds.allPositionsWithin)
        {
            foreach(var tile in targetTile){
                if (map.GetTile(pos) == tile)
                {
                    count++;
                }
            }
        }
        return count;
    }
}

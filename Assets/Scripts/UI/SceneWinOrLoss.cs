using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class SceneWinOrLoss : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileBase> targetTile;
    int totalCount;
     [SerializeField]
    private FireManager fireManager;
    void Start(){
        totalCount=CountTiles();
    }
    void Update()
    {
        int tileCount = CountTiles();
        float percentage= ((float)tileCount/(float)totalCount)*100;
        if(percentage<60){
            SceneManager.LoadScene("DefeatScene");
        }
        if(fireManager.ActiveFiresCount==0){
            SceneManager.LoadScene("WinScene");
        }
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

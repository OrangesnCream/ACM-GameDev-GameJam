using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
public class FireCount : MonoBehaviour
{
     [SerializeField]
    private FireManager fireManager;

    [SerializeField]
    private TextMeshProUGUI textMeshPro;


    void Update()
    {
        textMeshPro.text = "Active Fires: " + fireManager.ActiveFiresCount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    //각 칸의 인덱스포함, 해당 칸에 도착하면 발생할 메서드 

    public int index;

    public void TileEvent()
    {
        Debug.Log($"Index of his tile : {index}");
    }
}

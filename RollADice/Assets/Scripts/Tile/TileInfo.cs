using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    //�� ĭ�� �ε�������, �ش� ĭ�� �����ϸ� �߻��� �޼��� 

    public int index;

    public void TileEvent()
    {
        Debug.Log($"Index of his tile : {index}");
    }
}

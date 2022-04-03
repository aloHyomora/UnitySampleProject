using System;
using UnityEngine;
using UnityEngine.UI;

public class TileInfo_Star : TileInfo
{
    private int _starValue;
    public int starValue
    {
        set
        {
            _starValue = value;
            starValueText.text = _starValue.ToString();
        }
        get
        {
            return _starValue;
        }
    }
    public Text starValueText;
    public int starValueInit = 3; // 각 타일의 샛별점수 기본 3점 제공

    private void Awake()
    {
        starValue = starValueInit;
    }

    public override void TileEvent()
    {
        Debug.Log($"index of this tile : {index} , Increase star value + 1 ");
        starValue++;
    }
}


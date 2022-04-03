
using System.Collections.Generic;  // 리스트 사용
using UnityEngine;
using UnityEngine.UI;

public class DicePlayManager : MonoBehaviour
{
    private int currentTileIndex; //현재 플레이어의 타일 번호        
    private int _diceNum;
    public int diceNum     //주사위 개수
    {
        set
        {
            if(value > 0)
            {
                _diceNum = value;
                diceText.text = _diceNum.ToString();
            }
        }
        get
        {
            return _diceNum;
        }
    }
    public Text diceText;
    public int diceNumInit; //초기 주사위 번호
    private int _goldendiceNum;
    public int goldenDiceNum
    {
        set
        {
            if(value > 0)
            {
                _goldendiceNum = value;
                goldendiceText.text = _goldendiceNum.ToString();
            }
        }
        get 
        {
            return _goldendiceNum;
        }

    }
    public Text goldendiceText;
    public int goldendiceNumInit;
    private int _starScore;
    public int starScore //샛별점수 
    {
        set
        {
            if(starScore > 0)
            {
                _starScore = value;
                starscoreText.text = _starScore.ToString();
            }
        }
        get
        {
            return starScore;
        }
    }
    public Text starscoreText;
    public List<Transform> mapTiles;
    // ㅋ ㅋ ㅋ 
    private void Awake()
    {
        diceNum = diceNumInit;
        goldenDiceNum = goldendiceNumInit; 
    }

    // 버튼누르면 주사위 굴리고 그 눈금만큼 플레이어 이동 
    public void RollADice()
    {
        if (diceNum < 1) return;

        diceNum--;
        int diceValue = Random.Range(1, 7);
        MovePlayer(diceValue);
    }
    private void MovePlayer(int diceValue)
    {
        //
        int previousTileIndex = currentTileIndex;
        currentTileIndex += diceValue;
        if(currentTileIndex >= mapTiles.Count)
            currentTileIndex -= mapTiles.Count;


        Player.instance.Move(GetTilePosition(currentTileIndex));
    }
    private Vector3 GetTilePosition(int tileindex) //타일위치받아오기
    {
        return mapTiles[tileindex].position;
    }
}



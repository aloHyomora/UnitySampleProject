using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    static public GamePlay instance;
    private void Awake()
    {
        instance = this;
    }

    //public 이던지 seenewadlgize이던지 hierachy창에 있으면 public 쓸래 걍~
    public List<GameObject> players = new List<GameObject>(); //플레이어 리스트
    private List<Transform> finishedPlayers = new List<Transform>();  //등수 리스트 등수를 만들어 단상에 올리기 위함 position만 필요 , 플레이어move에 대한 정보 필요없음 
    public List<Transform> platforms = new List<Transform> ();

    private int totalPlayers;
    private float playerStartZPos;
    public Transform goal;
    //C#과 다르게 인스턴스화 하지 않고 인스펙터창에서 가능. 이미 게임오브젝트로 존재하기 때문에
    public bool onPlay = false; //static 해당클래스에 자유롭게 접근 가능!


    private void Start()
    {
        totalPlayers= players.Count;
    }
    // Update is called once per frame
    void Update()
    {
        if (onPlay)
        {
            CheckPlayerReachedToGoalAndStopMove();
            CheckGameIsFinished();
        }
    }
    void CheckPlayerReachedToGoalAndStopMove() //골라인 도착하면 움직임 멈추는 함수 
    {
        for (int i = players.Count-1; i >= 0; i--)
        {
            MovePlayer moveplayer = players[i].GetComponent<MovePlayer>();
            if (moveplayer.distance > goal.position.z-playerStartZPos)   //for문돌리면서 player리스트 빼면서 등수 리스트에 저장
            {
                moveplayer.doMove = false;                
                finishedPlayers.Add(players[i].transform); //players는 GameObject타입이라 Transform타입인 finishedPlayers에 추가할 수 없다. .transform으로 뭘 바꿔준거?                
                players.Remove(players[i]);   //players.Count 줄어든다. for문 일찍 종료됨. 에러 ->for문을 반대로 돌린다. (int i=0 ; i< players.Count; i++) 에서 바꿈.
            }
        }
    }
    void CheckGameIsFinished()
    {
        if(finishedPlayers.Count >= totalPlayers)
        {
            onPlay = false; //게임끝나면 단상올리기~
            for (int i = 0; i < platforms.Count; i++)
            {
                finishedPlayers[i].position = platforms[i].Find("playpoint").position +
                                                        new Vector3(0,finishedPlayers[i].lossyScale.y,0);
            }
        }
    }
    public void PlayGame()
    {
        onPlay = true;  //각 플레이어들에게 doMove를 true로 만들어 줄거다. MovePlayer의 컴포넌트를 가져와야 한다.  
                        //GamePlay클래스에서 players 리스트에 GameObject로 각 플레이어를 가져왔다. MovePlayer의 domove를 true로 바꾼다.
        playerStartZPos = players[0].transform.position.z;
        foreach (var sub in players) //item은 gameobject이다. 
        {
            MovePlayer moveplayer = sub.GetComponent<MovePlayer>();
            if (moveplayer != null)
                moveplayer.doMove = true;
        }
    }
}

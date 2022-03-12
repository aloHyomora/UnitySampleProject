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

    //public �̴��� seenewadlgize�̴��� hierachyâ�� ������ public ���� ��~
    public List<GameObject> players = new List<GameObject>(); //�÷��̾� ����Ʈ
    private List<Transform> finishedPlayers = new List<Transform>();  //��� ����Ʈ ����� ����� �ܻ� �ø��� ���� position�� �ʿ� , �÷��̾�move�� ���� ���� �ʿ���� 
    public List<Transform> platforms = new List<Transform> ();

    private int totalPlayers;
    private float playerStartZPos;
    public Transform goal;
    //C#�� �ٸ��� �ν��Ͻ�ȭ ���� �ʰ� �ν�����â���� ����. �̹� ���ӿ�����Ʈ�� �����ϱ� ������
    public bool onPlay = false; //static �ش�Ŭ������ �����Ӱ� ���� ����!


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
    void CheckPlayerReachedToGoalAndStopMove() //����� �����ϸ� ������ ���ߴ� �Լ� 
    {
        for (int i = players.Count-1; i >= 0; i--)
        {
            MovePlayer moveplayer = players[i].GetComponent<MovePlayer>();
            if (moveplayer.distance > goal.position.z-playerStartZPos)   //for�������鼭 player����Ʈ ���鼭 ��� ����Ʈ�� ����
            {
                moveplayer.doMove = false;                
                finishedPlayers.Add(players[i].transform); //players�� GameObjectŸ���̶� TransformŸ���� finishedPlayers�� �߰��� �� ����. .transform���� �� �ٲ��ذ�?                
                players.Remove(players[i]);   //players.Count �پ���. for�� ���� �����. ���� ->for���� �ݴ�� ������. (int i=0 ; i< players.Count; i++) ���� �ٲ�.
            }
        }
    }
    void CheckGameIsFinished()
    {
        if(finishedPlayers.Count >= totalPlayers)
        {
            onPlay = false; //���ӳ����� �ܻ�ø���~
            for (int i = 0; i < platforms.Count; i++)
            {
                finishedPlayers[i].position = platforms[i].Find("playpoint").position +
                                                        new Vector3(0,finishedPlayers[i].lossyScale.y,0);
            }
        }
    }
    public void PlayGame()
    {
        onPlay = true;  //�� �÷��̾�鿡�� doMove�� true�� ����� �ٰŴ�. MovePlayer�� ������Ʈ�� �����;� �Ѵ�.  
                        //GamePlayŬ�������� players ����Ʈ�� GameObject�� �� �÷��̾ �����Դ�. MovePlayer�� domove�� true�� �ٲ۴�.
        playerStartZPos = players[0].transform.position.z;
        foreach (var sub in players) //item�� gameobject�̴�. 
        {
            MovePlayer moveplayer = sub.GetComponent<MovePlayer>();
            if (moveplayer != null)
                moveplayer.doMove = true;
        }
    }
}

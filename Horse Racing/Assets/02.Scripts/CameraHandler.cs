using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Transform tr;
    private List<Transform> players = new List<Transform>();
    private int targetIndex = 0;
    public Vector3 offset = new Vector3(0, 2, -4);  //카메라 위치 조정 

    private void Awake() //카메라 위치받아옴.
    {
        tr = transform; 
    }
    private void Start()
    {
        foreach (var item in GamePlay.instance.players)
        {
            players.Add(item.transform); //게임플레이어가 가지고있는 객체에서 Gameplay에 접근해서 transform위치를 가져옴.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlay.instance.onPlay)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SwitchTarget();
            }
        }
    }
    private void FixedUpdate()
    {
        FollowTarget();
    }
    private void SwitchTarget() //GamePlay 인스턴스에서 게임목록을 받아올수있다.
    {
        targetIndex++;
        if (targetIndex > players.Count - 1)
            targetIndex = 0;
    }

    private void FollowTarget()
    {
        tr.position = players[targetIndex].position+offset;
    }
}

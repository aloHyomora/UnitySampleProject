using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Transform tr;
    private List<Transform> players = new List<Transform>();
    private int targetIndex = 0;
    public Vector3 offset = new Vector3(0, 2, -4);  //ī�޶� ��ġ ���� 

    private void Awake() //ī�޶� ��ġ�޾ƿ�.
    {
        tr = transform; 
    }
    private void Start()
    {
        foreach (var item in GamePlay.instance.players)
        {
            players.Add(item.transform); //�����÷��̾ �������ִ� ��ü���� Gameplay�� �����ؼ� transform��ġ�� ������.
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
    private void SwitchTarget() //GamePlay �ν��Ͻ����� ���Ӹ���� �޾ƿü��ִ�.
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

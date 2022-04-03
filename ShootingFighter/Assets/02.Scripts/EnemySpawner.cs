using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //enemy원본필요
    public GameObject enemyPrefab;
    public Vector3 rangeCenter; //스폰영역 중간
    public Vector3 rangeSize;   //스폰영역 크기

    public float spawnTimeGap = 0.3f;
    private float spawnTimer;

    private void Update()
    {
        Vector3 spawnPos = new Vector3(rangeCenter.x + Random.Range(-rangeSize.x / 2,rangeSize.x / 2), 
                                       rangeCenter.y + Random.Range(-rangeSize.y / 2, rangeSize.y / 2),
                                       rangeCenter.z + Random.Range(-rangeSize.z / 2, rangeSize.z / 2));
        //일반식형태 
        //정사각형 중심 기준으로 x방향은 -x/2, +x/2 / z방향은 -z/2, +z/2 범위로 생성  y=0넣으면 됨.

        if (spawnTimer < 0)
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            spawnTimer = spawnTimeGap;            
        }
        else
        {
            spawnTimer -= Time.deltaTime;            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // new Color(a,a,a,) rgb세팅도 가능
        Gizmos.DrawCube(rangeCenter, rangeSize);
        //Gizmos.DrawWireCube(rangeCenter, rangeSize); 모서리만 보고싶다. 
    }
}

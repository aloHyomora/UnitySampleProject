using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //enemy�����ʿ�
    public GameObject enemyPrefab;
    public Vector3 rangeCenter; //�������� �߰�
    public Vector3 rangeSize;   //�������� ũ��

    public float spawnTimeGap = 0.3f;
    private float spawnTimer;

    private void Update()
    {
        Vector3 spawnPos = new Vector3(rangeCenter.x + Random.Range(-rangeSize.x / 2,rangeSize.x / 2), 
                                       rangeCenter.y + Random.Range(-rangeSize.y / 2, rangeSize.y / 2),
                                       rangeCenter.z + Random.Range(-rangeSize.z / 2, rangeSize.z / 2));
        //�Ϲݽ����� 
        //���簢�� �߽� �������� x������ -x/2, +x/2 / z������ -z/2, +z/2 ������ ����  y=0������ ��.

        if (spawnTimer < 0)
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            spawnTimer = spawnTimeGap;
            Debug.Log("Instantiate");
        }
        else
        {
            spawnTimer -= Time.deltaTime;
            Debug.Log("deltaTime"+Time.deltaTime);
            Debug.Log("spawnTimer"+spawnTimer);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // new Color(a,a,a,) rgb���õ� ����
        Gizmos.DrawCube(rangeCenter, rangeSize);
        //Gizmos.DrawWireCube(rangeCenter, rangeSize); �𼭸��� ����ʹ�. 
    }
}

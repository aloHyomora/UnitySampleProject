using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; //�Ѿ� ��� ��ġ
    public float fireTimeGap = 0.3f;
    private float fireTimer;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);        
    }
}

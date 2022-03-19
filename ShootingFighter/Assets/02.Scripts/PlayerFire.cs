using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; //총알 출발 위치
    public float fireTimeGap = 0.3f;
    private float fireTimer;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);        
    }
}

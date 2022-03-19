using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�������Ѵ� ���� �ӵ��ʿ�
    public Vector3 dir =  Vector3.forward; //����
    public float speed = 5f;
    Transform tr;
    private void Awake() =>  
        tr= GetComponent<Transform>(); //������ǥ���� �� �ִ�.
    
    private void FixedUpdate()
    {
        tr.Translate(dir * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //enemy������ ���� �Ѿ� ����
        GameObject go = other.gameObject; //gameObject ->�浹�� ���ӿ�����Ʈ
        if (go == null) return;
        //���̾�üũ
        if(go.layer == LayerMask.NameToLayer("Enemy")) //Enemy üũ
        {
            
            go.GetComponent<Enemy>().DoDestroyEffect(); //Ŭ����
            Destroy(go);         //"Enemy"���̾�� ������Ʈ �ѽð�
            Destroy(gameObject); //�ڱ��ڽ� �ѽð�
        }

    }
}

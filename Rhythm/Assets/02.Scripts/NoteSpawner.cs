using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public KeyCode keyCode;
    public GameObject notePrefab; // ��Ʈ�� ��ȯ�ؾ��ϴϰ�

    public void SpawnNote()
    {
        Instantiate(notePrefab, transform.position, Quaternion.identity); // ������Ʈ ����
    }

}

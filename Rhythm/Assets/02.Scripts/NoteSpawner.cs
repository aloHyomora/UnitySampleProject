using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public KeyCode keyCode;
    public GameObject notePrefab; // 노트를 소환해야하니간

    public void SpawnNote()
    {
        Instantiate(notePrefab, transform.position, Quaternion.identity); // 오브젝트 생성
    }

}

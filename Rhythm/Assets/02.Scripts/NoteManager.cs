using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    // 싱글톤형태로사용
    public static NoteManager instance;
    public static float noteSpeedScale = 1f; // 게임시작할때의 세팅에 따라서 다름

    [SerializeField] private Transform spawnersParent;
    [SerializeField] private Transform hittersParent;


    public float noteFallingDistance // 초기화 할 필요없고 두 사이의 거리만 계산하면 되기 때문에 프로퍼티
    {
        get
        {
            return spawnersParent.position.y - hittersParent.position.y;
        }
    }

    public float noteFallingTime
    {
        get
        {
            return noteFallingDistance / noteSpeedScale;
        }
    }
    private Dictionary<KeyCode, NoteSpawner> spawners = new Dictionary<KeyCode,NoteSpawner>();
    private Queue<NoteData> noteQueue = new Queue<NoteData>();
    //=============================================================
    // ******************** Public Methods ***********************
    //=============================================================
    public void StartSpawn()
    {
        if (noteQueue.Count > 0)
            StartCoroutine(E_Spawning());
    }

    IEnumerator E_Spawning()
    {
        float startTimeMark = Time.time; // 처음 시간
        while (noteQueue.Count > 0) // noteQueue가 다 나가버리면 코루틴이 멈출수있다. 
        {
            for (int i = 0; i < noteQueue.Count; i++)
            {                             // 게임 실행 후 흐른 시간 - 처음시간
                if (noteQueue.Peek().time < (Time.time - startTimeMark)/noteSpeedScale ) // noteSpawning이 시작되는 시간에다가 FallingTime더해주면 됨
                {
                    NoteData note = noteQueue.Dequeue(); // noteQueue의 카운트는 줄어듬
                    spawners[note.keyCode].SpawnNote();
                }
                else
                    break;
            }
            yield return null; // 나갈 수 있어야 함. 
        }
    }
    //=============================================================
    // ******************** Private Methods ***********************
    //=============================================================
    private void Awake()
    {
        instance = this;
        NoteSpawner[] tmpSpawners = spawnersParent.GetComponentsInChildren<NoteSpawner>();
        foreach (NoteSpawner spawner in tmpSpawners)
        {
            spawners.Add(spawner.keyCode, spawner);
        }
        // 노트 데이터들 큐에 시간순 등록
        List<NoteData> notes = SongSelector.instance.songData.notes;
        for (int i = 0; i < notes.Count; i++)
        {

            float timeScaled = notes[i].time / NoteAssetss.GetNote(notes[i].keyCode).speed;
            notes[i] = new NoteData
            {
                keyCode = notes[i].keyCode,
                time = timeScaled,
            };
        }
        notes.Sort((x, y) => x.time.CompareTo(y.time));
        //시간에 따라서 오름차순정렬이 된다.
        foreach (NoteData note in notes)
            noteQueue.Enqueue(note);
    }
    
}

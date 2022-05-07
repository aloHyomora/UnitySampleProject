using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    // �̱������·λ��
    public static NoteManager instance;
    public static float noteSpeedScale = 1f; // ���ӽ����Ҷ��� ���ÿ� ���� �ٸ�

    [SerializeField] private Transform spawnersParent;
    [SerializeField] private Transform hittersParent;


    public float noteFallingDistance // �ʱ�ȭ �� �ʿ���� �� ������ �Ÿ��� ����ϸ� �Ǳ� ������ ������Ƽ
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
        float startTimeMark = Time.time; // ó�� �ð�
        while (noteQueue.Count > 0) // noteQueue�� �� ���������� �ڷ�ƾ�� ������ִ�. 
        {
            for (int i = 0; i < noteQueue.Count; i++)
            {                             // ���� ���� �� �帥 �ð� - ó���ð�
                if (noteQueue.Peek().time < (Time.time - startTimeMark)/noteSpeedScale ) // noteSpawning�� ���۵Ǵ� �ð����ٰ� FallingTime�����ָ� ��
                {
                    NoteData note = noteQueue.Dequeue(); // noteQueue�� ī��Ʈ�� �پ��
                    spawners[note.keyCode].SpawnNote();
                }
                else
                    break;
            }
            yield return null; // ���� �� �־�� ��. 
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
        // ��Ʈ �����͵� ť�� �ð��� ���
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
        //�ð��� ���� �������������� �ȴ�.
        foreach (NoteData note in notes)
            noteQueue.Enqueue(note);
    }
    
}

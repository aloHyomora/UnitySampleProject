using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAssetss : MonoBehaviour
{
    private static NoteAssetss _instance;
    public static NoteAssetss Instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<NoteAssetss>("NoteAssetss"));
            return _instance;
        }
    }
    public List<Note> notes = new List<Note>();

    public static Note GetNote(KeyCode keyCode)=>
        Instance.notes.Find(x => x.keyCode ==keyCode);  //키코드 오브젝트 받아옴.
}

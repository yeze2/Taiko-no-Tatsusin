using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


[System.Serializable]
public class MusicInfo
{
    public string title;
    public int bpm;
    public int time;
    public int difficultyLv;
    public List<NoteSetting> notes;
}

[System.Serializable]
public class NoteSetting
{
    public int noteType;
    public float noteTime;
}


public class NoteManager : MonoBehaviour
{
    public TextAsset textJson;

    double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject[] notes;

    public int noteType = 0;
    TimingManager timing;

    private string SAVE_DATA_DIRECTORY;
    public MusicInfo musicInfo;
    private int indexNum;
    private PlayerController playerController;

    private float beat;
    private int meter;
    private float oneBeat;

    static public bool isPlaying = false;
    private bool noteOver = false;
    float startTime;

    static public float playTime;

    private void Start()
    {
        timing = GetComponent<TimingManager>();
        //GameObject tfNote = Instantiate(note) as GameObject;
        //notes.Add(tfNote);
        musicInfo = JsonConvert.DeserializeObject<MusicInfo>(textJson.text);

        SAVE_DATA_DIRECTORY = Application.dataPath + "/test.json";
        indexNum = 0;



    }

    void Update()
    {
        beat = 60f / musicInfo.bpm;
        meter = musicInfo.time / 4;
        oneBeat = beat * meter;

        playTime = Time.time - startTime;

        if (Input.GetMouseButtonDown(1))
        {
            isPlaying = true;
            startTime = Time.time;
        }

        if (!noteOver && isPlaying && playTime >= musicInfo.notes[indexNum].noteTime * oneBeat)
        {
            noteType = musicInfo.notes[indexNum].noteType;

            MakeNote();
            indexNum++;
            if (indexNum >= musicInfo.notes.Count)
            {
                noteOver = true;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            timing.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    public void MakeNote()
    {
        //MusicInfo musicInfo = JsonUtility.FromJson<MusicInfo>();
        var prefab = Instantiate(notes[noteType], tfNoteAppear.position, Quaternion.identity);
        prefab.transform.SetParent(this.transform);
        timing.boxNoteList.Add(prefab);
    }
    
    private void LoadJsonFile()
    {
        var jdata = File.ReadAllText(SAVE_DATA_DIRECTORY);
        var list = JsonConvert.DeserializeObject<List<string>>(jdata);

        foreach(var item in list)
        {
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

//[System.Serializable]
//public class MusicInfo
//{
//    public string title;
//    public string artist;
//    public string difficulty;
//    public int bpm;
//    public int time;
//    public int noteType;
//    public float noteTiming;
//}

public class NoteTool : MonoBehaviour
{
    public AudioSource audioSource;
    AudioClip music;
    public RectTransform rectLine;

    public string filePath = "Assets/Resources";

    private float[] spectrum;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rectLine = GetComponent<RectTransform>();
    }
    void Start()
    {
        spectrum = new float[256];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeNote()
    {
        Debug.Log(Time.time);
    }

    public void LoadBeatMapFile()
    {
        float auidoLength = audioSource.clip.length;
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
        SetWidth(auidoLength);
        Debug.Log(audioSource.time);
    }

    private void SetWidth(float audioLength)
    {
        rectLine.sizeDelta = new Vector2(audioLength * 10f, rectLine.sizeDelta.y);
        Debug.Log(audioLength);
    }
}

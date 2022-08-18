using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Metronome : MonoBehaviour
{
    AudioSource play;
    public AudioClip tik;

    public int musicBpm = 60;
    public int stdBpm = 60;
    public int musicMeter = 4;
    public int stdMeter = 4;

    private float tikTime = 0f;
    private float nextTime = 0f;
    //private System.DateTime time;

    private bool isPlaying;
    float startTime;


    void Start()
    {
        play = GetComponent<AudioSource>();
        gameObject.GetComponent<Button>().onClick.AddListener(TurnOnAndOff);
        isPlaying = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
            return;

        tikTime = ((float)stdBpm / musicBpm) * (musicMeter / stdMeter);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            startTime = Time.time;

            Debug.Log(startTime);

            if (Time.time -startTime >= nextTime)
            {
                Debug.Log(nextTime);
                play.PlayOneShot(tik);
                nextTime += tikTime;
            }
        }

    }

    public void TurnOnAndOff()
    {
        isPlaying ^= true;
        play.Stop();
    }
}

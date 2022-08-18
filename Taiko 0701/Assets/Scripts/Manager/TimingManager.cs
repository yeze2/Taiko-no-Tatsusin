using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
    public GameObject perfectEff;

    private AudioSource audioSource;
    public AudioClip combo10;
    public AudioClip combo30;
    public AudioClip combo50;
    public AudioClip combo100;
    public AudioClip perfectClip;


    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxes = null;

    static public int score;
    static public int perfect;
    static public int good;
    static public int miss;


    private int combo = 0;
    public Text scoreUI;
    public Text comboUI;

    public GaugeManager gaugeManager;
    public int gauge { get; set; }

    Animator effectAnim;

    void Start()
    {
        timingBoxes = new Vector2[timingRect.Length];
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxes[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2, Center.localPosition.x + timingRect[i].rect.width / 2);
        }

        scoreUI.text = $"{score}";
        comboUI.text = " ";
        effectAnim = perfectEff.GetComponent<Animator>();
        perfectEff.SetActive(false);
        
        perfect = 0;
        good = 0;
        miss = 0;
        
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = $"{score}";
        if (combo >= 10)
            comboUI.text = $"{combo}";
        else
            comboUI.text = " ";

        gaugeManager.Set(gauge);
        if(combo ==10)
        {
            ComboSound(10);
        }
        if (combo == 30)
        {
            ComboSound(30);
        }
        if (combo == 50)
        {
            ComboSound(10);
        }
        if (combo == 100)
        {
            ComboSound(100);
        }
    }

    public void CheckTiming()
    {
        for(int i = 0; i < boxNoteList.Count; i++)
        {
            float notePosX = boxNoteList[i].transform.localPosition.x;

            for(int j= 0; j < timingBoxes.Length; j++)
            {
                if(timingBoxes[j].x<=notePosX&&notePosX<=timingBoxes[j].y)
                {
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);
                    Debug.Log(combo);

                    switch(j)
                    {
                        case 0:
                            score += 1000;
                            combo += 1;
                            gauge += 1;
                            perfect += 1;
                            break;
                        case 1:
                            score += 100;
                            combo += 1;
                            gauge += 1;
                            good += 1;
                            break;
                        case 2:
                            combo = 0;
                            gauge -= 1;
                            if(gauge<0)
                            {
                                gauge = 0;
                            }
                            miss += 1;
                            break;
                        default:
                            break;
                    }
                    return;
                }
            }
        }
    }

    public void ComboSound(int combo)
    {
        switch(combo)
        {
            case 10:
                audioSource.clip = combo10;
                break;
            case 30:
                audioSource.clip = combo30;
                break;
            case 50:
                audioSource.clip = combo50;
                break;
            case 100:
                audioSource.clip = combo100;
                break;
        }
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(var boxNote in boxNoteList)
        {
            if(timingBoxes[0].x<= boxNote.transform.localPosition.x && Input.anyKeyDown)
            {
                perfectEff.SetActive(true);
                effectAnim.SetTrigger("Perfect");
            }
        }
    }
}

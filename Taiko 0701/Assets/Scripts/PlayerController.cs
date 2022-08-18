using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioSource music;
    TimingManager timing;
    public GameObject pauseMenu;

    private int timer = 3;
    public Text timerUI;

    private bool isPaused = false;

    AudioSource audioSource;
    public AudioClip don;
    public AudioClip katsu;
    public AudioClip bigDon;
    public AudioClip bigKatsu;
    private void Start()
    {
        timing = FindObjectOfType<TimingManager>();
        pauseMenu.SetActive(false);
        timerUI.gameObject.SetActive(false);
        this.audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)||Input.GetKeyDown(KeyCode.J))
        {
            //판정 체크
            timing.CheckTiming();
            KatsuDonSound(0);
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.K))
        {
            timing.CheckTiming();
            KatsuDonSound(1);
        }
        if (Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.J))
        {
            timing.CheckTiming();
            KatsuDonSound(2);
        }
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.K))
        {
            timing.CheckTiming();
            KatsuDonSound(3);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }

        if (Input.GetMouseButtonDown(1))
        {
            music.Play();
            Debug.Log(music.clip.length);
        }

        if (!music.isPlaying && NoteManager.playTime >= music.clip.length)
        {
            EndStage();
        }
    }

    public void PauseMenu()
    {
        //일시정지 메뉴s
        pauseMenu.SetActive(true);
        music.Pause();
        isPaused = true;
        timer = 3;
        timerUI.text = $"{timer}";

    }

    public void ReturntoPlay()
    {
        StartCoroutine(PlayAfter3Secs());
    }

    IEnumerator PlayAfter3Secs()
    {
        pauseMenu.SetActive(false);
        if (timer>0)
        {
            timerUI.gameObject.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSecondsRealtime(1);
                timer -= 1;
                Time.timeScale = 1f;
                timerUI.text = $"{timer}";
            }
        }
        if(timer==0)
        {
            isPaused = false;
            timerUI.gameObject.SetActive(false);
            music.Play();
        }
    }

    public void GoSelectScene()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void EndStage()
    {
        SceneManager.LoadScene("ScoreScene");
    }

    public void KatsuDonSound(int noteType)
    {
        switch (noteType)
        {
            case 0:
                audioSource.clip = don;
                break;
            case 1:
                audioSource.clip = katsu;
                break;
            case 2:
                audioSource.clip = bigDon;
                break;
            case 3:
                audioSource.clip = bigKatsu;
                break;
        }
        audioSource.Play();

    }
}

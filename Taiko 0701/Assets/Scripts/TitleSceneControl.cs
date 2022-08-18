using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneControl : MonoBehaviour
{
    public AudioSource audioSource;
    AudioClip clip;

    public AudioClip katsu;
    public AudioClip don;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SelectScene");
            audioSource.PlayOneShot(katsu);
            audioSource.PlayOneShot(don);
        }
    }
}

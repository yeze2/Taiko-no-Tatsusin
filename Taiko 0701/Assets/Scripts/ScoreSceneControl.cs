using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSceneControl : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        audioSource.Play();

        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SelectScene");
        }
    }
}

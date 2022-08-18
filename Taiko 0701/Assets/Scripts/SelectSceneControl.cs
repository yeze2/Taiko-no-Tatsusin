using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

class SLData
{
    //아 무ㅝㄹ 저장해야되는거임 지낮 개빡친다
    string fileLocation;
    string lastPlayedMusic;
}
public class SelectSceneControl : MonoBehaviour
{
    AudioSource audioSource;
    SLData data = new SLData();

    public AudioClip don;
    public AudioClip chooseMusic;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(chooseMusic);
    }
    void Update()
    {
    }

    public void ReturnTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1.0f;
    }

    public void SaveGameProgress()
    {
        string jdata = JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.dataPath + "/saveLoadData.json", jdata);
    }

    public void LoadGameProgress()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/saveLoadData.json");
        data = JsonConvert.DeserializeObject<SLData>(jdata);
    }

    public void LoadKickIt()
    {
        SceneManager.LoadScene("SampleScene");
        audioSource.PlayOneShot(don);
    }

    public void LoadHot()
    {
        SceneManager.LoadScene("HotPlay");
        audioSource.PlayOneShot(don);
    }
}

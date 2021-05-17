using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; private set; }

    public GameObject Hijo;
    public static AudioClip Song;
    static AudioSource audiosrc;
    static AudioSource audiosrc2;

    Scene currentScene;
    string sceneName;

    private float musicVolume = 0.1f;
    private float sfxVolume = 0.1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!!");
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        

        audiosrc = GetComponent<AudioSource>();
        audiosrc2 = Hijo.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        //if (!audiosrc.isPlaying)
        //{
        //    if ((sceneName == "MainMenu" || sceneName == "GameOver" || sceneName == "Win" || sceneName == "Intro3"))
        //    {
        //        PlaySound("Song");
        //    }
        //    else if (sceneName == "Start")
        //    {
        //        PlaySound("IntroSong");
        //    }
        //    else
        //    {
        //        PlaySound("SongGame");
        //    }
        //}

        audiosrc.volume = musicVolume;

        audiosrc2.volume = sfxVolume;
    }

    public void SetVolumeMusic(float vol)
    {
        musicVolume = vol;
    }
    public void SetVolumeSFX(float vol)
    {
        sfxVolume = vol;
    }

    /*private void CheckCollisions()
    {
       
    }*/
    public static void StopSound() { audiosrc.Stop(); }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Song":
                break;
        }
    }
}
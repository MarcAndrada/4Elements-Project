using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; private set; }

    public GameObject Hijo;
    public static AudioClip Song, Attack, Damage, ClickMenu, Combination, Witch, Teleporter;
    static AudioSource audiosrc;
    static AudioSource audiosrc2;

    //Scene currentScene;
    //string sceneName;

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
        Song = Resources.Load<AudioClip>("SongGame");
        Attack = Resources.Load<AudioClip>("Attack");
        Damage = Resources.Load<AudioClip>("Damage");
        ClickMenu = Resources.Load<AudioClip>("ClickMenu");
        Combination = Resources.Load<AudioClip>("Mix");
        Witch = Resources.Load<AudioClip>("Witch");
        Teleporter = Resources.Load<AudioClip>("Teleporter");

        audiosrc = GetComponent<AudioSource>();
        audiosrc2 = Hijo.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!audiosrc.isPlaying) { PlaySound("SongGame"); }

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

    public static void StopSound() { audiosrc.Stop(); }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "SongGame":
                audiosrc.PlayOneShot(Song);
                break;
            case "Attack":
                audiosrc2.PlayOneShot(Attack);
                break;
            case "Damage":
                audiosrc2.PlayOneShot(Damage);
                break;
            case "ClickMenu":
                audiosrc2.PlayOneShot(ClickMenu);
                break;
            case "Mix":
                audiosrc2.PlayOneShot(Combination);
                break;
            case "Witch":
                audiosrc2.PlayOneShot(Witch);
                break;
            case "Teleporter":
                audiosrc2.PlayOneShot(Teleporter);
                break;
        }
    }
}
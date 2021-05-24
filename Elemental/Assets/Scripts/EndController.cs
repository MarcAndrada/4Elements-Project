using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public Text _Finalscore;
    public Text _ActualScore;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Finalscore.text = TimeManager.Instance.bestTime.ToString("F2");
        _ActualScore.text = TimeManager.Instance.newTime.ToString("F2");

        float delta = Time.deltaTime;
        timer += delta;
        if (timer > 6.5f) SceneManager.LoadScene("MainMenu");
    }
}

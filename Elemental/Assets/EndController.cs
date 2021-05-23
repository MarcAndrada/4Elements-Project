using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EndController : MonoBehaviour
{
    public Text _Finalscore;
    public Text _ActualScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Finalscore.text = TimeManager.Instance.bestTime.ToString("F2");
        _ActualScore.text = TimeManager.Instance.newTime.ToString("F2");
    }
}

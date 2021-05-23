using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    public float bestTime;
    public float newTime;


     void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
      
    }
    // Start is called before the first frame update
    void Start()
    {
      
        newTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (bestTime == null)
        {
            TimeReader();
        }
        if (bestTime < newTime)
        {
            TimeWrite(newTime);
            TimeReader();
        }
    }
    public void setNewtime(float _time)
    {
        newTime = _time;
    }
    public void TimeWrite(float _newhighest)
    {
        BinaryWriter writer = new BinaryWriter(File.Open("time.sav", FileMode.Create));
        writer.Write(_newhighest);
        writer.Close();
    }

    public void TimeReader()
    {
        BinaryReader reader;
        if (File.Exists("time.sav"))
        {
             reader = new BinaryReader(File.Open("time.sav", FileMode.Open));

        }
        else { return; }
        bestTime = reader.ReadInt32();
        reader.Close();
    }
}

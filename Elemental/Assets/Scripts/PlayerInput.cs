using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static float Vertical
    {
        get { return Input.GetAxis("Vertical"); }
    }

    public static float Horizontal
    {
        get { return Input.GetAxis("Horizontal"); }
    }


    public static bool Fire
    {
        get { return Input.GetKeyDown(KeyCode.Alpha1); }
    }
    public static bool Water
    {
        get { return Input.GetKeyDown(KeyCode.Alpha2); }
    }

    public static bool Wind
    {
        get { return Input.GetKeyDown(KeyCode.Alpha3); }
    }

    public static bool Earth
    {
        get { return Input.GetKeyDown(KeyCode.Alpha4); }
    }

    public static bool ShootUp 
    {
        get { return Input.GetKey(KeyCode.UpArrow); }
    }

    public static bool ShootDown 
    {
        get { return Input.GetKey(KeyCode.DownArrow); }
    }

    public static bool ShootLeft 
    {
        get { return Input.GetKey(KeyCode.LeftArrow); }
    }

    public static bool ShootRight 
    {
        get { return Input.GetKey(KeyCode.RightArrow); }
    }



    public static bool UseHability
    {
        get{ return Input.GetKey(KeyCode.Mouse0); }
    }

    public static bool PauseMenu
    {

        get { return Input.GetKeyDown(KeyCode.Escape);  }
    }
}

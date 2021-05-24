using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoLevel()
    {
        SoundManager.PlaySound("ClickMenu");
        SceneManager.LoadScene("Gameplay");
    }
    public void GoOptions()
    {
        SoundManager.PlaySound("ClickMenu");
        SceneManager.LoadScene("Options");
    }
    public void GoMenu()
    {
        SoundManager.PlaySound("ClickMenu");
        SceneManager.LoadScene("MainMenu");
    }
    public void GoExit()
    {
        SoundManager.PlaySound("ClickMenu");
        Application.Quit();
    }
}

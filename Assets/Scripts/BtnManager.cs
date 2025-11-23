using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public void Play1Click()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Play2Click()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Play3Click()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Play4Click()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Play5Click()
    {
        SceneManager.LoadScene("Level5");
    }

    public void MenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
    public void CreditsClick()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ExitClick()
    {
        Application.Quit();
        // If running in the editor, stop playing the scene
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }    
}

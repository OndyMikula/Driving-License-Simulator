using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public void PlayClick()
    {
        SceneManager.LoadScene("Game");
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

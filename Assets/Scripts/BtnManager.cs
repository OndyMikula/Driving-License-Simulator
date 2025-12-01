using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public gameController gameC;
    public carController carC;

    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Resume()
    {
        gameC.Canvas_Uncompleted.enabled = false;
        gameC.Canvas_UncompletedText.text = "";
        carC.maxSpeed = 60;
        carC.currentSpeed = 5;
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

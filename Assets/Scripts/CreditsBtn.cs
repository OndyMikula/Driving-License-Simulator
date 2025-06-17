using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBtn : MonoBehaviour
{
    public void OnCreditsButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }

}

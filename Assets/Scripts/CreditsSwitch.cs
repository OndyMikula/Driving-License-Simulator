using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSwitch : MonoBehaviour
{
    GameObject Credits1;
    GameObject Credits2;
    GameObject Credits3;

    // Start is called before the first frame update
    void Start()
    {
        Credits1 = GameObject.Find("Canvas_Page1");
        Credits2 = GameObject.Find("Canvas_Page2");
        Credits3 = GameObject.Find("Canvas_Page3");

        Credits1.SetActive(true);
        Credits2.SetActive(false);
        Credits3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCredits1()
    {
        Credits1.SetActive(true);
        Credits2.SetActive(false);
        Credits3.SetActive(false);
    }

    public void ShowCredits2()
    {
        Credits1.SetActive(false);
        Credits2.SetActive(true);
        Credits3.SetActive(false);
    }

    public void ShowCredits3()
    {
        Credits1.SetActive(false);
        Credits2.SetActive(false);
        Credits3.SetActive(true);
    }
}

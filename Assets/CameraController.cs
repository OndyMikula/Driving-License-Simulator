using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float osa_x, osa_y;
    public GameObject player;
    int mouseSensitivity = 12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        osa_x -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        osa_y += Input.GetAxis("Mouse X") * mouseSensitivity;

        transform.localEulerAngles = new Vector3(osa_x, 0, 0); //naklon hlavy pomoci mysi
        player.transform.localEulerAngles = new Vector3(0, osa_y, 0); //otaceni playera pomoci wsad
    }
}

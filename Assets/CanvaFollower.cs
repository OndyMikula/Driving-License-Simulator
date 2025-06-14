using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvaFollower : MonoBehaviour
{
    public Transform player;  // Auto
    public Vector3 offset = new Vector3(0, 2, 4); // Vždy před autem

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null) return;

        // Umísti canvas vždy před auto podle offsetu
        transform.position = player.TransformPoint(offset);

        // Otočení canvasu stejné jako auto (nebo jen horizontální osa)
        transform.rotation = Quaternion.Euler(0, player.eulerAngles.y, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player = null;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        transform.position = playerPos + startPos;
    }
}

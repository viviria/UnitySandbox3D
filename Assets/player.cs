using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leftButtonDown()
    {
        var pos = transform.position;
        pos.x -= 1.0f;

        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    public void rightButtonDown()
    {
        var pos = transform.position;
        pos.x += 1.0f;

        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    public void upButtonDown()
    {
        var pos = transform.position;
        pos.z += 1.0f;

        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void downButtonDown()
    {
        var pos = transform.position;
        pos.z -= 1.0f;

        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, -180, 0);
    }
}

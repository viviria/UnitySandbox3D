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
        transform.Translate(-1, 0, 0);
    }

    public void rightButtonDown()
    {
        transform.Translate(1, 0, 0);
    }

    public void upButtonDown()
    {
        transform.Translate(0, 0, 1);
    }

    public void downButtonDown()
    {
        transform.Translate(0, 0, -1);
    }
}

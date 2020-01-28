using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator = null;
    private Vector3 moveVec;
    private float moveTime = 0.25f;
    private float moveDeltaTime = 0.0f;
    private bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (moveDeltaTime <= moveTime)
            {
                transform.position = transform.position + moveVec * Time.deltaTime;
                moveDeltaTime += Time.deltaTime;
            }
            else
            {
                isMove = false;
                this.animator.SetTrigger("idleTrigger");
            }
        }
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
        isMove = true;
        moveDeltaTime = 0.0f;
        moveVec = new Vector3(0, 0, 1.0f / moveTime);

        transform.rotation = Quaternion.Euler(0, 0, 0);
        this.animator.SetTrigger("walkTrigger");
    }

    public void downButtonDown()
    {
        var pos = transform.position;
        pos.z -= 1.0f;

        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, -180, 0);
    }
}

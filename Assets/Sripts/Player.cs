using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Player : MonoBehaviour
{
    private Animator animator = null;
    private float moveTime = 0.25f;
    private float attackTime = 0.75f;
    private TimeCallback callbackManager = null;
    private GameObject uiCanvas = null;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        uiCanvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (callbackManager != null)
        {
            callbackManager.Update(Time.deltaTime);
        }
    }
    
    void moveAction(Vector3 moveVec)
    {
        callbackManager = new TimeCallback(moveTime,
            deltaTime => {
                transform.position = transform.position + moveVec * deltaTime / moveTime;
            },
            () => {
                this.animator.SetTrigger("idleTrigger");
                this.callbackManager = null;
                uiCanvas.GetComponent<CanvasController>().setEnabled(true);
            }
        );

        uiCanvas.GetComponent<CanvasController>().setEnabled(false);
        this.animator.SetTrigger("walkTrigger");
        callbackManager.Start();
    }

    public void moveButtonDown(int moveDir)
    {
        float rotate = 0.0f, dx = 0.0f, dz = 0.0f;

        switch (moveDir)
        {
            case 0: // UP
                dz = 1.0f;
                break;
            case 1: // RIGHT UP
                rotate = 45.0f;
                dx = 1.0f;
                dz = 1.0f;
                break;
            case 2: // RIGHT
                rotate = 90.0f;
                dx = 1.0f;
                break;
            case 3: // RIGHT DOWN
                rotate = 135.0f;
                dx = 1.0f;
                dz = -1.0f;
                break;
            case 4: // DOWN
                rotate = 180.0f;
                dz = -1.0f;
                break;
            case 5: // LEFT DOWN
                rotate = -135.0f;
                dx = -1.0f;
                dz = -1.0f;
                break;
            case 6: // LEFT
                rotate = -90.0f;
                dx = -1.0f;
                break;
            case 7: // LEFT UP
                rotate = -45.0f;
                dx = -1.0f;
                dz = 1.0f;
                break;
        }

        transform.rotation = Quaternion.Euler(0, rotate, 0);
        moveAction(new Vector3(dx, 0, dz));
    }

    public void attackButtonDown()
    {
        if (callbackManager != null && callbackManager.isExecute_)
        {
            return;
        }

        callbackManager = new TimeCallback(attackTime, null,
            () => {
                this.animator.SetTrigger("idleTrigger");
                this.callbackManager = null;
            }
        );
        
        animator.SetTrigger("attackTrigger");
        callbackManager.Start();
    }
}

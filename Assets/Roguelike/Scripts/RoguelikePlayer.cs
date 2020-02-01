using UnityEngine;
using Common;

namespace Roguelike {
  public class RoguelikePlayer : MonoBehaviour
  {
    private Animator animator = null;
    private const float MOVE_TIME = 0.25f;
    private const float MOVE_DIS = 1.5f;
    private float attackTime = 0.75f;
    private TimeCallback timeCallback = null;
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
        if (timeCallback != null)
        {
            timeCallback.Update(Time.deltaTime);
        }
    }
    
    void moveAction(Vector3 moveVec)
    {
        timeCallback = new TimeCallback(MOVE_TIME,
            deltaTime => {
                transform.position = transform.position + moveVec * deltaTime / MOVE_TIME;
            },
            () => {
                this.animator.SetTrigger("idleTrigger");
                this.timeCallback = null;
                uiCanvas.GetComponent<CanvasController>().setEnabled(true);
            }
        );

        uiCanvas.GetComponent<CanvasController>().setEnabled(false);
        this.animator.SetTrigger("walkTrigger");
        timeCallback.Start();
    }

    public void moveButtonDown(int moveDir)
    {
        float rotate = 0.0f, dx = 0.0f, dz = 0.0f;

        switch (moveDir)
        {
            case 0: // UP
                dz = MOVE_DIS;
                break;
            case 1: // RIGHT UP
                rotate = 45.0f;
                dx = MOVE_DIS;
                dz = MOVE_DIS;
                break;
            case 2: // RIGHT
                rotate = 90.0f;
                dx = MOVE_DIS;
                break;
            case 3: // RIGHT DOWN
                rotate = 135.0f;
                dx = MOVE_DIS;
                dz = -MOVE_DIS;
                break;
            case 4: // DOWN
                rotate = 180.0f;
                dz = -MOVE_DIS;
                break;
            case 5: // LEFT DOWN
                rotate = -135.0f;
                dx = -MOVE_DIS;
                dz = -MOVE_DIS;
                break;
            case 6: // LEFT
                rotate = -90.0f;
                dx = -MOVE_DIS;
                break;
            case 7: // LEFT UP
                rotate = -45.0f;
                dx = -MOVE_DIS;
                dz = MOVE_DIS;
                break;
        }

        transform.rotation = Quaternion.Euler(0, rotate, 0);
        
        TouchUtil.TouchInfo touchInfo = TouchUtil.getTouch();
        if (!TouchUtil.isTouch(touchInfo)) {
            moveAction(new Vector3(dx, 0, dz));
        }
    }

    public void attackButtonDown()
    {
        if (timeCallback != null && timeCallback.isExecute_)
        {
            return;
        }

        timeCallback = new TimeCallback(attackTime, null,
            () => {
                this.animator.SetTrigger("idleTrigger");
                this.timeCallback = null;
            }
        );
        
        animator.SetTrigger("attackTrigger");
        timeCallback.Start();
    }
  }
}

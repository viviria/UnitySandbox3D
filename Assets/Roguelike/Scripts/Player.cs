using UnityEngine;
using Common;

namespace Roguelike {
  public class Player : MonoBehaviour
  {
    private PlayerMove playerMove_ = null;
    private float attackTime = 0.75f;
    private TimeCallback timeCallback = null;
    private Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject uiCanvas = GameObject.Find("Canvas");
        playerMove_ = new PlayerMove(this, animator, uiCanvas);
    }

    // Update is called once per frame
    void Update()
    {
      playerMove_?.Update();
    }
    
    public void moveButtonDown(int moveDir)
    {
      float rotate = moveDir * 45.0f;
      transform.rotation = Quaternion.Euler(0, rotate, 0);
        
      TouchUtil.TouchInfo touchInfo = TouchUtil.getTouch();
      if (!TouchUtil.isTouch(touchInfo)) {
        playerMove_.moveAction(rotate);
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

using UnityEngine;
using Common;

namespace Roguelike {
  public class Player : MonoBehaviour
  {
    private const float MOVE_TIME = 0.25f;
    private MoveController moveController_ = null;
    private PlayerStatus playerStatus_ = null;
    private Animator animator_ = null;

    // Start is called before the first frame update
    void Start()
    {
      GameObject uiCanvas = GameObject.Find("Canvas");
      moveController_ = new MoveController(MOVE_TIME,
      () => {
        uiCanvas.GetComponent<CanvasController>().setEnabled(false);
      },
      () => {
        uiCanvas.GetComponent<CanvasController>().setEnabled(true);
      });
      playerStatus_ = new PlayerStatus();
    }

    // Update is called once per frame
    void Update()
    {
      moveController_?.Update();
    }
    
    public void moveButtonDown(int moveDir)
    {
      float rotate = moveDir * 45.0f;
      transform.rotation = Quaternion.Euler(0, rotate, 0);
      
      TouchUtil.TouchInfo touchInfo = TouchUtil.getTouch();
      if (!TouchUtil.isTouch(touchInfo)) {
        moveController_.moveAction(gameObject, rotate);
      }
    }

    public void attackButtonDown()
    {
      if (animator_.GetCurrentAnimatorStateInfo(0).IsName("attack"))
      {
        return;
      }
      
      animator_.SetTrigger("attackTrigger");
      GameManager.instance().enamyDamage(playerStatus_.power_);
    }
  }
}

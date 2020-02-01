using UnityEngine;
using Common;

namespace Roguelike {
  public class Player : MonoBehaviour
  {
    private PlayerMove playerMove_ = null;
    private PlayerStatus playerStatus_ = null;
    private Animator animator_ = null;

    // Start is called before the first frame update
    void Start()
    {
        animator_ = GetComponent<Animator>();
        playerMove_ = new PlayerMove(this, animator_, GameObject.Find("Canvas"));
        playerStatus_ = new PlayerStatus();
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
      if (animator_.GetCurrentAnimatorStateInfo(0).IsName("attack"))
      {
        return;
      }
      
      animator_.SetTrigger("attackTrigger");
      GameManager.instance().enamyDamage(playerStatus_.power_);
    }
  }
}

using System;
using UnityEngine;
using Common;

namespace Roguelike {
  public class MoveController
  {
    private float moveTime_ = 1.0f;
    private float MOVE_DIS = 1.5f;
    private Action startAction_ = null;
    private Action endCallback_ = null;
    private TimeCallback timeCallback_ = null;
    public MoveController(float moveTime, Action startAction = null, Action endCallback = null)
    {
      moveTime_ = moveTime;
      startAction_ = startAction;
      endCallback_ = endCallback;
    }

    // Update is called once per frame
    public void Update()
    {
      timeCallback_?.Update();
    }

    public void moveAction(GameObject own, float rotateY)
    {

      Animator animator = own.GetComponent<Animator>();

      float moveDis = MOVE_DIS * (rotateY % 90 != 0 ? Mathf.Sqrt(2) : 1);
      Vector3 moveVec = new Vector3(moveDis * Mathf.Sin(rotateY * Mathf.PI / 180), 0, moveDis * Mathf.Cos(rotateY * Mathf.PI / 180));

      timeCallback_ = new TimeCallback(moveTime_,
        deltaTime => {
          own.transform.position = own.transform.position + moveVec * deltaTime / moveTime_;
        },
        () => {
          Debug.Log(own.transform.position);
          endCallback_?.Invoke();
          animator?.SetTrigger("idleTrigger");
        }
      );

      startAction_?.Invoke();
      animator?.SetTrigger("walkTrigger");
      timeCallback_.Start();
    }
  }
}

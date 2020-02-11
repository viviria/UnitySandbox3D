using System;
using UnityEngine;
using Common;

namespace Roguelike {

  public class MoveController
  {
    public enum MoveDir {
      UP, RIGHT_UP, RIGHT, RIGHT_DOWN, DOWN, LEFT_DOWN, LEFT, LEFT_UP
    }

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

    private Vector3 getMoveVector(MoveDir moveDir) {
      switch (moveDir) {
        case MoveDir.UP:
          return new Vector3(0, 0, MOVE_DIS);
        case MoveDir.RIGHT_UP:
          return new Vector3(MOVE_DIS, 0, MOVE_DIS);
        case MoveDir.RIGHT:
          return new Vector3(MOVE_DIS, 0, 0);
        case MoveDir.RIGHT_DOWN:
          return new Vector3(MOVE_DIS, 0, -MOVE_DIS);
        case MoveDir.DOWN:
          return new Vector3(0, 0, -MOVE_DIS);
        case MoveDir.LEFT_DOWN:
          return new Vector3(-MOVE_DIS, 0, -MOVE_DIS);
        case MoveDir.LEFT:
          return new Vector3(-MOVE_DIS, 0, 0);
        case MoveDir.LEFT_UP:
          return new Vector3(-MOVE_DIS, 0, MOVE_DIS);
      }
      return Vector3.zero;
    }

    public void moveAction(GameObject own, MoveDir moveDir)
    {
      Animator animator = own.GetComponent<Animator>();

      Vector3 moveVec = getMoveVector(moveDir);
      if (!GameManager.instance().canMoveCharacter(own, own.transform.position + moveVec)) {
        return;
      }

      timeCallback_ = new TimeCallback(moveTime_,
        deltaTime => {
          own.transform.position += moveVec * deltaTime / moveTime_;
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

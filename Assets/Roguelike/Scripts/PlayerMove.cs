using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Roguelike {
  public class PlayerMove
  {
    private const float MOVE_TIME = 0.25f;
    private float MOVE_DIS = 1.5f * Mathf.Sqrt(2);
    private Player player_ = null;
    private Animator animator_ = null;
    private TimeCallback timeCallback_ = null;
    private GameObject uiCanvas_ = null;
    public PlayerMove(Player player, Animator animator, GameObject uiCanvas)
    {
      player_ = player;
      animator_ = animator;
      uiCanvas_ = uiCanvas;
    }

    // Update is called once per frame
    public void Update()
    {
      timeCallback_?.Update();
    }

    public void moveAction(float rotateY)
    {
      Vector3 moveVec = new Vector3(MOVE_DIS * Mathf.Sin(rotateY * Mathf.PI / 180), 0, MOVE_DIS * Mathf.Cos(rotateY * Mathf.PI / 180));

      timeCallback_ = new TimeCallback(MOVE_TIME,
        deltaTime => {
          player_.transform.position = player_.transform.position + moveVec * deltaTime / MOVE_TIME;
        },
        () => {
          this.animator_.SetTrigger("idleTrigger");
          this.uiCanvas_.GetComponent<CanvasController>().setEnabled(true);
          this.timeCallback_ = null;
          }
        );

        this.uiCanvas_.GetComponent<CanvasController>().setEnabled(false);
        this.animator_.SetTrigger("walkTrigger");
        timeCallback_.Start();
    }
  }
}

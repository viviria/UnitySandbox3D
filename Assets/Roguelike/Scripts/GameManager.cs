using System;
using UnityEngine;

namespace Roguelike {
  public sealed class GameManager
  {
    // Signleton
    private static GameManager gameManager_ = null;

    public static GameManager instance()
    {
      if (gameManager_ == null) {
        gameManager_ = new GameManager();
      }

      return gameManager_;
    }

    // ##########

    public int turn_ { private set; get; } = 1;

    private GameManager()
    {
      turn_ = 1;
    }

    public bool canMoveCharacter(GameObject own, Vector3 checkPosition)
    {
      Vector3 up = Vector3.up * 0.1f;
      if (Physics.Linecast(own.transform.position + up, checkPosition + up)) {
        return false;
      }

      return true;
    }

    public void enamyDamage(int power)
    {
      Debug.Log(power);
    }
  }
}

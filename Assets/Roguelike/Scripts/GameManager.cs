using System.Collections;
using System.Collections.Generic;
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

    public void enamyDamage(int power)
    {
      Debug.Log(power);
    }
  }
}

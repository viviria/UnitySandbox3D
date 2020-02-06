using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike {
  public sealed class MasterManager
  {
    // Signleton
    private static MasterManager masterManager_ = null;

    public static MasterManager instance()
    {
      if (masterManager_ == null) {
        masterManager_ = new MasterManager();
      }

      return masterManager_;
    }

    // ##########
  }
}

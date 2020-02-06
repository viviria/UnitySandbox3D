using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike {
  namespace Master {
    [ExcelAsset]
    public class EnemyMaster : ScriptableObject
    {
	    public List<Entity.EnemyMasterEntity> data;
    }
  }
}

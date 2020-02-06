using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike {
  public class Enemy : MonoBehaviour
  {
    public int id_ = -1;
    
    [SerializeField]
    private Master.EnemyMaster master_ = null;

    private Master.Entity.EnemyMasterEntity data_ = null;
    // Start is called before the first frame update
    void Start()
    {
      data_ = master_.data.Find(x => x.id == id_);
      Debug.Log(data_.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  }
}

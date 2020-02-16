using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike {
  public class CameraController : MonoBehaviour
  {
    public GameObject target_ = null;
    public float horizontalLength_ = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      float angle = transform.eulerAngles.x;
      float y = Mathf.Tan(angle * Mathf.PI / 180.0f) * -horizontalLength_;
      //transform.position = target_.transform.position + new Vector3(0, y, horizontalLength_);
    }
  }
}

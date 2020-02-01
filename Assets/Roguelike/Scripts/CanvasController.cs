using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike {
  public class CanvasController : MonoBehaviour
  {
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setEnabled(bool enabled)
    {
        foreach (Transform child in transform)
        {
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = enabled;
            }
        }
    }
  }
}

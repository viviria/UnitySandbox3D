using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
  public static class TouchUtil
  {
    private static List<RaycastResult> raycastResults = new List<RaycastResult>();

    public enum TouchType
    {
      BEGIN = 0,
      MOVE = 1,
      END = 2,
      NONE = -1,
    }

    public class TouchInfo
    {
      public TouchType type_ { private set; get; } = TouchType.NONE;
      public Vector2 position_ { private set; get; }
      public Touch? touch_ { private set; get; }
      public TouchInfo(TouchType type, Vector2 position, Touch? touch)
      {
        type_ = type;
        position_ = position;
        touch_ = touch;
      }
    }

    private static bool isPointOverUIObject(Vector2 position)
    {
      PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
      eventDataCurrentPosition.position = position;

      EventSystem.current.RaycastAll(eventDataCurrentPosition, raycastResults);
      var over = raycastResults.Count > 0;
      raycastResults.Clear();
      return over;
    }

    private static TouchInfo createTouchInfo(int index)
    {
      TouchType type = TouchType.NONE;
      Vector2 position = Vector2.zero;

      if (Application.isEditor) {
        if (Input.GetMouseButtonDown(0)) {
          type = TouchType.BEGIN;
          position = Input.mousePosition;
        } else if (Input.GetMouseButton(0)) {
          type = TouchType.MOVE;
          position = Input.mousePosition;
        } else if (Input.GetMouseButtonUp(0)) {
          type = TouchType.END;
          position = Input.mousePosition;
        }

        if (isPointOverUIObject(position)) {
          type = TouchType.NONE;
        }
      } else {
        if (Input.touchCount > 0 && index >= 0 && index < Input.touchCount) {
          Touch touch = Input.GetTouch(index);
          type = (TouchType)touch.phase;
          position = touch.position;
          if (isPointOverUIObject(position)) {
            type = TouchType.NONE;
          }
          return new TouchInfo(type, position, touch);
        }
      }
        
      return new TouchInfo(type, position, null);
    }

    public static TouchInfo getTouch()
    {
      return createTouchInfo(0);
    }

    public static TouchInfo[] getTouches()
    {
      TouchInfo[] touches = null;

      if (Input.touchCount > 0) {
        touches = new TouchInfo[Input.touchCount];
        for (int i = 0; i < Input.touchCount; i++) {
          touches[i] = createTouchInfo(i);
        }
      } else {
        touches = new TouchInfo[1];
        touches[0] = createTouchInfo(0);
      }
      
      return touches;
    }
  }
}
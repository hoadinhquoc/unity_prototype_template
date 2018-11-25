using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlAction
{
    SWIPE_LEFT,
    SWIPE_RIGHT,
}
public class InputManager : MonoBehaviour
{
    [SerializeField] float SWIPE_OFFSET = 50f;
    float _cacheTouchX = 0f;
    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            GameplayEvents.INPUT_CONTROL.Raise(ControlAction.SWIPE_RIGHT);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GameplayEvents.INPUT_CONTROL.Raise(ControlAction.SWIPE_LEFT);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousPos = Input.mousePosition;
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                _cacheTouchX += touch.deltaPosition.x;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Cache touch " + _cacheTouchX);
				if(_cacheTouchX > SWIPE_OFFSET)
				{
					GameplayEvents.INPUT_CONTROL.Raise(ControlAction.SWIPE_RIGHT);
				}
				else if(_cacheTouchX < -SWIPE_OFFSET)
				{
					GameplayEvents.INPUT_CONTROL.Raise(ControlAction.SWIPE_LEFT);
				}
				_cacheTouchX = 0f;
            }
        }
    }
}

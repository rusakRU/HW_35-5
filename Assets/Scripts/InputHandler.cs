using UnityEngine;


public class InputHandler : MonoBehaviour
{

    public Vector2 GetTouchDeltaPosition()
    {
        if(Input.touchCount > 0)
        {
           return Input.GetTouch(0).deltaPosition;
        }
        return Vector2.zero;
    }

    public bool isTouchOnScreen()
    {
        if (Input.touchCount > 0) return true;
        else return false;
    }

    

}
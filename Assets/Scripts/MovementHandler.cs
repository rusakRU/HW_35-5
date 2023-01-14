using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public InputHandler inputHandler;
    [SerializeField] private float ballSpeed;

    void Start()
    {
        if (inputHandler == null) Debug.LogError("input handler не назначен");
    }

    void Update()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        if (inputHandler.isTouchOnScreen())
        {
            Vector2 currentDeltaPossition = inputHandler.GetTouchDeltaPosition();
            currentDeltaPossition = currentDeltaPossition * ballSpeed;
            Vector3 newGravityVector = new Vector3(currentDeltaPossition.x, Physics.gravity.y, currentDeltaPossition.y);
            Physics.gravity = newGravityVector;
        }
    }


}

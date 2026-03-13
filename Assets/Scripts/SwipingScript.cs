using UnityEngine;

public class SwipingScript : MonoBehaviour
{
    public float steering=100f;
    public float sensitivity = 70f;

    Vector2 startTouch;
    bool touching = false;

    void Update()
    {
        #if UNITY_EDITOR
            steering = Input.GetAxis("Horizontal");
        #else
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                    startTouch = touch.position;

                if (touch.phase == TouchPhase.Moved)
                {
                    float deltaX = touch.position.x - startTouch.x;
                    steering = Mathf.Clamp(deltaX / Screen.width * sensitivity, -1f, 1f);
                }

                if (touch.phase == TouchPhase.Ended)
                    steering = 0;
            }
        #endif
    }
}
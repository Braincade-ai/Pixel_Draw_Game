using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool isTouchHeld = false; // A boolean to track if the touch is held.
    void Update()
    {
        // Check for touch input.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
           
            // Check if the touch began.
            if (touch.phase == TouchPhase.Began)
            {
                // Touch has begun, set the boolean to true.
                isTouchHeld = true;
            }
            // Check if the touch ended.
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Touch has ended, set the boolean to false.
                isTouchHeld = false;
            }

            if (isTouchHeld)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);
                Debug.Log("Istouching");
            }
        }






        if (Input.GetMouseButtonDown(0))
        {
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(cubeRay, Vector2.zero);

            if (hit)
            {
                hit.collider.gameObject.GetComponent<Player>().OnClick();
                Debug.Log(hit.collider.gameObject.name);
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(cubeRay, Vector2.zero);
            if (hit)
            {
                hit.collider.gameObject.GetComponent<Player>().OnClick();
            }
        }

    }
}

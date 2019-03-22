using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    private bool test;

    public float zoomOutMin = 100;
    public float zoomOutMax = 350;

    public float zoomSpeed;

    public Vector2 minPoz;
    public Vector2 maxPoz;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            test = true;
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - difference * zoomSpeed, zoomOutMin, zoomOutMax);
            test = false;
        }
        else if (Input.GetMouseButton(0) && test==true)
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (!(Camera.main.transform.position.x + direction.x > minPoz.x && Camera.main.transform.position.x + direction.x < maxPoz.x))
                direction.x = 0;
            if (!(Camera.main.transform.position.y + direction.y > minPoz.y && Camera.main.transform.position.y + direction.y < maxPoz.y))
                direction.y = 0;

            Camera.main.transform.position += direction;
        }
    }
}

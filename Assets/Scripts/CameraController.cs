using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 10f;      
    public float minFOV = 20f;          
    public float maxFOV = 60f;          
    public float panSpeed = 20f;        

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        HandleZoom();
        HandlePan();
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float zoomAmount = scroll * zoomSpeed;

        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - zoomAmount, minFOV, maxFOV);
    }

    void HandlePan()
    {
        if (Input.GetMouseButton(2))
        {
            float moveX = -Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            float moveY = -Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

            cam.transform.position += new Vector3(moveX, moveY, 0);
        }
    }
}

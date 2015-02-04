using UnityEngine;
using System.Collections;

[AddComponentMenu("Controlls/Top-Down Camera Controller")]
public class TopDownCameraController : MonoBehaviour
{
    public float CameraSpeed = 5f;
    public float ZoomSpeed = 5f;

    private float _zoomLevel;

    void Start()
    {
        _zoomLevel = Camera.main.transform.position.y;
    }
	
	void Update () 
    {
        CameraMovement();
	}

    private void CameraMovement()
    {
        // foward and horizontal movement
        if (Input.GetAxis("Foward") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            var pos = Camera.main.transform.position;

            var stepFoward = pos.z + (CameraSpeed * Camera.main.transform.position.y/10 * Time.deltaTime * Input.GetAxis("Foward"));
            pos.z = stepFoward;

            var stepHorizontal = pos.x + (CameraSpeed * Camera.main.transform.position.y/10 * Time.deltaTime * Input.GetAxis("Horizontal"));
            pos.x = stepHorizontal;

            Camera.main.transform.position = pos;
        }

        // Zooming
        var zoom = Camera.main.transform.position;

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            _zoomLevel = Mathf.Clamp(zoom.y + ZoomSpeed*-Input.GetAxis("Mouse ScrollWheel")*10, 10, 30);
        }

        var step = Mathf.Lerp(Camera.main.transform.position.y, _zoomLevel, 0.01f);
        zoom.y = step;
        Camera.main.transform.position = zoom;
    }
}

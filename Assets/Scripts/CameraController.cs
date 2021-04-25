using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform CameraTransform;

    public float MovementSpeed;
    public float MovementTime;
    public float RotationAmount;
    public Vector3 ZoomAmount;

    private Vector3 _newPosition;
    private Quaternion _newRotation;
    private Vector3 _newZoom;
    private Vector3 _dragStartPosition;
    private Vector3 _dragCurrentPosition;
    private Vector3 _rotateStartPosition;
    private Vector3 _rotateCurrentPosition;

    private Vector3 _rigStartPosition;
    private Quaternion _rigStartRotation;
    private Vector3 _cameraStartPosition;

    private void Start()
    {
        _newPosition = transform.position;
        _newRotation = transform.rotation;
        _newZoom = CameraTransform.localPosition;

        _rigStartPosition = transform.position;
        _rigStartRotation = transform.rotation;
        _cameraStartPosition = CameraTransform.localPosition;

    }

    private void Update()
    {
        HandleMouseInput();
        HandleKeyboardInput();


        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.position = _rigStartPosition;
            transform.rotation = _rigStartRotation;
            CameraTransform.localPosition = _cameraStartPosition;
            _newPosition = transform.position;
            _newRotation = transform.rotation;
            _newZoom = CameraTransform.localPosition;
        }

    }

    private void HandleMouseInput()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            _newZoom += Input.mouseScrollDelta.y * (ZoomAmount * 5);
        }

        if (Input.GetMouseButtonDown(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float entry;
            if (plane.Raycast(ray, out entry))
            {
                _dragStartPosition = ray.GetPoint(entry);
            }
        }
        if (Input.GetMouseButton(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float entry;
            if (plane.Raycast(ray, out entry))
            {
                _dragCurrentPosition = ray.GetPoint(entry);

                _newPosition = transform.position + _dragStartPosition - _dragCurrentPosition;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            _rotateStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            _rotateCurrentPosition = Input.mousePosition;

            var difference = _rotateStartPosition - _rotateCurrentPosition;
            _rotateStartPosition = _rotateCurrentPosition;
            _newRotation *= Quaternion.Euler(Vector3.up * -difference.x / 5f);
        }

    }

    private void HandleKeyboardInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _newPosition += (transform.forward * MovementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _newPosition += (transform.forward * -MovementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _newPosition += (transform.right * MovementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _newPosition += (transform.right * -MovementSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * RotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * -RotationAmount);
        }

        if (Input.GetKey(KeyCode.R))
        {
            _newZoom += ZoomAmount;
        }

        if (Input.GetKey(KeyCode.F))
        {
            _newZoom -= ZoomAmount;
        }

        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * MovementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * MovementTime);
        CameraTransform.localPosition = Vector3.Lerp(CameraTransform.localPosition, _newZoom, Time.deltaTime * MovementTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float boostMultiplier = 2f;

    [Header("Mouse Look Settings")]
    public float lookSensitivity = 2f;
    public bool invertY = false;

    private float _yaw;
    private float _pitch;

    private void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    private void HandleMovement()
    {
        Vector3 move = new Vector3(
            Input.GetAxis("Horizontal"),
            0, 
            Input.GetAxis("Vertical") 
        );

        if (Input.GetKey(KeyCode.Space)) move.y += 1;
        if (Input.GetKey(KeyCode.LeftShift)) move.y -= 1;

        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftControl)) speed *= boostMultiplier;

        transform.Translate(move.normalized * speed * Time.deltaTime, Space.Self);
    }

    private void HandleMouseLook()
    {
        _yaw += Input.GetAxis("Mouse X") * lookSensitivity;
        _pitch += Input.GetAxis("Mouse Y") * (invertY ? 1 : -1) * lookSensitivity;
        _pitch = Mathf.Clamp(_pitch, -90f, 90f);

        transform.eulerAngles = new Vector3(_pitch, _yaw, 0f);
    }
}
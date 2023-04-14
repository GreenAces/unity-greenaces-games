using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSideMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private float horizontalInput;
    private Vector3 movementDirection;
    private Camera mainCamera;
    private float screenWidth;

    void Start()
    {
        mainCamera = Camera.main;
        screenWidth = Screen.width;
    }

    void Update()
    {
        HandleInput();
        MoveObject();
    }

    private void HandleInput()
    {
        // Check for arrow key input on PC or any other platform
        horizontalInput = Input.GetAxis("Horizontal");

        // Check for touch input on mobile devices
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float touchPositionX = mainCamera.ScreenToWorldPoint(touch.position).x;
                horizontalInput = touchPositionX < transform.position.x ? -1 : 1;
            }
            else
            {
                horizontalInput = 0;
            }
        }
    }

    private void MoveObject()
    {
        movementDirection = new Vector3(horizontalInput, 0, 0);
        transform.position += movementDirection * speed * Time.deltaTime;
    }
}

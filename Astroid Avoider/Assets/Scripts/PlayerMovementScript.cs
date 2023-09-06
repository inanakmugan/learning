using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{

    [SerializeField] float forceMagnitude;
    [SerializeField] float maxVelocity;
    [SerializeField] float rotationSpeed;

    Camera mainCamera;
    Rigidbody rbody;
    Vector3 movementDirection;

    void Start()
    {
        mainCamera = Camera.main;
        rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessInput();

        KeepPlayerOnScreen();

        RotateToFaceVelocity();
    }



    void FixedUpdate()
    {
        if (movementDirection == Vector3.zero) { return; }

        rbody.AddForce(movementDirection * forceMagnitude * Time.deltaTime, ForceMode.Force);

        rbody.velocity = Vector3.ClampMagnitude(rbody.velocity, maxVelocity);
    }

    private void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0f;
            movementDirection.Normalize();

        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }

        if (viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }


        transform.position = newPosition;
    }

    void RotateToFaceVelocity()
    {
        if (rbody.velocity == Vector3.zero) { return; }

        Quaternion targetRotation = Quaternion.LookRotation(rbody.velocity, Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

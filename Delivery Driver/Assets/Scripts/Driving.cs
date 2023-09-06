using UnityEngine;

public class Driving : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float accelerationFactor = 30.0f;
    [SerializeField] float turnFactor = 3.5f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] float driftFactor = 0.95f;
    [SerializeField] float boostedSpeed = 25f;
    [SerializeField] float slowSpeed = 15f;


    //Local Variables
    float accelaritonInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;
    float velocityVUp = 0;
    Rigidbody2D rbody;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ApplyEngineForce();

        KillOrthogonalVelocity();

        ApplySteering();
    }

    private void ApplyEngineForce()
    {
        velocityVUp = Vector2.Dot(transform.up, rbody.velocity);
        //limits maxspeed of car
        if (velocityVUp > maxSpeed && accelaritonInput > 0)
        {
            return;
        }
        //limits reverse maxspeed of car
        if (velocityVUp < -maxSpeed * 0.5f && accelaritonInput < 0)
        {
            return;
        }
        //limits cars max speed at any direction
        if (rbody.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelaritonInput > 0)
        {
            return;
        }
        //manipulates the drag value based on player input to prevent the car from constantly spinning.
        if (accelaritonInput == 0)
        {
            rbody.drag = Mathf.Lerp(rbody.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else { rbody.drag = 0; }
        //applies force
        Vector2 applyEngineForce = transform.up * accelerationFactor * accelaritonInput;

        rbody.AddForce(applyEngineForce, ForceMode2D.Force);
    }

    private void ApplySteering()
    {
        //prevents turning at low speeds.     
        float minSpeedBeforeAllowTurningFactor = (rbody.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        //sets angle and rotates
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;
        rbody.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelaritonInput = inputVector.y;
    }

    void KillOrthogonalVelocity()
    {
        //kills orthagonalvelocity so it creates a more car like movement other than a spaceship like movement    
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rbody.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rbody.velocity, transform.right);

        rbody.velocity = forwardVelocity + rightVelocity * driftFactor;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp")
        {
            maxSpeed = boostedSpeed;
            Destroy(other.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            maxSpeed = slowSpeed;
        }
    }
}

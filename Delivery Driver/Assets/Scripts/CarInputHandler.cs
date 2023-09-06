using UnityEngine;
using UnityEngine.InputSystem;

public class CarInputHandler : MonoBehaviour
{
    Vector2 inputVector = Vector2.zero;
    Driving driving;

    private void Awake()
    {
        driving = GetComponent<Driving>();
    }

    void OnMove(InputValue inputValue)
    {
        //this one uses new input system, in tutorial it is old input system        
        inputVector = inputValue.Get<Vector2>();
        driving.SetInputVector(inputVector);

        Debug.Log(inputVector);
    }
}

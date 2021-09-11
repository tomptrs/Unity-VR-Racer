using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeMoveController : MonoBehaviour
{

    public InputActionReference gripRef = null;
    public InputActionReference turnRef = null;

    // Start is called before the first frame update
    void Start()
    {

        gripRef.action.started += Action_started;
        turnRef.action.started += Action_started1;
      
    }

    private void Action_started1(InputAction.CallbackContext obj)
    {
        Debug.Log("turn");
        var turnVal = obj.ReadValue<Vector2>();
        Debug.Log(turnVal);
    }

    private void Action_started(InputAction.CallbackContext obj)
    {
        Debug.Log("grip");
        var val = obj.ReadValue<float>();
        Debug.Log(val);
    }





    // Update is called once per frame
    void Update()
    {
        var aValue = turnRef.action.ReadValue<Vector2>();
        Debug.Log(aValue);
    }
}

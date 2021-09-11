using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class test : MonoBehaviour
{

    private ActionBasedController actionBasedController;
   public InputActionReference referenceTest = null;
    public InputActionReference turnRef = null;
    // Start is called before the first frame update
    void Start()
    {
        // actionBasedController = GetComponent<ActionBasedController>();
        // actionBasedController.activateAction.action.performed += Action_performed;
        referenceTest.action.started += Action_started;
        referenceTest.action.performed += Action_performed;

        turnRef.action.started += Action_started1;
        
       
    }

    private void Action_started1(InputAction.CallbackContext obj)
    {
        Debug.Log("test");
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("performed");
    }

    private void Action_started(InputAction.CallbackContext obj)
    {
        Debug.Log("started");
    }

    



    // Update is called once per frame
    void Update()
    {
        var val = turnRef.action.ReadValue<Vector2>();
        Debug.Log(val);
      // var value =  actionBasedController.translateAnchorAction.action.ReadValue<Vector2>();
       // Debug.LogWarning(value);
        //float pressValue = actionBasedController.selectAction.action.ReadValue<float>();
        //Debug.Log(pressValue);
        
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        
        public InputActionReference turnRef = null;
        public InputActionReference gripRef = null;
        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            
          //  gripRef.action.started += Action_started;
        }

        private void Action_started(InputAction.CallbackContext obj)
        {
            var aValue = obj.action.ReadValue<float>();
            Debug.Log(aValue);
        }

        public void ResetCarPosition()
        {
            this.transform.localPosition = new Vector3(0,0,0);
            this.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            m_Car.Move(0, 0, 0, 0);
            m_Car.m_Rigidbody.velocity = new Vector3(0, 0, 0);
        }

       

        private void FixedUpdate()
        {

            var turnValue = turnRef.action.ReadValue<Vector2>();
         var accelerateV = gripRef.action.ReadValue<float>();
            float h = turnValue.x;
            float v = turnValue.y;
            

            if(this.transform.localPosition.y < -15f)
            {
                ResetCarPosition();
            }
            m_Car.Move(h, accelerateV, accelerateV, 0);

        }
    }
}

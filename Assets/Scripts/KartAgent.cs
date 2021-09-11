using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class KartAgent : Agent
{
    private CarController m_Car;
    public TextMeshPro scoreBoard;
    private void Start()
    {
        m_Car = GetComponent<CarController>();
        previousPosition = new Vector3(1000, 1000, 1000);
    }

    private void Update()
    {
        scoreBoard.text = GetCumulativeReward().ToString("f4");
    }

    void Reset()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        m_Car.Move(0, 0, 0, 0);
        m_Car.m_Rigidbody.velocity = new Vector3(0, 0, 0);
        previousPosition = new Vector3(1000, 1000, 1000);
    }

    public override void OnEpisodeBegin()
    {
        Reset();
    }

    Vector3 previousPosition;
    public override void OnActionReceived(float[] vectorAction)
    {
        float handbrake = 0;
        if (vectorAction[1] < 0)
            AddReward(-0.02f); //negative reward for driving backwards
       

        //Debug.Log(vectorAction[1]);
        m_Car.Move(vectorAction[0], vectorAction[1], vectorAction[1], 0);

        if(previousPosition == transform.localPosition)
        {
            AddReward(-0.5f);
            EndEpisode();
        }
        previousPosition = transform.localPosition;
    }

    public override void Heuristic(float[] actionsOut)
    {

        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        float b = CrossPlatformInputManager.GetAxis("Jump");
        actionsOut[0] = h;
        actionsOut[1] = v;
      //  actionsOut[2] = b;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("checkpoint"))
        {
            Debug.LogWarning("trigger checkpoint");
            AddReward(0.2f);
        }

        if (other.CompareTag("finish"))
        {
            Debug.LogWarning("finnish checkpoint");
            AddReward(1f);
            EndEpisode();
        }

        if (other.CompareTag("ground"))
        {
            Debug.LogWarning("collision ground");    
            AddReward(-1f);
            EndEpisode();
        }


    }


}

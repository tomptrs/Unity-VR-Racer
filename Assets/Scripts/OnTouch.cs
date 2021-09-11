using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour
{
    
    public Material startMaterial;
    public Renderer background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTouching()
    {
        Debug.Log("TOUCHING");
        background.material = startMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

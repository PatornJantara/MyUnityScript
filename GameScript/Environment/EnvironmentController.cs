using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    // Start is called before the first frame update

    public Light DirectLight;

    void Start()
    {
        DirectLight.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

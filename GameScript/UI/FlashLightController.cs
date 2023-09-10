using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    public Light flashLight;
    private bool state = true;

    // Start is called before the first frame update
    void Start()
    {
        Toggle();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        state = !state;
        flashLight.enabled = state;
    }
}

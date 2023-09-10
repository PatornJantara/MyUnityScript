using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class Interact : MonoBehaviour
{
    private Rigidbody rb;

    public vThirdPersonInput controller;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Enermy")
        {
            controller.enabled  = false;
            rb.isKinematic      = false;
            transform.position  = transform.position;
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        Destroy(target.gameObject);

    }
}

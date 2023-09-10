using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public float openAngle = 90f;
    public float smoothSpeed = 2f;
    public float interactionDistance = 3f; // Maximum distance at which the player can interact
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isOpen = false;

    private Transform player; // Reference to the player's transform

    public     AudioClip    audioClip;
    public     AudioSource  audioSource;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0f, openAngle, 0f);
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assumes player has the "Player" tag
        gameObject.layer = ((int)MyLayer.MyLayers.Obstruction);

    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);


        // Check if the player is near the door and press the interaction key
        if (distanceToPlayer <= interactionDistance && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }

        if (isOpen)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
            gameObject.layer = ((int)MyLayer.MyLayers.Door);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * smoothSpeed);
            gameObject.layer = ((int)MyLayer.MyLayers.Obstruction);
        }

    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;
        audioSource.PlayOneShot(audioClip);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.tag == "Enermy")
        {
            isOpen = true;
        }

    }
}

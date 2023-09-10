using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PasswordDoorOpen : MonoBehaviour
{
    // Text input
    public InputField inputField;
    public float interactionDistance = 3f; // Distance to consider the player "near"
    private Transform playerPos; // Reference to the player's transform
    private bool inputTextState = false;

    public Text Password;

    public DoorOpen doorOpen;

    // Motion

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    public float openAngle = 90f;
    public float smoothSpeed = 2f;

    private bool bCorrect = false;

    private void Start()
    {
        inputField.gameObject.SetActive(false);

        playerPos = GameObject.FindGameObjectWithTag("Player").transform; // Assumes player has the "Player" tag


        initialRotation = transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0f, openAngle, 0f);

    }

    private void Update()
    {
        if (bCorrect && transform.rotation == targetRotation) return;           

        float distanceToPlayer = Vector3.Distance(transform.position, playerPos.position);

        // Check if the "T" key is pressed
        if (!bCorrect && distanceToPlayer <= interactionDistance && Input.GetKeyDown(KeyCode.E) && !inputTextState)
        {
            // Toggle the visibility of the text input UI
            inputTextState = !inputTextState;
            inputField.gameObject.SetActive(inputTextState);
            inputField.text = "";
            SetInputFieldFocus();

        }

        if ( Input.GetKeyDown(KeyCode.Return) && inputTextState)
        {
            inputTextState = !inputTextState;

            if(inputField.text == Password.text)
            {
                Debug.Log(inputField.text);
                bCorrect = true;
              
            }
          
            inputField.gameObject.SetActive(inputTextState);
        }

        if(bCorrect)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
        }
        
        if (transform.rotation == targetRotation)
        {
            doorOpen.enabled = true;
            enabled = false;
        }



    }

    private void SetInputFieldFocus()
    {
        // Select the input field
        inputField.Select();

        // Activate the input field (show the blinking cursor and open the keyboard)
        inputField.ActivateInputField();
    }

    public bool IsFin()
    {
        return bCorrect;
    }
}

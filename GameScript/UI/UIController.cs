using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pauseScene;

    void Start()
    {
       if(pauseScene != null) pauseScene.gameObject.SetActive(false);
       //LockMouse();
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle Mouse
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleCursorLock();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnLockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    private void ToggleCursorLock()
    {
        // Toggle between locked and unlocked states
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            // If currently locked, unlock and show the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // If currently unlocked, lock the cursor to the center and hide it
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void TogglePause()
    {

        if (Time.timeScale.Equals(1))
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            pauseScene.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            pauseScene.gameObject.SetActive(false);
        }
    }

}

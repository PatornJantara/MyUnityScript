using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public UIController uiController;

    public GameObject tutorInfo;
    public GameObject AboutInfo;


    // Start is called before the first frame update
    void Start()
    {
        if (tutorInfo != null) tutorInfo.gameObject.SetActive(false);
        if (AboutInfo != null) AboutInfo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("StartScene");
        Cursor.lockState = CursorLockMode.None;
    }

    public void TutorButton()
    {
        if (tutorInfo != null) tutorInfo.gameObject.SetActive(true);
    }
    public void AboutButton()
    {
        if (AboutInfo != null) AboutInfo.gameObject.SetActive(true);
    }

    public void BackButton()
    {
        if (tutorInfo != null) tutorInfo.gameObject.SetActive(false);
        if (AboutInfo != null) AboutInfo.gameObject.SetActive(false);
    }

}

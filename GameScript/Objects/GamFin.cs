using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamFin : MonoBehaviour
{
    // Start is called before the first frame update

    public PasswordDoorOpen passDoorOpen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(passDoorOpen!= null)
        {
            if(passDoorOpen.IsFin())
            {
                SceneManager.LoadScene("FinScene");
            }
        }
    }
}

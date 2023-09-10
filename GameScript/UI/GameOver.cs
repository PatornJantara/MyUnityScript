using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public string tagToCheck; // The tag to check for collision
    public SceneController gameOverScreen;

    private void Start()
    {
        gameOverScreen.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToCheck))
        {
            // Perform game over actions, like loading a game over scene
            StartCoroutine(ShowGameOver());
        }
    }



    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(3.0f);

        gameOverScreen.gameObject.SetActive(true);
        gameOverScreen.uiController.UnLockMouse();
    }



}

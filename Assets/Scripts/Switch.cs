using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public string lastSceneName;
    Scene currentScene;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (currentScene.name == lastSceneName)
        {
            ReturnToMainMenu();
        }

        void ReturnToMainMenu()
        {
            // Load the main menu scene
            SceneManager.LoadScene("MainMenu");
        }
    }

}

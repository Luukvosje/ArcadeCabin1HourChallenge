using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public KeyCode continueKey, continueKey02;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(continueKey) || Input.GetKeyDown(continueKey02))
        {
            SceneManager.LoadScene(1);
        }
    }


}

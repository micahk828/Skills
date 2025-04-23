using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1_Room1"); 
    }

    public void OpenLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void OpenMemoryLog()
    {
        SceneManager.LoadScene("MemoryLog");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LoadSystemBoot()
    {
        SceneManager.LoadScene("Level1_Room1"); 
    }

    public void LoadBrokenAxis()
    {
        SceneManager.LoadScene("Level2_Room1");
    }

    public void LoadTimeCheck()
    {
        SceneManager.LoadScene("Level3_Room1");
    }

    public void LoadCoreCollapse()
    {
        SceneManager.LoadScene("FinalLevel");
    }
    public void GoBackHome()
    {
        SceneManager.LoadScene("MainScene");
    }
}

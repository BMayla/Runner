using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelEvents : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

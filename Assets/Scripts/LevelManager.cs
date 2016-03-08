using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int level;

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        level++;
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame requested");
        Application.Quit();
    }
}

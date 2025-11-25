using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonCtrl : MonoBehaviour
{
    public void PlayScene()
    {
        SceneManager.LoadScene("Racing");
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Racing");
        Time.timeScale = 1;
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}

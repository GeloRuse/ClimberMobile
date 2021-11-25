using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    /// <summary>
    /// Перезапустить уровень
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Вернуться на стартовый экран
    /// </summary>
    public void FinishLevel()
    {
        SceneManager.LoadScene(Variables.mainScene);
    }
}

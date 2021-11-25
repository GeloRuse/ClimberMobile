using UnityEngine;
using UnityEngine.UI;

public class LevelTextManager : MonoBehaviour
{
    [SerializeField]
    private Text levelText; //текст уровня
    private int levelNumber; //номер уровня

    private void Start()
    {
        LoadLevelNumber();
        UpdateLevelText();
    }

    /// <summary>
    /// Обновить текст уровня
    /// </summary>
    private void UpdateLevelText()
    {
        levelText.text = "Level " + levelNumber;
    }

    /// <summary>
    /// Увеличить номер уровня
    /// </summary>
    private void IncreaseLevelNumber()
    {
        levelNumber++;
    }

    /// <summary>
    /// Сохранить номер уровня
    /// </summary>
    private void SaveLevelNumber()
    {
        PlayerPrefs.SetInt(Variables.levelSave, levelNumber);
    }

    /// <summary>
    /// Загрузить номер уровня
    /// </summary>
    private void LoadLevelNumber()
    {
        levelNumber = PlayerPrefs.GetInt(Variables.levelSave);
        if (levelNumber <= 0)
            levelNumber = 1;
    }

    /// <summary>
    /// Процедура завершения уровня
    /// </summary>
    public void FinishLevelProcedure()
    {
        IncreaseLevelNumber();
        SaveLevelNumber();
    }
}

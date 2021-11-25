using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private Text coinText; //текст монет
    [SerializeField]
    private GameObject coinsParent; //объект с монетами
    private List<CoinPicker> coins = new List<CoinPicker>(); //монеты на уровне
    private int score; //собранные монеты

    private void Start()
    {
        coins.AddRange(coinsParent.GetComponentsInChildren<CoinPicker>());
        OnEnable();
    }
    private void OnEnable()
    {
        foreach (CoinPicker c in coins)
        {
            c.OnPickup += IncreaseScore;
        }
    }

    private void OnDisable()
    {
        foreach (CoinPicker c in coins)
        {
            c.OnPickup -= IncreaseScore;
        }
    }

    /// <summary>
    /// Увеличить счёт
    /// </summary>
    private void IncreaseScore()
    {
        score++;
        coinText.text = score.ToString();
    }

    /// <summary>
    /// Сохранить собранные монеты
    /// </summary>
    public void SaveCoins()
    {
        PlayerPrefs.SetInt(Variables.coinSave, PlayerPrefs.GetInt(Variables.coinSave) + score);
    }
}

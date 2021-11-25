using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Text coinCount; //текст монет
    [SerializeField]
    private Text priceText; //текст цены

    private int coins; //монеты
    private int price; //цена
    [SerializeField]
    private int defaultPrice = 1; //цена по умолчанию

    private void Start()
    {
        LoadNumbers();
        UpdateCoinsText();
        UpdatePriceText();
    }

    /// <summary>
    /// Запустить уровень
    /// </summary>
    public void LoadLevel()
    {
        SceneManager.LoadScene(Variables.levelScene);
    }

    /// <summary>
    /// Обновить цену
    /// </summary>
    private void UpdatePriceText()
    {
        priceText.text = "Spend coins (" + price + ")";
    }

    /// <summary>
    /// Обновить кол-во монет
    /// </summary>
    private void UpdateCoinsText()
    {
        coinCount.text = coins.ToString();
    }

    /// <summary>
    /// Потратить монеты
    /// </summary>
    public void SpendCoins()
    {
        if (coins > price)
        {
            coins -= price;
            price++;
            UpdateCoinsText();
            UpdatePriceText();
            SaveNumbers();
        }
    }

    /// <summary>
    /// Сохранить монеты и цену
    /// </summary>
    private void SaveNumbers()
    {
        PlayerPrefs.SetInt(Variables.coinSave, coins);
        PlayerPrefs.SetInt(Variables.priceSave, price);
    }

    /// <summary>
    /// Загрузить монеты и цену
    /// </summary>
    private void LoadNumbers()
    {
        coins = PlayerPrefs.GetInt(Variables.coinSave);
        price = PlayerPrefs.GetInt(Variables.priceSave);
        if (price <= 0)
            price = defaultPrice;
    }

    /// <summary>
    /// Удалить весь прогресс
    /// </summary>
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        LoadNumbers();
        UpdateCoinsText();
        UpdatePriceText();
    }
}

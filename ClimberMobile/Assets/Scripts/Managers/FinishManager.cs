using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
    [SerializeField]
    private GoalReachChecker goalScript; //финиш
    [SerializeField]
    private LevelTextManager levelMan; //текст уровня
    [SerializeField]
    private CoinManager coinMan; //монеты
    [SerializeField]
    private CupManager cupMan; //шайбы

    [SerializeField]
    private GameObject finishPanel; //экран завершения уровня

    private void OnEnable()
    {
        goalScript.OnFinish += FinishProcedure;
    }

    private void OnDisable()
    {
        goalScript.OnFinish -= FinishProcedure;
    }

    /// <summary>
    /// Процедура завершения уровня
    /// </summary>
    void FinishProcedure()
    {
        levelMan.FinishLevelProcedure();
        coinMan.SaveCoins();
        cupMan.DisableCups();
        finishPanel.SetActive(true);
    }
}

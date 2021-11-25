using UnityEngine;

public class FailManager : MonoBehaviour
{
    [SerializeField]
    private CupManager cupMan; //шайбы
    [SerializeField]
    private DeathZoneScript deathMan; //зона поражения
    [SerializeField]
    private GameObject failPanel; //экран поражения

    private void OnEnable()
    {
        cupMan.OnFail += FailProcedure;
        deathMan.OnFail += FailProcedure;
    }

    private void OnDisable()
    {
        cupMan.OnFail -= FailProcedure;
        deathMan.OnFail -= FailProcedure;
    }

    /// <summary>
    /// Отключить шайбы и показать экран поражения
    /// </summary>
    private void FailProcedure()
    {
        cupMan.DisableCups();
        failPanel.SetActive(true);
    }
}

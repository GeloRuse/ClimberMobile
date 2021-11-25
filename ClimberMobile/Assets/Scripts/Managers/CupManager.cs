using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CupManager : MonoBehaviour
{
    [SerializeField]
    private HeadLook headScript; //голова
    [SerializeField]
    private GameObject cupsParent; //объект с шайбами
    private List<CupMover> cups = new List<CupMover>(); //шайбы
    [SerializeField]
    private float maxDistance; //максимальное расстояние между шайбами
    private bool isDead; //состояние поражения
    private CupMover curCup; //текущая активная шайба

    public event Action OnFail; //событие поражения

    private void Start()
    {
        cups.AddRange(cupsParent.GetComponentsInChildren<CupMover>());
        OnEnable();
    }

    private void OnEnable()
    {
        foreach(CupMover c in cups)
        {
            c.OnSwitch += SwitchCups;
        }
    }

    private void OnDisable()
    {
        foreach (CupMover c in cups)
        {
            c.OnSwitch -= SwitchCups;
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if(curCup!=null)
                headScript.LookAtCup(curCup);
            CalcBreak();
        }
    }

    /// <summary>
    /// Проверка расстояния между шайбами
    /// </summary>
    private void CalcBreak()
    {
        for (int i = 0; i < cups.Count - 1; i++)
        {
            for (int j = i + 1; j < cups.Count; j++)
            {
                float dist = Vector3.Distance(cups[i].transform.position, cups[j].transform.position);
                cups[i].CalcSlowdown(dist / maxDistance);
                cups[j].CalcSlowdown(dist / maxDistance);
                //если расстояние превышает максимум - сорваться с шайб
                if (dist > maxDistance && (cups[i].CheckActive() || cups[j].CheckActive()))
                {
                    Destroy(cups[i].GetComponent<CharacterJoint>());
                    Destroy(cups[j].GetComponent<CharacterJoint>());
                    isDead = true;
                    OnFail?.Invoke();
                    return;
                }
            }
        }
    }

    /// <summary>
    /// Переключить активную шайбу
    /// </summary>
    /// <param name="cup">шайба</param>
    private void SwitchCups(CupMover cup)
    {
        curCup = cup;
        foreach (CupMover c in cups)
            if (!c.Equals(cup))
            {
                c.SwitchToThis(false);
            }
    }

    /// <summary>
    /// Отключить шайбы
    /// </summary>
    public void DisableCups()
    {
        foreach (CupMover c in cups)
            c.enabled = false;
    }
}

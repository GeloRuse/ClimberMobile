using System;
using System.Collections.Generic;
using UnityEngine;

public class GoalReachChecker : MonoBehaviour
{
    public event Action OnFinish; //событие победы
    private List<GameObject> cupsEntered = new List<GameObject>(); //шайбы, находящиеся на финише

    private void OnTriggerEnter(Collider other)
    {
        if (CheckForCup(other))
        {
            cupsEntered.Add(other.gameObject);
            if(cupsEntered.Count>=2)
                OnFinish?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckForCup(other))
        {
            cupsEntered.Remove(other.gameObject);
        }
    }

    /// <summary>
    /// Проверка коллизии с шайбой
    /// </summary>
    /// <param name="other">объект коллизии</param>
    /// <returns>является ли объект шайбой</returns>
    private bool CheckForCup(Collider other)
    {
        if (!cupsEntered.Contains(other.gameObject)
            && !other.isTrigger
            && other.gameObject.layer.Equals(LayerMask.NameToLayer(Variables.cupLayer)))
            return true;
        else
            return false;
    }
}

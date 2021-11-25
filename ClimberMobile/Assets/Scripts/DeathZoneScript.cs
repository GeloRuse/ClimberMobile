using System;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{
    public event Action OnFail; //событие поражения

    /// <summary>
    /// В случае, если игрок упал за пределы уровня - проигрываем
    /// </summary>
    /// <param name="other">шайба</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer(Variables.cupLayer)))
        {
            OnFail?.Invoke();
        }
    }
}

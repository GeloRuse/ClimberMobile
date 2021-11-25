using System;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    public event Action OnPickup; //событие подбора монеты

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer(Variables.cupLayer)) && !other.isTrigger)
        {
            OnPickup?.Invoke();
            Destroy(gameObject);
        }
    }
}

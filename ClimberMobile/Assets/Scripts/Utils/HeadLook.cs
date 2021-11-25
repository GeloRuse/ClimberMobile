using UnityEngine;

public class HeadLook : MonoBehaviour
{
    [SerializeField]
    private Transform head; //голова

    /// <summary>
    /// Направить голову в сторону активной шайбы
    /// </summary>
    /// <param name="cup">шайба</param>
    public void LookAtCup(CupMover cup)
    {
        head.LookAt(cup.transform);
    }
}

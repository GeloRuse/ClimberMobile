using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CupMover : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Rigidbody rigidBody; //компонент RigidBody

    public event Action<CupMover> OnSwitch; //событие выбора активной шайбы
    [SerializeField]
    private InputManager inputManager; //менеджер управления
    private bool isMoving; //состояние движения
    private bool isActive; //состояние активной шайбы

    [SerializeField]
    private float speed; //скорость движения шайбы
    [SerializeField]
    private float maxSpeed; //максимальная скорость 
    [SerializeField]
    private float minSpeed; //минимальная скорость

    private float slowdown = 1; //степень замедления

    private void OnEnable()
    {
        inputManager.OnStartTouch += StartMove;
        inputManager.OnEndTouch += CancelMove;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= StartMove;
        inputManager.OnEndTouch -= CancelMove;
    }

    private void StartMove()
    {
        isMoving = true;
    }

    private void CancelMove()
    {
        isMoving = false;
        SwitchToThis(false);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isActive && isMoving)
        {
            Move();
        }
    }

    /// <summary>
    /// Движение шайбы
    /// </summary>
    private void Move()
    {
        Vector3 target = inputManager.PrimaryPosition();
        if (speed * slowdown < minSpeed)
            speed = minSpeed;
        else if (speed * slowdown > maxSpeed)
            speed = maxSpeed;
        else
            speed = speed * slowdown;
        rigidBody.AddForce((target - transform.position).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    /// <summary>
    /// Вычисление степени замедления
    /// </summary>
    /// <param name="number"></param>
    public void CalcSlowdown(float number)
    {
        slowdown = Variables.speedRate - number;
    }

    public void SwitchToThis(bool activate)
    {
        isActive = activate;
    }

    public bool CheckActive()
    {
        return isActive;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SwitchToThis(true);
        OnSwitch?.Invoke(this);
    }
}

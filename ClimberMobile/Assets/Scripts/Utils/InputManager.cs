using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void StartTouch(); //начало нажатия
    public event StartTouch OnStartTouch; //событие начала нажатия
    public delegate void EndTouch(); //прекращение нажатия
    public event EndTouch OnEndTouch; //событие прекращения нажатия

    private NewControls playerControls; //управление
    public Camera mainCamera; //основная камера

    private void Awake()
    {
        //назначение управления и камеры
        playerControls = new NewControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        playerControls.Touch.PrimaryContact.started += _ => StartTouchPrimary();
        playerControls.Touch.PrimaryContact.canceled += _ => EndTouchPrimary();
    }

    private void StartTouchPrimary()
    {
        if (OnStartTouch != null) OnStartTouch();
    }

    private void EndTouchPrimary()
    {
        if (OnEndTouch != null) OnEndTouch();
    }

    /// <summary>
    /// Метод определения места нажатия
    /// </summary>
    /// <returns>место нажатия в координатах</returns>
    public Vector2 PrimaryPosition()
    {
        return CamConverter.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}

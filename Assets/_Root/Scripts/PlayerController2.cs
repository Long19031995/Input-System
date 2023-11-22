using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    PlayerControls controls;
    Vector2 move;
    public float speed = 10;

    private void Awake()
    {
        controls = new PlayerControls();
        // controls.Player.Buttons.performed += context => SendMessage();
        controls.Player.Move.performed += context => move = context.ReadValue<Vector2>();
        controls.Player.Move.canceled += context => move = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
}

using Assets.Scripts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    #region Config
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] MotorController motorController;
    [SerializeField] BuoyancyController buoyancyController;
    #endregion

    void Update()
    {
        Move();
    }

    void Move()
    {
        HorizontalMovement();
        BuoyancyChanging();
    }

    private void HorizontalMovement()
    {
        HandleGear();
        float xMovement = motorController.CurrentGear.Speed * Time.deltaTime;
        if (!spriteRenderer.flipX)
        {
            xMovement *= -1;
        }
        Vector2 oldVelocity = rigidbody.velocity;
        rigidbody.velocity = new Vector2(oldVelocity.x + xMovement, oldVelocity.y);
    }

    private void HandleGear()
    {
        MotorGear newGear;
        if (Input.GetButtonDown("Stop Submarine"))
        {
            motorController.TrySetNeutralGear();
        }
        else
        {
            int gearOffset = (int)Input.GetAxisRaw("Motor Gears");
            motorController.TryChangeGear(gearOffset);
        }
    }

    private void BuoyancyChanging()
    {
        BuoyancyGear newGear;
        if (Input.GetButtonDown("Stop Submarine"))
        {
            buoyancyController.TrySetNeutralGear();
        }
        else
        {
            int gearOffset = (int)Input.GetAxisRaw("Buoyancy Gears");
            buoyancyController.TryChangeGear(gearOffset);
        }

        rigidbody.gravityScale = buoyancyController.CurrentGear.Buoyancy;
    }

}

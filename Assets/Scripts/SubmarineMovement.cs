using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Gear
{
    public int Number;
    public float Speed;
}

public class SubmarineMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float gearDelay = 1f;
    [SerializeField]
    List<Gear> gears = new() {
        new Gear { Number = -1, Speed = -0.5f },
        new Gear { Number = 0, Speed = 0f },
        new Gear { Number = 1, Speed = 1f },
        new Gear { Number = 2, Speed = 1.5f },
    };
    [SerializeField] float gravityChangingSpeed = 0.7f;
    [SerializeField] float maxGravity = 0.2f;
    [SerializeField] float minGravity = -0.2f;

    Gear currentGear;
    int minGearNumber;
    int maxGearNumber;
    float gearDelayCounter = 0f;

    private void Start()
    {
        currentGear = gears.FirstOrDefault(g => g.Number == 0);
        minGearNumber = gears.Min(g => g.Number);
        maxGearNumber = gears.Max(g => g.Number);
    }

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

        float xMovement = currentGear.Speed * Time.deltaTime;
        if (!spriteRenderer.flipX)
        {
            xMovement *= -1;
        }
        Vector2 oldVelocity = rigidbody.velocity;
        rigidbody.velocity = new Vector2(oldVelocity.x + xMovement, oldVelocity.y);
    }

    private void HandleGear()
    {
        int gearOffset = -(int)Input.GetAxisRaw("Horizontal");
        int newGearNumber = currentGear.Number + gearOffset;
        newGearNumber = Mathf.Max(newGearNumber, minGearNumber);
        newGearNumber = Mathf.Min(newGearNumber, maxGearNumber);
        if (newGearNumber != currentGear.Number)
        {
            TryChangeGear(newGearNumber);
        }
        gearDelayCounter -= Time.deltaTime;
    }

    private void TryChangeGear(int newGearNumber)
    {
        if (gearDelayCounter <= 0)
        {
            currentGear = gears.FirstOrDefault(g => g.Number == newGearNumber);
            gearDelayCounter = gearDelay;
            Debug.Log($"Gear: {currentGear.Number}");
        }
    }

    private void BuoyancyChanging()
    {
        float yAxle = -Input.GetAxis("Vertical");
        float gravityOffset = yAxle * gravityChangingSpeed * Time.deltaTime;
        float newGravity = rigidbody.gravityScale + gravityOffset;
        newGravity = Mathf.Max(newGravity, minGravity);
        newGravity = Mathf.Min(newGravity, maxGravity);
        rigidbody.gravityScale = newGravity;
    }
}

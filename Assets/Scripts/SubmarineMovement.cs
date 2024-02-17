using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float xSpeed = 10f;
    [SerializeField] float gravityChangingSpeed = 0.7f;
    [SerializeField] float maxGravity = 0.2f;
    [SerializeField] float minGravity = -0.2f;

    [SerializeField] float xVelocityOffset = 0;

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
        float xAxle = Input.GetAxis("Horizontal");
        if (true ||Input.GetAxisRaw("Horizontal") != 0)
        {
            xVelocityOffset = xAxle;
        }
        float xMovement = xVelocityOffset * xSpeed * Time.deltaTime;
        Vector2 oldVelocity = rigidbody.velocity;
        rigidbody.velocity = new Vector2(oldVelocity.x + xMovement, oldVelocity.y);
        Debug.Log($"X Velocity: {rigidbody.velocity.x}");
    }

    private void BuoyancyChanging()
    {
        float yAxle = -Input.GetAxis("Vertical");
        float gravityOffset = yAxle * gravityChangingSpeed * Time.deltaTime;
        float newGravity = rigidbody.gravityScale + gravityOffset;
        newGravity = Mathf.Max(newGravity, minGravity);
        newGravity = Mathf.Min(newGravity, maxGravity);
        rigidbody.gravityScale = newGravity;
        Debug.Log($"Buoyancy: {rigidbody.gravityScale}");
    }
}

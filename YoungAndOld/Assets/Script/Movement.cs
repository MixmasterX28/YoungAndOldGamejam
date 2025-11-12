using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float WalkSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * WalkSpeed, rb.linearVelocity.y);
    }
}

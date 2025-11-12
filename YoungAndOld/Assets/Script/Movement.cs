using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float WalkSpeed = 5f;
    private Rigidbody2D rb;

    public KeyCode leftkey = KeyCode.A;
    public KeyCode rightkey = KeyCode.B;

    private float moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = 0f;
        
        if (Input.GetKey(leftkey))
            moveInput = -1f;
        else if (Input.GetKey(rightkey))
            moveInput = 1f;

        rb.linearVelocity = new Vector2(moveInput * WalkSpeed, rb.linearVelocity.y);

        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}

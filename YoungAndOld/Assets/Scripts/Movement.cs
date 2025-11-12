using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float WalkSpeed = 5f;
    private Rigidbody2D rb;

    private RogueDash RogueDashScript;

    public KeyCode leftkey = KeyCode.A;
    public KeyCode rightkey = KeyCode.D;

    private float moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RogueDashScript = rb.GetComponent<RogueDash>();
    }

    void Update()
    {

        moveInput = 0f;
        
        if (Input.GetKey(leftkey))
            moveInput = -1f;
        else if (Input.GetKey(rightkey))
            moveInput = 1f;

        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void FixedUpdate()
    {
        if (RogueDashScript != null && RogueDashScript.DashingIni)
            return;

        rb.linearVelocity = new Vector2(moveInput * WalkSpeed, rb.linearVelocity.y);
    }
}

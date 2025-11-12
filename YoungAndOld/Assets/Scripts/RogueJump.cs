
using UnityEngine;

public class RogueJump : MonoBehaviour
{
    [SerializeField] Vector2 boxSize;
    [SerializeField] float castDistance;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpForce;
    bool hasDoubleJumped;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (GroundedCheck())
        {
            hasDoubleJumped = false;
            GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, jumpForce, 0);
            return;
        }

        if (hasDoubleJumped)
            return;

        GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, jumpForce ,0);
        hasDoubleJumped = true;
    }

    public bool GroundedCheck()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
            return true;

        else 
            return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}

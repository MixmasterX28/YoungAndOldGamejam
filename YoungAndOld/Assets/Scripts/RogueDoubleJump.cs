using UnityEditor.ShaderGraph;
using UnityEngine;

public class RogueDoubleJump : MonoBehaviour
{
    [SerializeField] Vector2 boxSize;
    [SerializeField] float castDistance;
    [SerializeField] LayerMask groundLayer;
    bool hasDoubleJumped;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (GroundedCheck())
        {
            hasDoubleJumped = false;
            GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, 5f, 0);
            return;
        }

        if (hasDoubleJumped)
            return;

        GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, 5f ,0);
        hasDoubleJumped = true;
    }

    bool GroundedCheck()
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

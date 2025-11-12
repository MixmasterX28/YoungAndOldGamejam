
using System.Collections;
using UnityEngine;

public class RogueDash : MonoBehaviour
{
    [SerializeField] RogueJump rogueJump;
    Rigidbody2D rigidbody;
    TrailRenderer trailRenderer;
    [SerializeField] float dashingSpeed;
    [SerializeField] float dashingTime;
    bool isDashing;
    bool hasDashed;
    public bool DashingIni => isDashing;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            StartCoroutine(Dash());


        if (rogueJump.GroundedCheck())
        {
            hasDashed = false;
        }
    }

    IEnumerator Dash()
    {
        if (isDashing)
            yield break;

        if (hasDashed)
            yield break;

        hasDashed = true;
        isDashing = true;
        float originalGravity = rigidbody.gravityScale;
        rigidbody.gravityScale = 0;
        trailRenderer.emitting = true;
        Debug.Log(transform.localScale.x);
        Debug.Log(dashingSpeed);
        rigidbody.linearVelocity = new Vector2(transform.localScale.x * dashingSpeed, 0f);
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        trailRenderer.emitting = false;
        rigidbody.linearVelocity = Vector2.zero;
        rigidbody.gravityScale = originalGravity;

        yield break;
    }
}

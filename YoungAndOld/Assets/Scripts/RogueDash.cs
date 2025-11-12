
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RogueDash : MonoBehaviour
{
    Rigidbody2D rigidbody;
    TrailRenderer trailRenderer;
    [SerializeField] float dashingSpeed;
    [SerializeField] float dashingTime;
    bool canDash;
    bool hasDashed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            StartCoroutine(Dash());

        if (Input.GetKeyDown(KeyCode.Z))
            transform.Rotate(new Vector3(0, 180, 0));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canDash = true;
            hasDashed = false;
        }
    }

    IEnumerator Dash()
    {
        if (!canDash)
            yield break;

        if (hasDashed)
            yield break;

        hasDashed = true;
        float originalGravity = rigidbody.gravityScale;
        rigidbody.gravityScale = 0;
        trailRenderer.emitting = true;
        rigidbody.AddForce(new Vector2(transform.localScale.x * transform.right.x * dashingSpeed, 0f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rigidbody.linearVelocity = Vector2.zero;
        rigidbody.gravityScale = originalGravity;

        yield break;
    }
}

using UnityEngine;

public class PlaceholderMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody.linearVelocityX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space))
            rigidbody.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
    }
}

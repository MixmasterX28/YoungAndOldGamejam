using UnityEngine;

public class EndDoor : MonoBehaviour
{
    byte playersAtDoor;

    private void FixedUpdate()
    {
        if (playersAtDoor == 2)
        {
            Debug.Log("winner");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersAtDoor += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersAtDoor -= 1;
        }
    }
}

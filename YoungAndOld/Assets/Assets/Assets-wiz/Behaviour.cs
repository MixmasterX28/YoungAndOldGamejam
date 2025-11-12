using Unity.VisualScripting;
using UnityEngine;

public class PLatform : MonoBehaviour
{

    [SerializeField] private bool move = true;
    [SerializeField] private float speed = 4f;
    [SerializeField] private Vector2 targetPosition;
    public float timer;
    private Vector2 initialPosititon;

    
    void Start()
    {
        initialPosititon = transform.position;

    }

    void Update()
    {
        if (move)
        {

        }
    }
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if (timer > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosititon, Time.deltaTime * speed);
        }
    }
}


using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    List<GameObject> doors = new List<GameObject>();
    [SerializeField] bool keepOpen;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            doors.Add(child.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject go in doors)
        {
            go.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (keepOpen)
            return;

        foreach (GameObject go in doors)
        {
            go.SetActive(true);
        }
    }
}

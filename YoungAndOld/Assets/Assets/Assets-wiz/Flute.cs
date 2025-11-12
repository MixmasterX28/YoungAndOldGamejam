using Unity.VisualScripting;
using UnityEngine;

public class Flute : MonoBehaviour
{

    private float eooeoe;
    private bool active = true;

    public bool note1 = false;
    public bool note2 { get; private set; } = false;
    public bool note3 { get; private set; } = false;
    public bool note4 { get; private set; } = false;

    [SerializeField] private PLatform behaviour;
    bool toggle;



    void Start()
    {
        
    }
    void Update()
    {

        if (active) 
        { 
            CheckInput(); 

            if (note1) {}
            if (note2) {}
            if (note3) {}
            if (note4) {}
        }
    }
        
    private void CheckInput()
    {

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (toggle)
            {
                behaviour.timer = 0.25f;
                toggle = false;
            }
        }
        else
        {
            note1 = false;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            if (!toggle)
            {
                behaviour.timer = 0.25f;
                toggle = true;
            }
        }
        else
        {
            note2 = false;
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            note3 = true;
        }
        else
        {
            note3 = false;
        }

        if (Input.GetKeyUp(KeyCode.Y))
        {
            note4 = true;
        }
        else
        {
            note4 = false;
        }
    }
}

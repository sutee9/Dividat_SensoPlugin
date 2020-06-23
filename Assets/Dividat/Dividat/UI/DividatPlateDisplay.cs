using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dividat;

public class DividatPlateDisplay : MonoBehaviour
{
    public Dividat.Direction plate;
    private Text field;
    private bool step;
    // Start is called before the first frame update
    void Start()
    {
        field = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        Plate p = Dividat.Hardware.GetPlateState(plate);
        if (Dividat.Hardware.GetStep(plate))
        {
            step = true;
        }
        if (Dividat.Hardware.GetRelease(plate))
        {
            step = false;              
        }
        field.text = "(" + System.Math.Round(p.x, 2) + ", " + System.Math.Round(p.y, 2) + ")\nf=" + System.Math.Round(p.f, 2) + "\n" + (step ? "In Step" : "");
    }
}
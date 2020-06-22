using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOn : MonoBehaviour
{
    Toggle myToggle;

    //If need to add more objects, add them publicly here and place the appropriate object in the Inspector (Cont'd)
    //For the approprate Toggle.

    // Start is called before the first frame update
    void Start()
    {
        myToggle = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myToggle.isOn)
        {
            //Inset Action(s) Here
        }
    }
}

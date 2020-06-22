using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MasterSlider : MonoBehaviour
{

    ToggleGroup group;
    Toggle[] toggles;


    public Slider masterSlider;

    public Item[] items;

    public Toggle currentToggle
    {
        get { return group.ActiveToggles().FirstOrDefault(); }
    }

    float previousValue;
    // Start is called before the first frame update
    void Start()
    {
        group = GetComponent<ToggleGroup>();
        toggles = group.GetComponentsInChildren<Toggle>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(previousValue != masterSlider.value)
        {
            
            runMath();
            previousValue = masterSlider.value;
        }
    }

    void runMath()
    {
        if (currentToggle == toggles[0])
        {
            Debug.Log("Changing values of one");
            items[0].health = (int)Mathf.Floor(Mathf.Pow(masterSlider.value, 1.4f));
            items[0].strength = (int)Mathf.Floor(masterSlider.value * 1.2f + 3f);
            items[0].speed = (int)masterSlider.value;
            items[0].defense = (int)0f;
        }
        else if(currentToggle == toggles[1])
        {
            items[1].health = (int)0f;
            items[1].strength = (int)(masterSlider.value / 2f);
            items[1].speed = (int)Mathf.Floor(Mathf.Pow(masterSlider.value, 1.3f));
            items[1].defense = (int)Mathf.Floor(Mathf.Log(masterSlider.value, 1.4f));
        }
        else if(currentToggle == toggles[2])
        {
            items[2].health = (int)(masterSlider.value * 1.6f);
            items[2].strength = (int)Mathf.Floor(masterSlider.value / 3f);
            items[2].speed = 0;
            items[2].defense = (int)Mathf.Floor(Mathf.Pow(masterSlider.value, 2.1f));
        }
        else if(currentToggle == toggles[3])
        {
            items[3].health = (int)(masterSlider.value * 0.75f);
            items[3].strength = 0;
            items[3].speed = (int)(masterSlider.value * 1.25f);
            items[3].defense = 0;
        }
        else
        {
            /*
            items[0].health = 0;
            items[1].strength = 0;
            items[2].speed = 0;
            items[3].defense = 0;
            */
        }

    }
}

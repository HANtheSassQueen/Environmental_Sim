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

    private Toggle previousToggle;

    public Item currentItem
    {
        get {
            if(currentToggle == toggles[0])
            {
                return items[0];
            }
            else if(currentToggle == toggles[1])
            {
                return items[1];
            }
            else if(currentToggle == toggles[2])
            {
                return items[2];
            }
            else if(currentToggle == toggles[3])
            {
                return items[3];
            }
            else
            {
                return items[0];
            }
        }
    }

    private Item previousItem;

    //float previousValue;
    // Start is called before the first frame update
    void Start()
    {
        group = GetComponent<ToggleGroup>();
        toggles = group.GetComponentsInChildren<Toggle>();

        previousToggle = currentToggle;
        previousItem = currentItem;

        items[0].masterValue = 0;
        calcItemOne();
        items[1].masterValue = 0;
        calcItemTwo();
        items[2].masterValue = 0;
        calcItemThree();
        items[3].masterValue = 0;
        calcItemFour();
    }

    // Update is called once per frame
    void Update()
    {
        if (previousToggle != currentToggle)
        {
            
            changeToggle();
            //Debug.Log("Value of Master Slider: " + masterSlider.value);
        }

        if (currentItem.masterValue != masterSlider.value)
        {
            
            runMath();
            Debug.Log("Value of Master Slider: " + masterSlider.value);
        }

        
        

        
    }

    void runMath()
    {
        if (currentToggle == toggles[0])
        {
            //Debug.Log("Changing values of one");
            items[0].masterValue = (int)masterSlider.value;
            items[0].previousValue = items[0].masterValue;
            calcItemOne();

            items[1].masterValue = (int)(items[1].masterValue * 0.85);
            calcItemTwo();
            items[2].masterValue = (int)(items[2].masterValue * 0.75);
            calcItemThree();
            items[3].masterValue = (int)(items[3].masterValue * 0.65);
            calcItemFour();
        }
        else if(currentToggle == toggles[1])
        {
            items[1].masterValue = (int)masterSlider.value;
            items[1].previousValue = items[1].masterValue;
            calcItemTwo();

            items[0].masterValue = (int)(items[0].masterValue * 1.15);
            calcItemOne();
            items[2].masterValue = (int)(items[2].masterValue * 0.55);
            calcItemThree();
            items[3].masterValue = (int)(items[3].masterValue * 1.25);
            calcItemFour();
        }
        else if(currentToggle == toggles[2])
        {
            items[2].masterValue = (int)masterSlider.value;
            items[2].previousValue = items[2].masterValue;
            calcItemThree();

            items[1].masterValue = (int)(items[1].masterValue * 1.5);
            calcItemTwo();
            items[0].masterValue = (int)(items[0].masterValue * 0.45);
            calcItemOne();
            items[3].masterValue = (int)(items[3].masterValue * 0.1);
            calcItemFour();
        }
        else if(currentToggle == toggles[3])
        {
            items[3].masterValue = (int)masterSlider.value;
            items[3].previousValue = items[3].masterValue;
            calcItemFour();

            items[1].masterValue = (int)(items[1].masterValue * 0.7);
            calcItemTwo();
            items[0].masterValue = (int)(items[0].masterValue * 1.1);
            calcItemOne();
            items[2].masterValue = (int)(items[2].masterValue * 0.9);
            calcItemThree();
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

    void changeToggle()
    {
        Debug.Log("Master Slider Value Before: " + masterSlider.value);
        masterSlider.value = currentItem.masterValue;
        Debug.Log("Master Slider Value After: " + masterSlider.value);

        previousToggle = currentToggle;
        previousItem = currentItem;
        
    }

    void calcItemOne()
    {
        items[0].health = (int)Mathf.Floor(Mathf.Pow(items[0].masterValue, 1.4f));
        items[0].strength = (int)Mathf.Floor(items[0].masterValue * 1.2f + 3f);
        items[0].speed = (int)items[0].masterValue;
        items[0].defense = 0;
        
    }

    void calcItemTwo()
    {
        items[1].health = 0;
        items[1].strength = (int)(items[1].masterValue / 2f);
        items[1].speed = (int)Mathf.Floor(Mathf.Pow(items[1].masterValue, 1.3f));
        items[1].defense = (int)Mathf.Floor(Mathf.Log(items[1].masterValue, 1.4f));
        
    }

    void calcItemThree()
    {
        items[2].health = (int)(items[2].masterValue * 1.6f);
        items[2].strength = (int)Mathf.Floor(items[2].masterValue / 3f);
        items[2].speed = 0;
        items[2].defense = (int)Mathf.Floor(Mathf.Pow(items[2].masterValue, 2.1f));
        
    }

    void calcItemFour()
    {
        items[3].health = (int)(items[3].masterValue * 0.75f);
        items[3].strength = 0;
        items[3].speed = (int)(items[3].masterValue * 1.25f);
        items[3].defense = 0;
        
    }
}

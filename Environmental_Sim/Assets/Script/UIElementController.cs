using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class UIElementController : MonoBehaviour
{
    // Start is called before the first frame update

    //Public 
    public ToggleGroup toggleGroup;
    public GameObject icon;

    //Private
    private Toggle myToggle;
    private Image displayImage;

    //If need to add more objects, add them publicly here and place the appropriate object in the Inspector (Cont'd)
    //For the approprate Toggle.

    // Start is called before the first frame update
    void Start()
    {
        //Get selected toggle
        myToggle = toggleGroup.ActiveToggles().FirstOrDefault();
        displayImage = icon.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // get selected toggle on each update
        myToggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if (myToggle.isOn)
        {
            //Inset Action(s) Here

            //Find Icon game object in selected toggle
            GameObject icon = myToggle.transform.Find("Icon").gameObject;

            myToggle.GetComponent<ItemDisplay>().UpdateCanvas();
            
            // If find icon
            if(icon != null)
            {
                // get sprite from the selected icon
                Sprite selectSprite = icon.GetComponent<Image>().sprite;

                //  apply it to display image
                displayImage.sprite = selectSprite;
            }

        }
    }


}

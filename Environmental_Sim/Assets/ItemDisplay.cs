using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{

    public Item item;

    public Slider healthSlider;
    public Slider strengthSlider;
    public Slider speedSlider;
    public Slider defenseSlider;
    public Text description;
    public Text itemName;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCanvas()
    {
        healthSlider.value = item.health;
        strengthSlider.value = item.strength;
        speedSlider.value = item.speed;
        defenseSlider.value = item.defense;
        description.text = item.description;
        itemName.text = item.itemName;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Item",menuName = "Item")]
public class Item : ScriptableObject
{

    public string itemName;
    public string description;
    public int masterValue;
    public int previousValue;
    public int health;
    public int strength;
    public int speed;
    public int defense;

}

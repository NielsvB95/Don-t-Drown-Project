using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableInventory
{
    //Resources
    public int Wood { get; set; }
    public int Grass { get; set; }
    public int Stone { get; set; }
    public int Pebble { get; set; }
    public int Iron { get; set; }
    public int Straw { get; set; }
    public int Stick { get; set; }
    public int Flower { get; set; }
    public int Mushroom { get; set; }
    public int Gemstone { get; set; }

    //Potions
    public int EndurancePotion { get; set; }
    public int IntelligencePotion { get; set; }
    public int GatheringPotion { get; set; }
    public int WisdomPotion { get; set; }

    //Tools
    public bool Axe { get; set; }
    public bool Pickaxe { get; set; }
    public bool Pitchfork { get; set; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
        
    //Resources
    public static int Wood { get; set; }
    public static int Grass { get; set; }
    public static int Stone { get; set; }
    public static int Pebble{ get; set; }
    public static int Iron{ get; set; }
    public static int Straw { get; set; }
    public static int Stick{ get; set; }
    public static int Flower{ get; set; }
    public static int Mushroom{ get; set; }
    public static int Gemstone{ get; set; }

    //Potions
    public static int EndurancePotion { get; set; }
    public static int IntelligencePotion { get; set; }
    public static int GatheringPotion { get; set; }
    public static int WisdomPotion { get; set; }

    //Tools
    public static bool Axe { get; set; }
    public static bool Pitchfork { get; set; }
    public static bool Pickaxe { get; set; }
}

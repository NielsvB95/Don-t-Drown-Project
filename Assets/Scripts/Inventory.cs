using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static int wood, clay, stone, iron, straw, stick, mushroom, flower;
    public static bool axe, pitchfork, pickaxe;

    public static int Wood
    {
        get
        {
            return wood;
        }
        set
        {
            wood = value;
        }
    }

    public static int Clay
    {
        get
        {
            return clay;
        }
        set
        {
            clay = value;
        }
    }

    public static int Stone
    {
        get
        {
            return stone;
        }
        set
        {
            stone = value;
        }
    }

    public static int Iron
    {
        get
        {
            return iron;
        }
        set
        {
            iron = value;
        }
    }

    public static int Straw
    {
        get
        {
            return straw;
        }
        set
        {
            straw = value;
        }
    }

    public static int Stick
    {
        get
        {
            return stick;
        }
        set
        {
            stick = value;
        }
    }

    public static int Flower
    {
        get
        {
            return flower;
        }
        set
        {
            flower = value;
        }
    }

    public static int Mushroom
    {
        get
        {
            return mushroom;
        }
        set
        {
            mushroom = value;
        }
    }

    public static bool Axe
    {
        get
        {
            return axe;
        }
        set
        {
            axe = value;
        }
    }

    public static bool Pitchfork
    {
        get
        {
            return pitchfork;
        }
        set
        {
            pitchfork = value;
        }
    }

    public static bool Pickaxe
    {
        get
        {
            return pickaxe;
        }
        set
        {
            pickaxe = value;
        }
    }
}

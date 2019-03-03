using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseModel
{
    public int Stick { get; set; }
    public int Straw { get; set; }
    public int Clay { get; set; }
    public int Stone { get; set; }
    public int Iron { get; set; }
    public int Wood { get; set; }
    public int Pebble { get; set; }

    public static HouseModel houseModel_2 = new HouseModel()
    {
        Stick = 3,
        Straw = 5
    };

    public static HouseModel houseModel_3 = new HouseModel()
    {
        Stick = 5,
        Straw = 8
    };
    public static HouseModel houseModel_4 = new HouseModel()
    {
        Stick = 2,
        Straw = 5,
        Wood = 5
    };
    public static HouseModel houseModel_5 = new HouseModel()
    {
        Stick = 2,
        Straw = 2,
        Wood = 5,
        Clay = 5
    };
    public static HouseModel houseModel_6 = new HouseModel()
    {
        Wood = 5,
        Clay = 5,
        Stone = 2
    };
    public static HouseModel houseModel_7 = new HouseModel()
    {
        Wood = 8,
        Clay = 2,
        Stone = 5
    };
    public static HouseModel houseModel_8 = new HouseModel()
    {
        Wood = 5,
        Iron = 2,
        Stone = 5
    };
}

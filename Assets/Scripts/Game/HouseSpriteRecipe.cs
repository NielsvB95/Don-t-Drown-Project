using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HouseSpriteRecipe
{
    public Sprite HouseImage;
    public HouseModel HouseModel;
    public int House_id;
    
    public static HouseSpriteRecipe House_1 = new HouseSpriteRecipe()
    {
        House_id = 1,
        HouseImage = null,
        HouseModel = null
    };
    public static HouseSpriteRecipe House_2 = new HouseSpriteRecipe()
    {
        House_id = 2,
        HouseImage = null,
        HouseModel = HouseModel.houseModel_2
    };
    public static HouseSpriteRecipe House_3 = new HouseSpriteRecipe()
    {
        House_id = 3,
        HouseImage = null,
        HouseModel = HouseModel.houseModel_3
    };
    public static HouseSpriteRecipe House_4 = new HouseSpriteRecipe()
    {
        House_id = 4,
        HouseImage = null,
        HouseModel = HouseModel.houseModel_4
    };
    public static HouseSpriteRecipe House_5 = new HouseSpriteRecipe()
    {
        House_id = 5,
        HouseImage = null,
        HouseModel = HouseModel.houseModel_5
    };
    public static HouseSpriteRecipe House_6 = new HouseSpriteRecipe()
    {
        House_id = 6,
        HouseImage = null,
        HouseModel = HouseModel.houseModel_6
    };
    public static HouseSpriteRecipe House_7 = new HouseSpriteRecipe()
    {
        House_id = 7,
        HouseImage = null,
        HouseModel = HouseModel.houseModel_7
    };
    public static HouseSpriteRecipe House_8 = new HouseSpriteRecipe()
    {
        House_id = 8,
        HouseImage = null,
        HouseModel = HouseModel.houseModel_8
    };
}

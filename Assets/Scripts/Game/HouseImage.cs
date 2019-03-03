using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseImage : MonoBehaviour
{
    public Sprite House_1;
    public Sprite House_2;
    public Sprite House_3;
    public Sprite House_4;
    public Sprite House_5;
    public Sprite House_6;
    public Sprite House_7;
    public Sprite House_8;

    private void Start()
    {
        SetSprites();
        Debug.Log("SetSprites called");
    }

    public static Sprite image;

    public void SetSprites()
    {
        HouseSpriteRecipe.House_1.HouseImage = House_1;
        HouseSpriteRecipe.House_2.HouseImage = House_2;
        HouseSpriteRecipe.House_3.HouseImage = House_3;
        HouseSpriteRecipe.House_4.HouseImage = House_4;
        HouseSpriteRecipe.House_5.HouseImage = House_5;
        HouseSpriteRecipe.House_6.HouseImage = House_6;
        HouseSpriteRecipe.House_7.HouseImage = House_7;
        HouseSpriteRecipe.House_8.HouseImage = House_8;
    }
}

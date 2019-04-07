using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableSaveData
{
    public int Level { get; set; }
    public bool LevelUp { get; set; }
    public bool Request { get; set; }
    public int WisdomLevel { get; set; }
    public int MushroomSpawn { get; set; }
    public SerializableInventory Inventory { get; set; }
}

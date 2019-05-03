using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableSaveData
{
    public int Level { get; set; }
    public bool LevelUp { get; set; }
    public bool Request { get; set; }
    public int EnduranceLevel { get; set; }
    public int IntelligenceLevel { get; set; }
    public int GatheringLevel { get; set; }
    public int WisdomLevel { get; set; }
    public int FlowerSpawn { get; set; }
    public int GemstoneSpawn { get; set; }
    public int MushroomSpawn { get; set; }
    public SerializableInventory Inventory { get; set; }
}

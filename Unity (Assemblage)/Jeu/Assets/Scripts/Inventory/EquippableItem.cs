using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Casque,
    Poitrine,
    Gants,
    Bottes,
    Arme1,
    Arme2,
    Accessoire1,
    Accessoire2,
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int ForceBonus;
    public int AgiliteBonus;
    public int IntelligenceBonus;
    public int VitaliteBonus;
    [Space]
    public float ForcePercentBonus;
    public float AgilitePercentBonus;
    public float IntelligencePercentBonus;
    public float VitalitePercentBonus;
    [Space]
    public EquipmentType equipmentType;
}


public class EquipmentSlot : ItemSlot
{
    public EquipmentType equipmentType;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = equipmentType.ToString() + " Slot";
    }
}

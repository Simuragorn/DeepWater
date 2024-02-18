using Assets.Scripts.Classes;

public class MotorController : GearsController<MotorGear>
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void TrySetGear(int newGearNumber)
    {
        base.TrySetGear(newGearNumber);
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void SetGearText()
    {
        currentGearText.text = $"Motor Gear: {CurrentGear.GetName()}";
    }
}

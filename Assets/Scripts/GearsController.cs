using Assets.Scripts.Classes;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public abstract class GearsController<GearType> : MonoBehaviour where GearType : Gear
{
    #region Config
    [SerializeField] protected TextMeshProUGUI currentGearText;
    [Range(0.1f, 1.5f)]
    [SerializeField] protected float gearDelay = 1f;
    [SerializeField] protected List<GearType> gears;
    #endregion

    public GearType CurrentGear { private set; get; }
    protected int minGearNumber;
    protected int maxGearNumber;
    protected float gearDelayCounter = 0f;


    protected virtual void Start()
    {
        TrySetNeutralGear();
        minGearNumber = gears.Min(g => g.Number);
        maxGearNumber = gears.Max(g => g.Number);
    }

    public void TrySetNeutralGear()
    {
        TrySetGear(MotorGear.NeutralGearNumber);
    }

    public void TryChangeGear(int gearOffset)
    {
        int newGearNumber = CurrentGear.Number + gearOffset;
        newGearNumber = Mathf.Max(newGearNumber, minGearNumber);
        newGearNumber = Mathf.Min(newGearNumber, maxGearNumber);
        TrySetGear(newGearNumber);
    }

    protected virtual void TrySetGear(int newGearNumber)
    {
        if (gearDelayCounter <= 0)
        {
            if (CurrentGear != null && newGearNumber == CurrentGear.Number)
            {
                return;
            }
            CurrentGear = gears.First(g => g.Number == newGearNumber);
            gearDelayCounter = gearDelay;
            SetGearText();
        }
    }

    protected virtual void SetGearText()
    {
        currentGearText.text = $"Gear: {CurrentGear.GetName()}";
    }

    protected virtual void Update()
    {
        if (gearDelayCounter > 0f)
        {
            gearDelayCounter -= Time.deltaTime;
        }
    }
}

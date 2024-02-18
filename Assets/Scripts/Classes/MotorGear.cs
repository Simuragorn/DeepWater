using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    [Serializable]
    public class MotorGear : Gear
    {
        [Range(-1.5f, 1.5f)]
        public float Speed;
        public static new int NeutralGearNumber => 0;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    [Serializable]
    public class BuoyancyGear : Gear
    {
        [Range(-0.5f, 0.5f)]
        public float Buoyancy;
    }
}

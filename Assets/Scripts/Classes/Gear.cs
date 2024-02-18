using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    [Serializable]
    public class Gear
    {
        [Range(-5, 5)]
        public int Number;

        public string GetName()
        {
            if (Number == 0)
            {
                return "Neutral";
            }
            return Number.ToString();
        }

        public static int NeutralGearNumber => 0;
    }
}

using UnityEngine;
using System;

namespace WeaponSystem
{
    [Serializable]
    public class QualityModel
    {
        public string QualityName;
        public string QualityLevel;
        public string QualiityType;
        public string Addition;
        public int CurrentAddition;
        public int ClearPrice;
        public int ClearLevel;
        public int UnlockPrice;
        public int UnlockNeedMaterial;
        public bool IsLock;

        public GameObject QualityButton;
    }
}
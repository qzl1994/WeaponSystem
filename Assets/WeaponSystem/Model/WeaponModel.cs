using UnityEngine;

namespace WeaponSystem
{
    public delegate void OnWeaponChange(WeaponModel data);
    public delegate void OnQualityChange(QualityModel data);

    public class WeaponModel : MonoBehaviour
    {
        public string WeaponName;
        public int WeaponPower;
        public int WeaponSpeed;
        public string WeaponDesc;
        public QualityModel[] Quality;
        public QualityModel CurrentQuality;

        public OnWeaponChange OnWeaponChange;
        public OnQualityChange OnQualityChange;
    }
}
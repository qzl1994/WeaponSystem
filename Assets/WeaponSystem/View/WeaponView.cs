using UnityEngine;

namespace WeaponSystem
{
    public class WeaponView : MonoBehaviour
    {
        public WeaponQualityView WeaponQualityView;
        public WeaponQualityUnlockView WeaponQualityUnlockView;
        public WeaponDetailView WeaponDetailView;

        public void InitWeaponView(WeaponModel data)
        {
            WeaponDetailView.InitWeaponDetailView(data);
            WeaponQualityView.InitWeaponQualityView(data);
            WeaponQualityUnlockView.InitWeaponQualityUnlockView(data.CurrentQuality);
        }
    }
}
using UnityEngine;

namespace WeaponSystem
{
    /// <summary>
    /// 武器界面
    /// </summary>
    public class WeaponView : MonoBehaviour
    {
        public WeaponQualityView WeaponQualityView;
        public WeaponQualityUnlockView WeaponQualityUnlockView;
        public WeaponDetailView WeaponDetailView;

        public void InitWeaponView(WeaponModel data)
        {
            //初始化属性界面
            WeaponDetailView.InitWeaponDetailView(data);
            //初始化特质界面
            WeaponQualityView.InitWeaponQualityView(data);
            //初始化解锁界面
            WeaponQualityUnlockView.InitWeaponQualityUnlockView(data.CurrentQuality);
        }
    }
}
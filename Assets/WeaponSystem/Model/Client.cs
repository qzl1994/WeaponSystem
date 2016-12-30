using UnityEngine;

namespace WeaponSystem
{
    public class Client : MonoBehaviour
    {
        #region//单例
        private static Client _ins;

        public static Client Instance
        {
            get
            {
                return _ins;
            }
        }
        #endregion

        public WeaponModel WeaponModel;
        public WeaponView WeaponView;

        void Awake()
        {
            _ins = this;

            InitWeaponModel();
        }   

        public void InitWeaponModel()
        {
            WeaponModel.CurrentQuality = WeaponModel.Quality[0];
            WeaponView.InitWeaponView(WeaponModel);
        }
    }
}
using UnityEngine;

namespace WeaponSystem
{
    /// <summary>
    /// 客户端，程序启动入口
    /// </summary>
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

            //初始化武器模块
            InitWeaponModel();
        }   

        public void InitWeaponModel()
        {
            WeaponModel.CurrentQuality = WeaponModel.Quality[0];//取第一个特质为当前特质

            WeaponView.InitWeaponView(WeaponModel);
        }
    }
}
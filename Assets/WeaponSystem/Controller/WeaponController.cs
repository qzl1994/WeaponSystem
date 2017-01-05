using UnityEngine;

namespace WeaponSystem
{
    public class WeaponController : MonoBehaviour
    {
        #region//单例
        private static WeaponController _ins;

        public static WeaponController Instance
        {
            get
            {
                return _ins;
            }
        }
        #endregion

        void Awake()
        {
            _ins = this;
        }

        private Transform t;
        private QualityModel Quality;
        private WeaponModel Weapon;

        void Start()
        {
            t = GameObject.Find("WeaponView").transform;
        }

        /// <summary>
        /// 点击特质
        /// </summary>
        /// <param name="data"></param>
        public void OnClickQualityButton(QualityModel data)
        {
            Client.Instance.WeaponModel.CurrentQuality = data;

            Client.Instance.WeaponModel.OnQualityChange(data);
        }

        /// <summary>
        /// 洗练
        /// </summary>
        public void OnClickClearButton()
        {
            GameObject g = t.FindChild("QualityClearView").gameObject;
            g.SetActive(true);
            g.GetComponent<QualityClearView>().InitQualityClearView(Client.Instance.WeaponModel.CurrentQuality);
        }

        /// <summary>
        /// 取消洗练
        /// </summary>
        public void OnClickCancelButton()
        {
            t.FindChild("QualityClearView").gameObject.SetActive(false);
        }

        /// <summary>
        /// 确认洗练
        /// </summary>
        /// <param name="ClearNum"></param>
        public void OnClickOkButton(int ClearNum)
        {
            Weapon = Client.Instance.WeaponModel;
            Quality = Client.Instance.WeaponModel.CurrentQuality;

            int ClearBefore = Quality.CurrentAddition;
            Quality.CurrentAddition = ClearNum;

            switch (Quality.QualiityType)
            {
                default: break;
                case 0: Weapon.WeaponPower += (Quality.CurrentAddition - ClearBefore); break;
                case 1: Weapon.WeaponSpeed += (Quality.CurrentAddition - ClearBefore); break;
            }

            Client.Instance.WeaponModel = Weapon;
            Client.Instance.WeaponModel.CurrentQuality = Quality;

            Client.Instance.WeaponModel.OnWeaponChange(Client.Instance.WeaponModel);
            Client.Instance.WeaponModel.OnQualityChange(Client.Instance.WeaponModel.CurrentQuality);

            t.FindChild("QualityClearView").gameObject.SetActive(false);
        }

        /// <summary>
        /// 解锁特质
        /// </summary>
        public void OnClickUnLockButton()
        {
            Weapon = Client.Instance.WeaponModel;
            Quality = Client.Instance.WeaponModel.CurrentQuality;

            if(Quality.UnlockNeedMaterial <= 1000)
            {
                Quality.IsLock = false;

                switch (Quality.QualiityType)
                {
                    default:break;
                    case 0: Weapon.WeaponPower += Quality.CurrentAddition; break;
                    case 1: Weapon.WeaponSpeed += Quality.CurrentAddition; break;
                }

                Client.Instance.WeaponModel = Weapon;
                Client.Instance.WeaponModel.CurrentQuality = Quality;

                Client.Instance.WeaponModel.OnWeaponChange(Client.Instance.WeaponModel);
                Client.Instance.WeaponModel.OnQualityChange(Client.Instance.WeaponModel.CurrentQuality);
            }
            else
            {
                Debug.Log("材料不足");
            }
        }
    }
}
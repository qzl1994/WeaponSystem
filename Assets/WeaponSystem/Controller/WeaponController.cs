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

        private Transform t;
        private QualityModel Quality;
        private WeaponModel Weapon;

        void Awake()
        {
            _ins = this;
        }

        void Start()
        {
            t = GameObject.Find("WeaponView").transform;
        }

        public void OnClickQualityButton(QualityModel data)
        {
            Client.Instance.WeaponModel.CurrentQuality = data;

            Client.Instance.WeaponModel.OnQualityChange(data);
        }

        public void OnClickClearButton()
        {
            GameObject g = t.FindChild("QualityClearView").gameObject;
            g.SetActive(true);
            g.GetComponent<QualityClearView>().InitQualityClearView(Client.Instance.WeaponModel.CurrentQuality);
        }

        public void OnClickCancelButton()
        {
            t.FindChild("QualityClearView").gameObject.SetActive(false);
        }

        public void OnClickOkButton(int ClearNum)
        {
            Weapon = Client.Instance.WeaponModel;
            Quality = Client.Instance.WeaponModel.CurrentQuality;

            int ClearBefore = Quality.CurrentAddition;
            Quality.CurrentAddition = ClearNum;

            switch (Quality.QualiityType)
            {
                default: break;
                case "攻击": Weapon.WeaponPower += (Quality.CurrentAddition - ClearBefore); break;
                case "速度": Weapon.WeaponSpeed += (Quality.CurrentAddition - ClearBefore); break;
            }

            Client.Instance.WeaponModel = Weapon;
            Client.Instance.WeaponModel.CurrentQuality = Quality;

            Client.Instance.WeaponModel.OnWeaponChange(Client.Instance.WeaponModel);
            Client.Instance.WeaponModel.OnQualityChange(Client.Instance.WeaponModel.CurrentQuality);

            t.FindChild("QualityClearView").gameObject.SetActive(false);
        }

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
                    case "攻击": Weapon.WeaponPower += Quality.CurrentAddition; break;
                    case "速度": Weapon.WeaponSpeed += Quality.CurrentAddition; break;
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
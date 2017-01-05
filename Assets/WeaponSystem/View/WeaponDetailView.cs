using UnityEngine;
using UnityEngine.UI;

namespace WeaponSystem
{
    /// <summary>
    /// 武器属性界面
    /// </summary>
    public class WeaponDetailView : MonoBehaviour
    {
        public Text WeaponName;
        public Text WeaponPower;
        public Text WeaponSpeed;
        public Text WeaponDesc;
        public Slider WeaponPowerSlider;
        public Slider WeaponSpeedSlider;

        public Text QualityName;
        public Text QualityLevel;
        public Text QualityType;
        public Text QualityAddition;
        public Text QualityCurrentAddition;
        public Text QualityUnLock;
        public Text QualityUnLockLevel;
        public Text ClearPrice;
        public Button ClearButton;

        private string Type;

        void Start()
        {
            ClearButton.onClick.AddListener(WeaponController.Instance.OnClickClearButton);

            Client.Instance.WeaponModel.OnWeaponChange += InitWeaponDetail;
            Client.Instance.WeaponModel.OnQualityChange += InitQualityDetail;
        }

        public void InitWeaponDetailView(WeaponModel data)
        {
            InitWeaponDetail(data);
            InitQualityDetail(data.CurrentQuality);
        }

        /// <summary>
        /// 初始化武器基本属性
        /// </summary>
        /// <param name="data"></param>
        public void InitWeaponDetail(WeaponModel data)
        {
            WeaponName.text = data.WeaponName;
            WeaponPower.text = data.WeaponPower.ToString();
            WeaponSpeed.text = data.WeaponSpeed.ToString();
            WeaponDesc.text = data.WeaponDesc;
            WeaponPowerSlider.value = (float)(data.WeaponPower / 445.0);
            WeaponSpeedSlider.value = (float)(data.WeaponSpeed / 84.0);
        }

        /// <summary>
        /// 初始化特质基本属性
        /// </summary>
        /// <param name="data"></param>
        public void InitQualityDetail(QualityModel data)
        {
            switch (data.QualiityType)
            {
                default:break;
                case 0:Type = "攻击";break;
                case 1:Type = "速度";break;
            }
            QualityLevel.text = data.QualityLevel;
            QualityName.text = data.QualityName;
            QualityType.text = "可加" + Type + ":";
            QualityAddition.text = data.Addition;
            QualityCurrentAddition.text = data.CurrentAddition.ToString();

            if (data.IsLock)
            {
                QualityUnLock.gameObject.SetActive(true);
                QualityUnLockLevel.text = data.ClearLevel.ToString();
                ClearButton.gameObject.SetActive(false);
            }
            else
            {
                QualityUnLock.gameObject.SetActive(false);
                ClearButton.gameObject.SetActive(true);
                ClearPrice.text = data.ClearPrice.ToString();
            }       
        }
    }
}
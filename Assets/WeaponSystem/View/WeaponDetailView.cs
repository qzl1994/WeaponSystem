using UnityEngine;
using UnityEngine.UI;

namespace WeaponSystem
{
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

        public void InitWeaponDetail(WeaponModel data)
        {
            WeaponName.text = data.WeaponName;
            WeaponPower.text = data.WeaponPower.ToString();
            WeaponSpeed.text = data.WeaponSpeed.ToString();
            WeaponDesc.text = data.WeaponDesc;
            WeaponPowerSlider.value = (float)(data.WeaponPower / 445.0);
            WeaponSpeedSlider.value = (float)(data.WeaponSpeed / 84.0);
        }

        public void InitQualityDetail(QualityModel data)
        {
            float addition = float.Parse(data.Addition.Split(' ')[data.Addition.Split(' ').Length - 1]);
            float level = (data.CurrentAddition / addition);

            if (level <= 0.5)
            {
                data.QualityLevel = "普通";
                QualityLevel.text = data.QualityLevel;
            }
            else if (level > 0.5 && level <= 0.75)
            {
                data.QualityLevel = "优秀";
                QualityLevel.text = data.QualityLevel;
            }
            else if (level > 0.75 && level <= 1.0)
            {
                data.QualityLevel = "极品";
                QualityLevel.text = data.QualityLevel;
            }

            QualityName.text = data.QualityName;
            QualityType.text = "可加" + data.QualiityType + ":";
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
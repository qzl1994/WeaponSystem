using UnityEngine;
using UnityEngine.UI;

namespace WeaponSystem
{
    /// <summary>
    /// 武器特质解锁界面
    /// </summary>
    public class WeaponQualityUnlockView : MonoBehaviour
    {    
        public Text UnLockPrice;
        public Text UnLockNeedMaterial;
        public Button UnLockButton;
        public Slider MaterialSlider;

        public void InitWeaponQualityUnlockView(QualityModel data)
        {
            if (data.IsLock)
            {
                UnLockButton.gameObject.SetActive(true);
                UnLockPrice.text = data.UnlockPrice.ToString();
            }
            else
            {
                UnLockButton.gameObject.SetActive(false);
            }
            UnLockNeedMaterial.text = data.UnlockNeedMaterial.ToString();
            MaterialSlider.value = (float)(1000.0 / data.UnlockNeedMaterial);
        }

        void Start()
        {
            UnLockButton.onClick.AddListener(WeaponController.Instance.OnClickUnLockButton);

            Client.Instance.WeaponModel.OnQualityChange += InitWeaponQualityUnlockView;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace WeaponSystem
{
    public class QualityClearView : MonoBehaviour
    {
        public Text ClearBefore;
        public Text ClearAfter;
        public Button Ok;
        public Button Cancel;
        private int ClearNum;

        void Start()
        {
            Ok.onClick.AddListener(delegate()
            {
                WeaponController.Instance.OnClickOkButton(ClearNum);
            });
            Cancel.onClick.AddListener(WeaponController.Instance.OnClickCancelButton);
        }

        public void InitQualityClearView(QualityModel data)
        {
            ClearBefore.text = data.QualiityType + ": +" + data.CurrentAddition;

            ClearNum = GetClearNum(data);

            if (ClearNum > data.CurrentAddition)
            {
                ClearAfter.text = string.Format("<color=#5FC172>" + data.QualiityType + ": +" + ClearNum + "</color>");
            }
            else
            {
                ClearAfter.text = string.Format("<color=#FF6767>" + data.QualiityType + ": +" + ClearNum + "</color>");
            }
        }

        public int GetClearNum(QualityModel Quality)
        {
            string[] range = Quality.Addition.Split(' ');
            int num = Random.Range(int.Parse(range[0]), int.Parse(range[2]) + 1);
            return num;
        }
    }
}
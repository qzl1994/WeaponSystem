using UnityEngine;
using UnityEngine.UI;

namespace WeaponSystem
{
    /// <summary>
    /// 武器洗练界面
    /// </summary>
    public class QualityClearView : MonoBehaviour
    {
        public Text ClearBefore;
        public Text ClearAfter;
        public Button Ok;
        public Button Cancel;
        private int ClearNum;

        private string Type;

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
            switch (data.QualiityType)
            {
                case 0:Type = "攻击";break;
                case 1:Type = "速度";break;
                default:break;
            }

            ClearBefore.text = Type + ": +" + data.CurrentAddition;

            ClearNum = GetClearNum(data);

            if (ClearNum > data.CurrentAddition)
            {
                ClearAfter.text = string.Format("<color=#5FC172>" + Type + ": +" + ClearNum + "</color>");
            }
            else
            {
                ClearAfter.text = string.Format("<color=#FF6767>" + Type + ": +" + ClearNum + "</color>");
            }
        }

        /// <summary>
        /// 得到特质加成范围内的随机数
        /// </summary>
        /// <param name="Quality"></param>
        /// <returns></returns>
        public int GetClearNum(QualityModel Quality)
        {
            string[] range = Quality.Addition.Split(' ');
            int num = Random.Range(int.Parse(range[0]), int.Parse(range[2]) + 1);
            return num;
        }
    }
}
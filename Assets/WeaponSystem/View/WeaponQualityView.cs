using UnityEngine;
using UnityEngine.UI;

namespace WeaponSystem
{
    /// <summary>
    /// 武器特质界面
    /// </summary>
    public class WeaponQualityView : MonoBehaviour
    {
        public GameObject Content;//特质按钮父节点

        void Start()
        {
            Client.Instance.WeaponModel.OnQualityChange += UnLockQuality;
        }
        
        /// <summary>
        /// 实例化特质
        /// </summary>
        /// <param name="data"></param>
        public void InitWeaponQualityView(WeaponModel data)
        {
            for(int i=0;i<data.Quality.Length; i++)
            {
                Object qualityPrefab = Resources.Load("Prefabs/Quality") as Object;

                if(qualityPrefab != null)
                {
                    GameObject Quality = Instantiate(qualityPrefab) as GameObject;
                    Quality.transform.SetParent(Content.transform, false);
                    GameObject button = Quality.transform.FindChild("Button").gameObject;
                    
                    if(button != null)
                    {
                        if(i>0 && i%2 != 0)
                        {
                            button.transform.localPosition += new Vector3(100, 50 * i, 0);
                        }
                        else if(i>0 && i%2 == 0)
                        {
                            button.transform.localPosition += new Vector3(0, 50 * i, 0);
                        }

                        data.Quality[i].QualityButton = button;
                        UnLockQuality(data.Quality[i]);
                        InitQualityButton(data.Quality[i]);
                    }       
                }
            }
        }

        /// <summary>
        /// 按钮添加委托事件
        /// </summary>
        /// <param name="data"></param>
        public void InitQualityButton(QualityModel data)
        {
            data.QualityButton.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                WeaponController.Instance.OnClickQualityButton(data);
            });
        }

        /// <summary>
        /// 按钮高亮背景解锁
        /// </summary>
        /// <param name="qualityData"></param>
        public void UnLockQuality(QualityModel qualityData)
        {
            Transform t = qualityData.QualityButton.gameObject.transform.FindChild("bg2");

            if (qualityData.IsLock)
            {        
                t.gameObject.SetActive(false);
            }
            else
            {
                t.gameObject.SetActive(true);
            }
        }
    }
}
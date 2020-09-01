using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Management
{
    public class WeaponManager: MonoBehaviour
    {
        public List<Gun> Guns;

        private void Start()
        {
            InvokeRepeating("CheckTotalBulletCount", 3, 1);
        }

        void CheckTotalBulletCount()
        {
            int count = Guns.Select(item => item.BulletsLeft).Sum();
            Debug.Log("Bullets Left: " + count);
            if(count < 1)
            {
                ScoreManager.Instance.SaveScore();
                CancelInvoke("CheckTotalBulletCount");
            }
        }
    }
}

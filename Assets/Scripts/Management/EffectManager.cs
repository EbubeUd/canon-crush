using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Assets.Scripts.Management
{
    public class EffectManager
    {
        public static EffectManager Instance;

        public GameObject ExplosionEffect;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void SpawnExplosionEffect(Vector3 location)
        {
            SpawnExplosionEffect(location);
        }
    }
}

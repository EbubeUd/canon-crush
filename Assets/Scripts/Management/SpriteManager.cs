using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Management
{
    public class SpriteManager : MonoBehaviour
    {
        public static SpriteManager Instance;
        public List<Sprite> BoxSprites;
       

        void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public Sprite GetSprite(BoxType _boxType)
        {
            return BoxSprites[(int)_boxType];
        }
    }
}

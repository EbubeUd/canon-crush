using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Boxes
{
    public class BoxHolder : FallingObject
    {
       // [HideInInspector]
        public BoxType BoxType;

        [HideInInspector]
        public ColumnType ColumnType;


        private void Start()
        {
            SetupFallingObject();
            DelegateHandler.BoxDestroyed += OnBoxDestroyed;
            Invoke("ResetSpeed", 0.5f);
            ConstantFall = true;
        }


        /// <summary>
        /// Sets up the requirements for the obejct to fall smoothely. 
        /// It references the falling object parent
        /// </summary>
        void SetupFallingObject()
        {
            Speed = 4;
            UseConstantDirection = true;
            SetRigidBody(GetComponent<Rigidbody2D>());
        }

        private void OnBoxDestroyed(ColumnType column, BoxType box)
        {

        }

        void ResetSpeed()
        {
            ConstantFall = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
   
        }

        private void OnDestroy()
        {
            DelegateHandler.BoxDestroyed -= OnBoxDestroyed;
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
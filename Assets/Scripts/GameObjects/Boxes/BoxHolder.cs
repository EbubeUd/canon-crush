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
        }


        /// <summary>
        /// Sets up the requirements for the obejct to fall smoothely. 
        /// It references the falling object parent
        /// </summary>
        void SetupFallingObject()
        {
            Speed = 5;
            UseConstantDirection = true;
            SetRigidBody(GetComponent<Rigidbody2D>());
        }

        private void OnBoxDestroyed(ColumnType column, BoxType box)
        {
            Speed = 5;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("BoxHolder"))
            {
                Speed = 0;
            }
        }

        private void OnDestroy()
        {
            DelegateHandler.BoxDestroyed -= OnBoxDestroyed;
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
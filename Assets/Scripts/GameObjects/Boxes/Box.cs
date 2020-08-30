using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using UnityEngine;
using Unity;
using Assets.Scripts.Enums;
using Assets.Scripts.Management;
using Assets.Scripts.Logic;

namespace Assets.Scripts.GameObjects.Boxes
{
    public class Box : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        BoxHolder parentHolder;
        public Sprite Sprite;


        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Sprite;
            parentHolder = transform.parent.gameObject.GetComponent<BoxHolder>();
            SetUpVisuals();
            MatchingSystem.Instance.AddBox(parentHolder.ColumnType, this);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                switch (parentHolder.BoxType)
                {
                    case BoxType.Hs:
                        MatchingSystem.Instance.DestroyBoxesInColumn((int)parentHolder.ColumnType);
                        break;
                    case BoxType.R:
                        MatchingSystem.Instance.DestroyBoxesInRow((int)parentHolder.ColumnType, this);
                        break;
                    default:
                        DestroyBox();
                        break;
                }
            }
        }

        public BoxType GetBoxType()
        {
            return parentHolder.BoxType;
        }

        public void DestroyBox()
        {
            DelegateHandler.BoxDestroyed(parentHolder.ColumnType, parentHolder.BoxType);
            Destroy(transform.parent.gameObject);
        }

        public void SetUpVisuals()
        {
            switch (parentHolder.BoxType)
            {
                // Rendering red color
                case BoxType.A:
                    spriteRenderer.sprite = SpriteManager.Instance.GetSprite(BoxType.A);
                    break;
                //Rendering blue color
                case BoxType.B:
                    spriteRenderer.sprite = SpriteManager.Instance.GetSprite(BoxType.B);
                    break;
                // Rendering yellow color
                case BoxType.C:
                    spriteRenderer.sprite = SpriteManager.Instance.GetSprite(BoxType.C);
                    break;
                // Rendering green color
                case BoxType.D:
                    spriteRenderer.sprite = SpriteManager.Instance.GetSprite(BoxType.D);
                    break;
                case BoxType.Hs:
                    spriteRenderer.sprite = SpriteManager.Instance.GetSprite(BoxType.Hs);
                    break;
                case BoxType.R:
                    spriteRenderer.sprite = SpriteManager.Instance.GetSprite(BoxType.R);
                    break;

            }
        }


    }

}
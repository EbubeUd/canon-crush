using Assets.Scripts.Enums;
using Assets.Scripts.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * Gun class defines a gun used in this game
 */
public class Gun : MonoBehaviour
{
    // Reference to the prefab that is used as a blueprint for spawning bullets
    public Rigidbody2D PrefabOfBullet;


    // Bullet that has been spawned and made ready to be launched
    private Rigidbody2D LaunchableBullet;


    // Velocity at which this gun launches its bullets
    private Vector2 LaunchVelocity;

    public int BulletsLeft;


    Animator animator;

    public ColumnType Column;

    public Text BulletsLeftText;

    // Called before the first frame update
    private void Start()
    {
        LaunchVelocity = new Vector2(0, 25);
        SpawnLaunchableBullet();
        BulletsLeft = 20;
        animator = GetComponent<Animator>();
        DelegateHandler.BoxDestroyed += OnBoxDestroyed;
        BulletsLeftText.text = BulletsLeft.ToString();

    }


    void OnBoxDestroyed(ColumnType column, BoxType box)
    {
        if(box == BoxType.AntiRacistAid && Column == column)
        {
            //Add one more bullet to the gun
            EnableGun(1);
        }
    }


    // Spawns a launchable bullet
    private void SpawnLaunchableBullet()
    {
        LaunchableBullet = Instantiate(PrefabOfBullet, GetPositionOfNozzle(), Quaternion.identity);
    }


    // Returns the position of this gun's nozzle
    private Vector3 GetPositionOfNozzle()
    {
        Transform thisGameObject = this.gameObject.transform;
        Vector3 positionOfNozzle = thisGameObject.position;

        for (int i = 0; i < thisGameObject.childCount; i++) {

            if (thisGameObject.GetChild(i).name == "Nozzle") {
                positionOfNozzle = thisGameObject.GetChild(i).position;
                break;
            }
        }

        return positionOfNozzle;
    }


    // Fires this gun
    public void Fire()
    {
        if (GameManager.Instance.IsGamePaused)
        {
            return;
        }

        if (BulletsLeft <= 0) return;

        if (LaunchableBullet != null) {
            LaunchBullet();
            Invoke("SpawnLaunchableBullet", 0.5f);
            BulletsLeft--;
            BulletsLeftText.text = BulletsLeft.ToString();
            if (DelegateHandler.GunFired != null) {
                DelegateHandler.GunFired.Invoke();
            }
        }
        if (BulletsLeft == 0) DisableGun();

    }




    void DisableGun()
    {
        animator.SetBool("IsEnabled", false);
    }

    void EnableGun(int numberOfBullets)
    {
        BulletsLeft += numberOfBullets;
        BulletsLeftText.text = BulletsLeft.ToString();
        animator.SetBool("IsEnabled", true);
    }


    // Launches the current launchable bullet
    private void LaunchBullet()
    {
        if (LaunchableBullet != null) {
            LaunchableBullet.isKinematic = false;
            LaunchableBullet.velocity = LaunchVelocity;
            LaunchableBullet = null;
        }
    }

    private void OnDisable()
    {
        DelegateHandler.BoxDestroyed -= OnBoxDestroyed;
    }

}

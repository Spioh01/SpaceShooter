using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private float shootingInterval;

    [Header("Basic Attack")]
    [SerializeField] private Transform basicShootingPoint;

    [Header("Upgrade Points")]
    [SerializeField] private Transform leftCannon;
    [SerializeField] private Transform rightCannon;
    [SerializeField] private Transform secondLeftCannon;
    [SerializeField] private Transform secondRightCannon;

    [Header("Upgrade Rotation Points")]
    [SerializeField] private Transform leftRotationCannon;
    [SerializeField] private Transform rightRotationCannon;

    [SerializeField] private AudioSource source;
    private int upgradeLevel = 0;
    private float intervalReset;
    void Start()
    {
        intervalReset = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if (shootingInterval <= 0)
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }
    public void IncreaseUpgrade(int increaseAmount)
    { 
        upgradeLevel += increaseAmount;
        if (shootingInterval <= 0)
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }
    public void DecreaseUpgrade(int decreaseAmount)
    {
        upgradeLevel -= decreaseAmount;
        if(upgradeLevel <= 0) { 
            upgradeLevel = 0;
        }
    }
    private void Shoot()
    {
        source.Play();
        switch (upgradeLevel)
        {
            case 0:
                Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(laserBullet, leftCannon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCannon.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCannon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCannon.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCannon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCannon.position, Quaternion.identity);
                Instantiate(laserBullet, secondLeftCannon.position, Quaternion.identity);
                Instantiate(laserBullet, secondRightCannon.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCannon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCannon.position, Quaternion.identity);
                Instantiate(laserBullet, secondLeftCannon.position, Quaternion.identity);
                Instantiate(laserBullet, secondRightCannon.position, Quaternion.identity);
                Instantiate(laserBullet, rightRotationCannon.position, Quaternion.identity);
                Instantiate(laserBullet, leftRotationCannon.position, Quaternion.identity);
                break;
            default: 
                break;
        }
    }
}

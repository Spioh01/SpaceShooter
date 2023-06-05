using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hitsToDestroy = 3;
    public bool protection = false;

    private void OnEnable()
    {
        hitsToDestroy = 3;
        protection = true;
    }
    private void DamageShield()
    { 
        hitsToDestroy--;
        if (hitsToDestroy <= 0)
        { 
            protection = false;
            gameObject.SetActive(false);
        }
    }
    public void RepairShield()
    { 
        hitsToDestroy=3;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            if (collision.CompareTag("Boss"))
            {
                enemy.TakeDamage(5);
                hitsToDestroy = 0;
                DamageShield();
                return;
            }
            enemy.TakeDamage(999);
            DamageShield();
        }
        else { 
            Destroy(collision.gameObject);
            DamageShield();
        }
    }
}

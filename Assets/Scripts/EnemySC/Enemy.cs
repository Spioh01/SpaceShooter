using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject explosionPrefab;

    [SerializeField] protected Animator anim;
    [Header("Score"), SerializeField]
    protected int scoreValue;
    // Start is called before the first frame upd ate
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    { 
        health -= damage;
        HurtSequence();
        if (health < 0)
        {
            DeathSequence();
        }
    }
    public virtual void HurtSequence()
    {
        //
    }
    public virtual void DeathSequence()
    {
        EndGameManager.endManager.UpdateScore(scoreValue);
    }
}

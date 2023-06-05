using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    private float rotateSpeed;
    [SerializeField] private float maxRotateSpeed;
    [SerializeField] private ScriptLevelObjectExample powerUpSpawner;
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down*speed;
    }

    // Update is called once per frame
    void Update()
    {
        rotateSpeed = Random.Range(0, maxRotateSpeed);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
    public override void HurtSequence()
    {
        //
    }
    public override void DeathSequence()
    {
        base.DeathSequence();
        Instantiate(explosionPrefab,transform.position,transform.rotation);
        if (powerUpSpawner != null)
            powerUpSpawner.SpawnPowerUp(transform.position);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.CompareTag("Player"))
        {
            //Destroy(otherColl.gameObject);
            PlayerStats player = otherColl.GetComponent<PlayerStats>();
            player.PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

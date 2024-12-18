using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    [SerializeField] Ship playerShip;
    [SerializeField] float damageForceMagnitude = 4000;
    [SerializeField] CustomCollider _collider;
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameOverManager gameOverManager;

    public int PlayerHealthValue
    {
        get { return playerHealth; }
        set 
        { 
            playerHealth = value;
            healthText.text = "HP: " + playerHealth.ToString() + "%";

            if (playerHealth <= 0)
            {
                playerHealth = 0;
                healthText.text = "HP: 0%";
                gameOverManager.ActivateWithDelay(2);
                playerShip.SpawnDestructionVFX();
                Destroy(gameObject);
            }

        }
    }

    private void Awake()
    {
        if(!_collider)
        {
            _collider = GetComponent<CustomCollider>();
        }
    }

    private void OnEnable()
    {
        _collider.OnCollisionDetected += Collision;
    }

    private void OnDisable()
    {        
        _collider.OnCollisionDetected -= Collision;
    }

    public void DealDamage(int damageValue, Vector3 direction)
    {
        playerShip.AddForceToShip(direction * damageForceMagnitude);
        PlayerHealthValue -= damageValue;
    }

    void Collision(CustomCollider other)
    {
        if(other.collisionLayer == CustomCollisionLayer.EnemyShip)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction.Normalize();

            DealDamage(10, -direction);
        }
    }

    private void OnDestroy()
    {
    }
}

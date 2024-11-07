using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerCarSprite;
    [SerializeField] SpriteRenderer[] obstacleSprites;

    bool isPlayerInCollision = false;

    private void Update()
    {
        isPlayerInCollision = false;
        foreach (SpriteRenderer obstacleSprite in obstacleSprites)
        {
            if(AABBCollisionCheck(playerCarSprite, obstacleSprite) == true)
            {
                isPlayerInCollision = true;
            }
        }

        if(isPlayerInCollision)
        {
            playerCarSprite.color = Color.red;
        }
        else
        {
            playerCarSprite.color = Color.white;
        }
    }

    bool AABBCollisionCheck(SpriteRenderer playerCarSprite, SpriteRenderer obstacleSprite)
    {
        if (playerCarSprite.bounds.max.x > obstacleSprite.bounds.min.x && playerCarSprite.bounds.min.x < obstacleSprite.bounds.max.x
            && playerCarSprite.bounds.max.y > obstacleSprite.bounds.min.y && playerCarSprite.bounds.min.y < obstacleSprite.bounds.max.y)
        {
            Debug.Log("AABB Collision Detected!");
            obstacleSprite.color = Color.red;
            return true;
        }
        else
        {
            obstacleSprite.color = Color.white;
            return false; 
        }
    }
}

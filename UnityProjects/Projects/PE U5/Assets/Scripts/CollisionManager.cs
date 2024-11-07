using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

//Class that handles collision detection for different collision detection modes
public class CollisionManager : MonoBehaviour
{
    public CollisionType collisionDetectionType;

    [SerializeField] SpriteInfo playerCarSpriteInfo;
    [SerializeField] SpriteInfo[] obstacleSpriteInfos;

    //Flag to show if player car is in a collision
    bool isPlayerInCollision = false;

    [SerializeField] TextMeshProUGUI collisionDetectionTypeText;

    private void Update()
    {
        //Set collision flag to false
        isPlayerInCollision = false;

        //Call appropriate collision check method based on current collision mode
        if (collisionDetectionType == CollisionType.aabb)
        {
            foreach (SpriteInfo obstacleSpriteInfo in obstacleSpriteInfos)
            {

                if (AABBCollisionCheck(playerCarSpriteInfo.spriteRenderer, obstacleSpriteInfo.spriteRenderer) == true)
                {
                    isPlayerInCollision = true;
                }
            }

        }
        else if(collisionDetectionType == CollisionType.circle)
        {
            foreach (SpriteInfo obstacleSpriteInfo in obstacleSpriteInfos)
            {

                if (CircleCollisionCheck(playerCarSpriteInfo, obstacleSpriteInfo) == true)
                {
                    isPlayerInCollision = true;
                }
            }
        }

        //IF player is in collision, set sprite color to red, otherwise white
        if (isPlayerInCollision)
        {
            playerCarSpriteInfo.spriteRenderer.color = Color.red;
        }
        else
        {
            playerCarSpriteInfo.spriteRenderer.color = Color.white;
        }
    }

    //Check for aabb collision
    bool AABBCollisionCheck(SpriteRenderer playerCarSprite, SpriteRenderer obstacleSprite)
    {
        //Check if any part of player car bounds is within the bounds of the obstacle
        //if true, set obstacle color to red and return true
        //else, set obstacle color to white and return false
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

    bool CircleCollisionCheck(SpriteInfo playerCarSriteInfo, SpriteInfo obstacleSprintInfo)
    {
        //Find distance squared between centers of both bounding circles using pythagorean theorem
        // distance^2 = (x1-x2)^2 + (y1-y2)^2
        float distanceSquared = Mathf.Pow(playerCarSpriteInfo.transform.position.x - obstacleSprintInfo.transform.position.x, 2) + 
            Mathf.Pow(playerCarSpriteInfo.transform.position.y - obstacleSprintInfo.transform.position.y, 2);

        //check if distance squared is less than sum of radii squared
        //In other words, check if the circles are overlapping (If distance between centers is less than sum of radii)
        //if true, set obstacle color to red and return true
        //else, set obstacle color to white and return false
        if (distanceSquared < Mathf.Pow((playerCarSpriteInfo.boundingCircleRadius + obstacleSprintInfo.boundingCircleRadius), 2))
        {
            Debug.Log("Circle Collision Detected!");
            obstacleSprintInfo.spriteRenderer.color = Color.red;
            return true;
        }
        else
        {
            obstacleSprintInfo.spriteRenderer.color = Color.white;
            return false;
        }
    }

    //Change colliision type and update text component
    public void OnChangeCollisionMode(InputAction.CallbackContext context)
    {
        if(collisionDetectionType == CollisionType.aabb)
        {
            collisionDetectionType = CollisionType.circle;
        }
        else
        {
            collisionDetectionType = CollisionType.aabb;
        }
        collisionDetectionTypeText.text = "Collision Detection Mode: " + collisionDetectionType.ToString().ToUpper();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    //Array of creature sprites. Make sure they are arranged in the following order in inspector:
    //Elephant (25%)
    //Turtle (20%)
    //Snail (15%)
    //Octopus (10%)
    //Kangaroo (30%)
    [SerializeField] Sprite[] spriteImages;

    //Prefab of creature to spawn
    [SerializeField] GameObject creaturePrefab;

    //List of reference to all creatures spawned
    [SerializeField] List<GameObject> spawnedCreaturesList;


    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    public void Spawn()
    {
        //Clear all currently spawned creatures
        CleanUp();

        //Determine random number of creatures to spawn
        int numberOfCreaturesToSpawn = Random.Range(10, 30);

        //for loop to spawn each creature
        //with each creature we determine:
        //A random location with gaussian distribution
        //A random color by generating random values for red, green and blue components
        for (int i = 0; i < numberOfCreaturesToSpawn; i++)
        {
            Vector2 spawnLocation = new Vector2(Gaussian(0, 1), Gaussian(0, 1));
            Color creatureColor = new Color(Random.value, Random.value, Random.value);
            SpawnCreature(ChooseRandomCreature(), spawnLocation, creatureColor);
        }
    }

    //Helper method that spawns a creature and adds it to spawned creatures list
    private void SpawnCreature(Sprite creatureSprite, Vector2 spawnLocation, Color randomColor)
    {
        GameObject newCreature = Instantiate(creaturePrefab, spawnLocation, Quaternion.identity);
        spawnedCreaturesList.Add(newCreature);

        SpriteRenderer newCreatureSpriteRenderer = newCreature.GetComponent<SpriteRenderer>();
        newCreatureSpriteRenderer.sprite = creatureSprite;
        newCreatureSpriteRenderer.color = randomColor;

    }

    //Method that returns a random sprite based on predefined chances
    private Sprite ChooseRandomCreature()
    {
        float spawnChance = Random.value;

        if (spawnChance < 0.25)
        {
            return spriteImages[0];
        }
        else if (spawnChance < 0.45)
        {
            return spriteImages[1];
        }
        else if (spawnChance < 0.60)
        {
            return spriteImages[2];
        }
        else if (spawnChance < 0.70)
        {
            return spriteImages[3];
        }
        else
        {
            return spriteImages[4];
        }
    }

    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

    //Deletes all existing spawned creature gameobjects and clears the list
    private void CleanUp()
    {
        foreach(GameObject creature in spawnedCreaturesList)
        {
            Destroy(creature);
        }
        spawnedCreaturesList.Clear();
    }

}

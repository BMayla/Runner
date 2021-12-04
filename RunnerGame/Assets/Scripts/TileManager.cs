using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{ 
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;//we are moving a long in the z axes 
    public float tileLength = 24;// the lengh of our title
    public int numberOfTiles = 5;

     public Transform playerTransform; 
   
    private List<GameObject> activeTiles = new List<GameObject>();


    // Start is called before the first frame update
    //public Transform playerTransform;

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0) // the first road is empty
                 SpawnTile(0);
            else
                 SpawnTile(Random.Range(0, tilePrefabs.Length));
        }

    }

    // Update is called once per frame
    void Update()
    {
       if (playerTransform.position.z-48 > zSpawn - (numberOfTiles * tileLength)) //when the player is moving forward 
        {
            
            SpawnTile(Random.Range(0, tilePrefabs.Length)); //  news titles are generated
            DeleteTile();//when we spawn a new title we need to delete the first one in the active  Titles list usin a function DeleteTile()
        }

    }

public void SpawnTile(int titleIndex)
{
       GameObject go = Instantiate(tilePrefabs[titleIndex], transform.forward * zSpawn, transform.rotation);
        
       activeTiles.Add(go);
       zSpawn += tileLength;

}
    private void DeleteTile()
    {
        //activeTiles[0].SetActive(false);
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        //PlayerManager.score += 3;
    }
    
}


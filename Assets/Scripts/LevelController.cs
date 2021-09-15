using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Transform[] tiles;
    public Vector3 nextTilePosition;
    public GameObject player;
    public float tileDrawDistance;
    public float tileDeleteDistance;
  
    void Start()
    {
       LoadTiles();
    }

    // Update is called once per frame
    void Update()
    { 
        RemoveTiles();
       LoadTiles();
    }

    void LoadTiles()
    {
        while ((nextTilePosition - player.transform.position).x < tileDrawDistance)
        {
            Transform tile = tiles[Random.Range(0, tiles.Length)];
            Transform newPart = Instantiate(tile, nextTilePosition - tile.Find("Start_point").position, tile.rotation,
                transform);

            nextTilePosition = newPart.Find("End_point").position;
        }
    }

    void RemoveTiles()
    {
        if (transform.childCount>1)
        {
            Transform tile = transform.GetChild(0);
            Vector3 diff = player.transform.position - tile.position;

            if (diff.x > tileDeleteDistance)
            {
                Destroy(tile.gameObject);
            }
        }
    }
}



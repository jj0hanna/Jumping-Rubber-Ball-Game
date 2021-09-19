using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform[] tiles;
    [SerializeField] private Vector3 nextTilePosition;
    [SerializeField] private GameObject player;
    [SerializeField] private float tileDrawDistance;
    [SerializeField] private float tileDeleteDistance;
    
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
            //load random tilelevels at a specific distance 
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
            //remove the tile in position 0 when the player is a specific amount of lenght away from it
            Transform tile = transform.GetChild(0);
            Vector3 diff = player.transform.position - tile.position;

            if (diff.x > tileDeleteDistance)
            {
                Destroy(tile.gameObject);
            }
        }
    }
}



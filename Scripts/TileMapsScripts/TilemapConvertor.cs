using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapConvertor : MonoBehaviour
{
    private float offset = 0.5f;

    [SerializeField] private Tilemap CollectableTilemap;

    [SerializeField] private List<Tile> tiles = new List<Tile>();
    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();

    private Dictionary<Tile, GameObject> tilesToPrefabs = new Dictionary<Tile, GameObject>();

    private void Start()
    {
        for(int i = 0;i<tiles.Count;i++)
        {
            tilesToPrefabs[tiles[i]] = prefabs[i];
        }

        SetAllPrefabs(CollectableTilemap);
    }

    private void SetAllPrefabs(Tilemap tilemap)
    {
        foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
        {
            Tile tile = tilemap.GetTile<Tile>(position);
            if (tile == null) continue;

            if (tilesToPrefabs.ContainsKey(tile))
            {
                setPrefab(position, tilesToPrefabs[tile], tilemap);
            }
        }
    }

    private void setPrefab(Vector3Int position, GameObject objToSpawn, Tilemap tilemap)
    {
        Vector2 selfOffset = new Vector2(offset + objToSpawn.transform.position.x, offset + objToSpawn.transform.position.y);
        Vector2 vec = new Vector2(position.x, position.y);

        Instantiate(objToSpawn, vec + selfOffset, Quaternion.identity);

        tilemap.SetTile(position, null);
    }
}
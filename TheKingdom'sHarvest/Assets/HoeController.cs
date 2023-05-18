using UnityEngine;
using UnityEngine.Tilemaps;

public class HoeController : MonoBehaviour
{
    public Tilemap groundTileset; // Reference to the tilemap containing the ground tiles
    public TileBase farmDirtTile; // Reference to the "farmdirt_0" tile in the tile palette

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            SwapTile();
        }
    }

    private void SwapTile()
    {
        Vector3Int mousePosition = GetMouseTilePosition();
        Vector3Int playerPosition = groundTileset.WorldToCell(transform.position);

        // Check if the tile is directly adjacent to the player
        if (Vector3Int.Distance(mousePosition, playerPosition) <= 1f)
        {
            if (groundTileset.GetTile(mousePosition) is TileBase groundTile && groundTile.name == "GroundOnly_0")
            {
                groundTileset.SetTile(mousePosition, farmDirtTile);
            }
        }
    }

    private Vector3Int GetMouseTilePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return groundTileset.WorldToCell(mouseWorldPos);
    }
}

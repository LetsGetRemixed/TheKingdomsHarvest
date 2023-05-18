using UnityEngine;
using UnityEngine.Tilemaps;

public class HoeController : MonoBehaviour
{
    public Tilemap groundTileset; // Reference to the tilemap containing the ground tiles
    public TileBase farmDirtTile; // Reference to the "farmdirt_0" tile in the tile palette

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwapTile();
        }
    }

    private void SwapTile()
    {
        Vector3Int tilePosition = groundTileset.WorldToCell(transform.position);

        if (groundTileset.GetTile(tilePosition) is TileBase groundTile && groundTile.name == "GroundOnly_0")
        {
            groundTileset.SetTile(tilePosition, farmDirtTile);
        }
    }
}

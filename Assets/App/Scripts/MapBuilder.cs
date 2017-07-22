using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    public int ZoomLevel = 12;

    public float MapTileSize = 0.5f;

    public float Latitude = 47.642567f;
    public float Longitude = -122.136919f;
    
    public GameObject MapTilePrefab;

    public float MapSize = 12;

    private TileInfo _centerTile;
    private List<MapTile> _mapTiles;

    void Start()
    {
        _mapTiles = new List<MapTile>();
        ShowMap();
    }

    public void ShowMap()
    {
        _centerTile = new TileInfo(new WorldCoordinate { Lat = Latitude, Lon = Longitude }, 
            ZoomLevel, MapTileSize);
        LoadTiles();
    }

    private void LoadTiles(bool forceReload = false)
    {
        var size = (int)(MapSize / 2);

        var tileIndex = 0;
        for (var x = -size; x <= size; x++)
        {
            for (var y = -size; y <= size; y++)
            {
                var tile = GetOrCreateTile(x, y, tileIndex++);
                tile.SetTileData(new TileInfo(_centerTile.X - x, _centerTile.Y + y, ZoomLevel, MapTileSize),
                    forceReload);
                tile.gameObject.name = string.Format("({0},{1}) - {2},{3}", x, y, tile.TileData.X,
                    tile.TileData.Y);
            }
        }
    }

    private MapTile GetOrCreateTile(int x, int y, int i)
    {
        if (_mapTiles.Any() && _mapTiles.Count > i)
        {
            return _mapTiles[i];
        }

        var mapTile = Instantiate(MapTilePrefab, transform);
        mapTile.transform.localPosition = new Vector3(MapTileSize * x - MapTileSize / 2, 0, MapTileSize * y + MapTileSize / 2);
        mapTile.transform.localRotation = Quaternion.identity;
        var tile = mapTile.GetComponent<MapTile>();
        _mapTiles.Add(tile);
        return tile;
    }
}
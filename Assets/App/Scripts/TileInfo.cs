using System;
using UnityEngine;

public class TileInfo : IEquatable<TileInfo>
{
    public float MapTileSize { get; private set; }

    public TileInfo(WorldCoordinate centerLocation, int zoom, float mapTileSize)
    {
        SetStandardValues(mapTileSize);

        //http://wiki.openstreetmap.org/wiki/Slippy_map_tilenames#Tile_numbers_to_lon..2Flat._2
        var latrad = centerLocation.Lat * Mathf.Deg2Rad;
        var n = Math.Pow(2, zoom);
        X = (int)((centerLocation.Lon + 180.0)/360.0*n);
        Y = (int)((1.0 - Mathf.Log(Mathf.Tan(latrad) + 1 / Mathf.Cos(latrad)) / Mathf.PI) / 2.0 * n);
        ZoomLevel = zoom;
    }

    public TileInfo(int x, int y, int zoom, float mapTileSize)
    {
        SetStandardValues(mapTileSize);
        X = x;
        Y = y;
        ZoomLevel = zoom;
    }

    private void SetStandardValues(float mapTileSize)
    {
        MapTileSize = mapTileSize;
    }

    public int X { get;  set; }
    public int Y { get;  set; }

    public int ZoomLevel { get; private set; }

    public override bool Equals(object obj)
    {
        return Equals(obj as TileInfo);
    }

    public override string ToString()
    {
        return string.Format("X={0},Y={1},zoom={2}", X, Y, ZoomLevel);
    }

    public virtual bool Equals(TileInfo other)
    {
        if (other != null)
        {
            return X == other.X && Y == other.Y && ZoomLevel == other.ZoomLevel;
        }

        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = X;
            hashCode = (hashCode * 397) ^ Y;
            hashCode = (hashCode * 397) ^ ZoomLevel;
            return hashCode;
        }
    }
}

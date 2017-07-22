using UnityEngine;

public class OpenStreetMapTileBuilder : IMapUrlBuilder
{
    private static readonly string[] TilePathPrefixes = { "a", "b", "c" };

    public string GetTileUrl(TileInfo tileInfo)
    {
        return string.Format("http://{0}.tile.openstreetmap.org/{1}/{2}/{3}.png",
                   TilePathPrefixes[Mathf.Abs(tileInfo.X) % 3],
                   tileInfo.ZoomLevel, tileInfo.X, tileInfo.Y);
    }
}
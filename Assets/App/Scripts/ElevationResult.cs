using System;
using System.Collections.Generic;

[Serializable]
public class Resource
{
    public Resource()
    {
        elevations = new List<int>();
    }
    public string __type;
    public List<int> elevations;
    public int zoomLevel;
}

[Serializable]
public class ResourceSet
{
    public ResourceSet()
    {
        resources = new List<Resource>();
    }
    public int estimatedTotal;
    public List<Resource> resources;
}

[Serializable]
public class ElevationResult
{
    public ElevationResult()
    {
        resourceSets = new List<ResourceSet>();
    }
    public string authenticationResultCode;
    public string brandLogoUri;
    public string copyright;
    public List<ResourceSet> resourceSets;
    public int statusCode;
    public string statusDescription;
    public string traceId;
}

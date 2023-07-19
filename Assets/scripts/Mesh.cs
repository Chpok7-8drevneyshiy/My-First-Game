using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public static class CustomMeshPool
{
    private static List<CustomMesh> Pool;
    private static int pointer;

    public static CustomMesh GetMesh(int id)
    {
        return Pool[id];
    }

    public static int Push(CustomMesh customMesh)
    {
        if (Pool == null)
            Pool = new List<CustomMesh>();

        pointer = GetAvailableIndex();

        if (pointer < Pool.Count)
            Pool[pointer] = customMesh;
        else
            Pool.Add(customMesh);

        return pointer;
    }

    public static bool Remove(int index)
    {
        if (Pool == null)
            return false;

        var b = Pool[index] == null;

        Pool[index] = null;

        return b;
    }

    public static int GetAvailableIndex()
    {
        if (Pool == null)
            return 0;

        var availableIndex = Pool.FindIndex(mesh => mesh == null);

        return availableIndex != -1 ? availableIndex : Pool.Count;
    }

    public static void Flush()
    {
        if (Pool != null)
            Pool.Clear();
    }
}

public class CustomMesh
{
    public int Id;

    public Triangle[] Triangles;

    public Vector3[] vertices;

    public Vector3[] normals;

    public Vector2[] uv0, uv2;

    public Color[] colors;

    public CustomMesh(Vector3[] vertices, int[] triangles, Vector3[] normals, Vector2[] uv0, Vector2[] uv2,
        Color[] colors)
    {
        this.vertices = vertices;
        this.normals = normals;
        if (normals != null)
            for (var i = 0; i < this.normals.Length; i++)
            {
                this.normals[i] = this.normals[i].normalized;
            }

        this.uv0 = uv0;
        this.uv2 = uv2;

        this.colors = colors;

        var ptr = CustomMeshPool.GetAvailableIndex();
        CustomMeshPool.Push(this);

        Id = ptr;

        Triangles = new Triangle[triangles.Length / 3];

        Triangles = Triangles
            .AsParallel()
            .Select((t, i) => new Triangle(ptr, i, triangles[i * 3], triangles[i * 3 + 1], triangles[i * 3 + 2]))
            .ToArray();
    }
}

public struct Triangle
{
    private int _index;
    public int Index
    {
        get { return _index; }
        set
        {
            _index = value;
            if (_edges != null)
            {
                _edges[0].TriangleIndex = value;
                _edges[1].TriangleIndex = value;
                _edges[2].TriangleIndex = value;
            }
        }
    }

    private int _meshId;
    public int MeshId
    {
        get { return _meshId; }
        internal set { _meshId = value; }
    }

    private Edge[] _edges;

    public Edge[] Edges
    {
        get { return _edges; }
        set
        {
            if (value.Length == 3)
            {
                _edges = value;
                for (var i = 0; i < 3; i++)
                {
                    _edges[i].TriangleIndex = _index;
                }
            }
            else
                throw new IndexOutOfRangeException();
        }
    }

    public Vertex V0
    {
        get { return Edges[0].v0; }
        set
        {
            if (value.MeshId != MeshId)
                throw new Exception("Not the same mesh");

            Edges[0].v0 = value;
            Edges[2].v1 = value;
        }
    }

    public Vertex V1
    {
        get { return Edges[1].v0; }
        set
        {
            if (value.MeshId != MeshId)
                throw new Exception("Not the same mesh");

            Edges[1].v0 = value;
            Edges[0].v1 = value;
        }
    }

    public Vertex V2
    {
        get { return Edges[2].v0; }
        set
        {
            if (value.MeshId != MeshId)
                throw new Exception("Not the same mesh");

            Edges[2].v0 = value;
            Edges[1].v1 = value;
        }
    }

    public Triangle(int meshId, int index, int v0, int v1, int v2)
    {
        _index = index;
        _meshId = meshId;

        var edges = new Edge[3];
        edges[0] = new Edge(meshId, index, v0, v1);
        edges[1] = new Edge(meshId, index, v1, v2);
        edges[2] = new Edge(meshId, index, v2, v0);

        _edges = edges;
    }
}

public struct Edge
{
    public Vertex v0;

    public Vertex v1;

    private int _meshId;
    public int MeshId
    {
        get { return _meshId; }
        internal set { _meshId = value; }
    }

    private int _triangleIndex;
    public int TriangleIndex
    {
        get { return _triangleIndex; }
        internal set { _triangleIndex = value; }
    }

    public Edge(int meshId, int triangleIndex, int v0Index, int v1Index)
    {
        _meshId = meshId;
        _triangleIndex = triangleIndex;
        v0 = new Vertex()
        {
            MeshId = meshId,
            Index = v0Index
        };
        v1 = new Vertex()
        {
            MeshId = meshId,
            Index = v1Index
        };
    }
}

public struct Vertex
{
    public int Index;

    private int _meshId;
    public int MeshId
    {
        get { return _meshId; }
        internal set { _meshId = value; }
    }

    public Vector3 position
    {
        get { return CustomMeshPool.GetMesh(_meshId).vertices[Index]; }
        set { CustomMeshPool.GetMesh(_meshId).vertices[Index] = value; }
    }

    public Vector3 normal
    {
        get { return CustomMeshPool.GetMesh(_meshId).normals[Index]; }
        set { CustomMeshPool.GetMesh(_meshId).normals[Index] = value; }
    }

    public Vector2 uv0
    {
        get { return CustomMeshPool.GetMesh(_meshId).uv0[Index]; }
        set { CustomMeshPool.GetMesh(_meshId).uv0[Index] = value; }
    }

    public Vector2 uv2
    {
        get { return CustomMeshPool.GetMesh(_meshId).uv2[Index]; }
        set { CustomMeshPool.GetMesh(_meshId).uv2[Index] = value; }
    }

    public Color color
    {
        get { return CustomMeshPool.GetMesh(_meshId).colors[Index]; }
        set { CustomMeshPool.GetMesh(_meshId).colors[Index] = value; }
    }
}
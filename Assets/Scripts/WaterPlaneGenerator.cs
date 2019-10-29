using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneGenerator : MonoBehaviour {

    public float size = 1;
    public int gridSize = 16;

    private MeshFilter filter;
	// Use this for initialization
	void Start ()
    {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();
	}
	
    private Mesh GenerateMesh()
    {
        Mesh watermesh = new Mesh();
        var vertices = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>();

        for (int x = 0; x < gridSize + 1; x++)
        {
            for (int y = 0; y < gridSize + 1; y++)
            {
                vertices.Add(new Vector3(-size * 0.5f + size * (x / (float)gridSize), 0, -size * 0.5f + size * (y / (float)gridSize)));
                normals.Add(Vector3.up);
                watermesh.RecalculateNormals();
                uvs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
            }
        }

        var triangles = new List<int>();
        var vertCount = gridSize + 1;

        for (int i = 0; i < vertCount * vertCount; i++)
        {
            if ((i + 1) % vertCount == 0)
            {
                continue;
            }
            triangles.AddRange(new List<int>()
        {
            i+1+vertCount,i+vertCount,i,
            i, i+1, i+vertCount+1
        });
            //Debug.Log(triangles.Count);
            watermesh.SetVertices(vertices);
            watermesh.SetNormals(normals);
            watermesh.SetUVs(0, uvs);
            watermesh.SetTriangles(triangles, 0);

            

        }
        return watermesh;

    }

}

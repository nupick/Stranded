using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNoiseTest : MonoBehaviour {


    public float power = 3;
    public float scale = 1;
    public float timeScale = 1;

    private float offsetX;
    private float offsetY;
    private MeshFilter mf;

    Vector3[] outVertices;
    int[] outTriangles;
    // Use this for initialization
    void Start()
    {

        mf = GetComponent<MeshFilter>();
        Noise();
        RemakeMeshToDiscrete(mf.mesh.vertices, mf.mesh.triangles);
        mf.mesh.vertices = outVertices;
        mf.mesh.triangles = outTriangles;
    }

    // Update is called once per frame
    void Update()
    {
        Noise();
        offsetX += Time.deltaTime * timeScale;
        offsetY += Time.deltaTime * timeScale;
        mf.mesh.RecalculateNormals();
    }

    void Noise()
    {
        Vector3[] vertices = mf.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = CalculateHeight(vertices[i].x, vertices[i].z) * power;
        }

        mf.mesh.vertices = vertices;
        RemakeMeshToDiscrete(mf.mesh.vertices, mf.mesh.triangles);
        mf.mesh.vertices = outVertices;
        mf.mesh.triangles = outTriangles;
        

        //mf.mesh.RecalculateNormals();
    }

    float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + offsetX;
        float yCord = y * scale + offsetY;

        return Mathf.PerlinNoise(xCord, yCord);
    }

    void RemakeMeshToDiscrete(Vector3[] vert, int[] trig)
    {
        Vector3[] vertDiscrete = new Vector3[trig.Length];
        int[] trigDiscrete = new int[trig.Length];
        for (int i = 0; i < trig.Length; i++)
        {
            vertDiscrete[i] = vert[trig[i]];
            trigDiscrete[i] = i;
        }
        outVertices = vertDiscrete;
        outTriangles = trigDiscrete;
    }
}

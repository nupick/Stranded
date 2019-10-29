using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationGrid : MonoBehaviour {

    public Transform prefab;
    public int gridResolution = 10;
    Transform[] grid;

    List<Transformation> transformations;

    void Awake()
    {
        grid = new Transform[gridResolution * gridResolution * gridResolution];

        for (int i = 0 , z = 0; z<gridResolution;z++)
        {
            for (int y = 0; y<gridResolution;y++)
            {
                for(int x = 0; x < gridResolution; x++,i++)
                {
                    grid[i] = CreateGridPoint(x, y, z);
                    grid[i].name = "Cube " + i;
                }
            }
        }

        transformations = new List<Transformation>();
    }

    void Update()
    {
        GetComponents<Transformation>(transformations);

        for( int i = 0, z = 0; z<gridResolution;z++)
        {
            for (int y = 0; y<gridResolution;y++)
            {
                for (int x = 0; x<gridResolution;i++,x++)
                {
                    grid[i].localPosition = TransformPoint(x, y, z);

                }
            }
        }
    }

    Transform CreateGridPoint(int x , int y , int z)
    {
        Transform Point = Instantiate<Transform>(prefab);

        Point.localPosition = GetCoordinate(x, y, z);
        Point.GetComponent<MeshRenderer>().material.color = new Color((float)x / gridResolution, (float)y / gridResolution, (float)z / gridResolution);
        return Point;
    }

    Vector3 GetCoordinate(int x, int y, int z)
    {
        return new Vector3(
            x - (gridResolution - 1) * 0.5f,
            y - (gridResolution - 1) * 0.5f,
            z - (gridResolution - 1) * 0.5f);
    }

    Vector3 TransformPoint (int x,int y, int z)
    {
        Vector3 coordinates = GetCoordinate(x, y, z);
        for (int i = 0; i < transformations.Count; i++)
        {
            coordinates = transformations[i].Apply(coordinates);

        }
        return coordinates;
    }
}

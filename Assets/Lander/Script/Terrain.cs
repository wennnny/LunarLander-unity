using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    #region setup
    
    // mesh properties
    Mesh mesh;
    Vector3[] polygonPoint;
    int[] polygonTriangle;

    public float hight_left = 0;
    public float hight_right = 0;
    public int no;
    public RosSharp.RosBridgeClient.TerrainSubscribe terrainSubscribe;

    void Start()
    {
        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        hight_left = terrainSubscribe.scale[no-1] * 20;
        hight_right = terrainSubscribe.scale[no] * 20;
        DrawFilled();
    }
    # endregion

    void DrawFilled()
    {
        polygonPoint = GetCircumferencePoints().ToArray();
        polygonTriangle = DrawFilledTriangles(polygonPoint);
        mesh.Clear();
        mesh.vertices = polygonPoint;
        mesh.triangles = polygonTriangle;
    }

    List<Vector3> GetCircumferencePoints()
    {
        List<Vector3> points = new List<Vector3>();

        points.Add(new Vector3(-300 + 60*(no-1), -200 + hight_left, 0));
        points.Add(new Vector3(-300 + 60*(no-1), -210, 0));
        points.Add(new Vector3(-240 + 60*(no-1), -210, 0));
        points.Add(new Vector3(-240 + 60*(no-1), -200 + hight_right, 0));

        return points;
    }
    
    int[] DrawFilledTriangles(Vector3[] points)
    {
        int triangleAmount = points.Length - 2;
        List<int> newTriangles = new List<int>();
        for(int i = 0; i<triangleAmount;i++)
        {
            newTriangles.Add(0);
            newTriangles.Add(i+2);
            newTriangles.Add(i+1);
        }
        return newTriangles.ToArray();
    }
}



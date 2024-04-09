using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    #region setup
    
    // mesh properties
    Mesh mesh;
    Vector3[] polygonPoint;
    int[] polygonTriangle;

    void Start()
    {
        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;

    }

    // Update is called once per frame
    void Update()
    {
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

        points.Add(new Vector3(-60, -100, 0));
        points.Add(new Vector3(-60, -130, 0));
        points.Add(new Vector3(0, -130, 0));
        points.Add(new Vector3(0, -100, 0));
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

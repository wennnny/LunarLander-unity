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

    // polygon properties
    int polygonSize = 4;
    float polygonRadius = 42.5f;

    public float height_left = 0;
    public float height_right = 0;

    public int no;

    // Start is called before the first frame update
    // void Start()
    // {
    //     mesh = new Mesh();
    //     this.GetComponent<MeshFilter>().mesh = mesh;
    // }

    void Awake()
    {
        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        DrawFilled(polygonSize, polygonRadius, no);
    }
    # endregion

    void DrawFilled(int sides, float radius, int no)
    {
        polygonPoint = GetCircumferencePoints(sides, radius, no).ToArray();
        polygonTriangle = DrawFilledTriangles(polygonPoint);
        mesh.Clear();
        mesh.vertices = polygonPoint;
        mesh.triangles = polygonTriangle;
    }

    List<Vector3> GetCircumferencePoints(int sides, float radius, int no)
    {
        List<Vector3> points = new List<Vector3>();
        float circumferenceProgressPerStep = (float)1/sides;
        float TAU = Mathf.PI;
        float radianProgressPerStep = circumferenceProgressPerStep * TAU;

        for (int i = 0; i < sides; i++)
        {
            float currentRadian = radianProgressPerStep * (2*i+1);
            if (i == 0)
                points.Add(new Vector3(Mathf.Cos(currentRadian)*radius -270 + (60*(no-1)), Mathf.Sin(currentRadian)*radius -130 + height_right, 0));
            if (i == 1)
                points.Add(new Vector3(Mathf.Cos(currentRadian)*radius -270 + (60*(no-1)), Mathf.Sin(currentRadian)*radius -130 + height_left, 0));
            else
                points.Add(new Vector3(Mathf.Cos(currentRadian)*radius -270 + (60*(no-1)), Mathf.Sin(currentRadian)*radius -170 , 0));
        }

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

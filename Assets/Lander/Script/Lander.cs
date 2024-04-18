using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lander : MonoBehaviour
{
    #region setup
    
    // mesh properties
    Mesh mesh;
    Vector3[] polygonPoint;
    int[] polygonTriangle;
    public ParticleSystem particleSystem;
    public RosSharp.RosBridgeClient.ThrusterSubscriber thrusterSubscriber;

    public RosSharp.RosBridgeClient.LunarLanderSubscriber lunarLanderSubscriber;


    void Start()
    {
        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        DrawFilled();
        Thrust();
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

        points.Add(new Vector3(lunarLanderSubscriber.position_1[0], lunarLanderSubscriber.position_1[1]));
        points.Add(new Vector3(lunarLanderSubscriber.position_2[0], lunarLanderSubscriber.position_2[1]));
        points.Add(new Vector3(lunarLanderSubscriber.position_3[0], lunarLanderSubscriber.position_3[1]));
        points.Add(new Vector3(lunarLanderSubscriber.position_4[0], lunarLanderSubscriber.position_4[1]));
        points.Add(new Vector3(lunarLanderSubscriber.position_5[0], lunarLanderSubscriber.position_5[1]));
        points.Add(new Vector3(lunarLanderSubscriber.position_6[0], lunarLanderSubscriber.position_6[1]));

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

    public void Thrust()
    {
        if (thrusterSubscriber.isThrusting == 0)
        {
            particleSystem.Stop();
        }
        else
        {
            particleSystem.transform.position = new Vector3(lunarLanderSubscriber.position_2[0], lunarLanderSubscriber.position_2[1], -100);
            particleSystem.Play();
        }
    }
}

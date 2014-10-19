using UnityEngine;
using System.Collections;

public class TriangleBuilder : MonoBehaviour {
    public float maxY;
    public float maxX;

	// Use this for initialization
	void Start () {
        PolygonCollider2D coll = GetComponent<PolygonCollider2D>();
        //coll.CreatePrimitive(3);
        Vector2[] points = new Vector2[3]; 
        points[0] = new Vector2(0,0);
        points[1] = new Vector2(-maxX,maxY);
        points[2] = new Vector2(maxX,maxY);
        coll.SetPath(0, points);
        //mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(-maxX, maxY, 0), new Vector3(maxX, maxY, 0) };
        //mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        //mesh.triangles = new int[] { 0, 1, 2 };

        //MeshCollider meshColl = GetComponent<MeshCollider>();
        //meshColl.sharedMesh = mesh;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class iPadUpSide : MonoBehaviour
{
    public float cornerRadius = 0.1f;

    void Start()
    {
        RoundCorners();
    }

    void RoundCorners()
    {
        // Holen Sie sich den Mesh des Cubes
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        // Holen Sie sich die Eckpunkte des Meshes
        Vector3[] vertices = mesh.vertices;

        // Runden Sie die Ecken ab
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = RoundVertex(vertices[i]);
        }

        // Setzen Sie die aktualisierten Eckpunkte zurück
        mesh.vertices = vertices;

        // Aktualisieren Sie die Normals, um Beleuchtung korrekt zu berücksichtigen
        mesh.RecalculateNormals();
    }

    Vector3 RoundVertex(Vector3 vertex)
    {
        // Berechnen Sie den Abstand vom Ursprung (Mittelpunkt) des Cubes
        float distance = Mathf.Sqrt(vertex.x * vertex.x + vertex.y * vertex.y + vertex.z * vertex.z);

        // Wenn der Abstand größer als der Radius ist, runden Sie die Position ab
        if (distance > cornerRadius)
        {
            float proportion = cornerRadius / distance;
            vertex.x = proportion;
            vertex.y = proportion;
            vertex.z *= proportion;
        }

        return vertex;
    }
}

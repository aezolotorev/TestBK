using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Drawing;
using System.IO;




[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    [SerializeField]
    Texture2D texture;    
    int xSize;
    int zSize;
    public float scale;

    void Start()
    {
        
        xSize = texture.height;
        zSize = texture.width;     
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        StartCoroutine( CreateShape(texture));
       
    }

    private void Update()
    {
        UpdateMesh();
    }


    IEnumerator CreateShape(Texture2D texture)
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        int i = 0;
        for ( int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = TakeDarknes(x, z, texture);
                vertices[i] =new  Vector3(x, y, z);
                i++;
            }
        }
        triangles = new int[(xSize*zSize*6)];
        int vert = 0;
        int tris = 0;
        for ( int z = 0; z < zSize; z++)
        {
            Debug.Log("z= "+z.ToString()); 
            for (int x = 0; x < xSize; x++)
            {
               
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
                
            }
            yield return new WaitForSeconds(.01f);
            vert++;
        }
        

    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
    private float TakeDarknes(int x,int y, Texture2D texture)
    {
        var colorValue = texture.GetPixel(x, y);
        var result= (colorValue.r + colorValue.b + colorValue.g)*scale/ 3;
        return result;
    }




}

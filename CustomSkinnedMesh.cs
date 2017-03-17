using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMesh : MonoBehaviour {

    SkinnedMeshRenderer render;
    public Transform[] bonse;
    [SerializeField]
    Material mat;

    void Start() {
        render = GetComponent<SkinnedMeshRenderer>();
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {
            new Vector3(0f,     0f, 0f), // 0
            new Vector3(-1f,    2f, 0f), // 1
            new Vector3(1f,     2f, 0f), // 2
            new Vector3(0f,     4f, 0f), // 3

            new Vector3(-5f,     4f, 0f), // 4
            new Vector3(-1f,     4f, 0f), // 5
            new Vector3(-2f,     2f, 0f), // 6
            new Vector3(-1f,     0f, 0f), // 7
            
            new Vector3(1f,     4f, 0f), // 8
            new Vector3(5f,     4f, 0f), // 9
            new Vector3(2f,     2f, 0f), // 10
            new Vector3(1f,     0f, 0f), // 11
            
            new Vector3(-0.5f,     5f, 0f), // 12
            new Vector3(   0f,     4.5f, 0f), // 13
            new Vector3(-0.8f,     4.5f, 0f), // 141
            new Vector3(   0.5f,     5f, 0f), // 15
            new Vector3(   0.8f,     4.5f, 0f), // 16
            new Vector3(   0.5f,     4f, 0f), // 17
            new Vector3(   -0.5f,     4f, 0f) // 18


        };
        mesh.triangles = new int[]
        {
           0,1,2,
           1,3,2,
           4,5,6,
           5,7,6,
           8,9,10,
           8,10,11,
           12,13,14,
           13,15,16,
           16,17,13,
           13,17,18,
           13,18,14
        };
        mesh.colors = new Color[] 
        {
            Color.blue, // 0
            new Color(0,0.5f, 0.5f), // 1
            new Color(0,0.5f, 0.5f), // 2
            Color.green, // 3
            new Color(1, 1, 0.7f), // 4
            new Color(1, 1, 0.7f), // 5
            new Color(1, 1, 0.7f), // 6
            new Color(1, 1, 0.7f), // 7
            new Color(1, 1, 0.7f), // 8
            new Color(1, 1, 0.7f), // 9
            new Color(1, 1, 0.7f), // 10
            new Color(1, 1, 0.7f), // 11
            Color.red, // 12
            new Color(1,0,1), // 13
            new Color(1, 0, 1), // 14
            Color.red, // 15
            new Color(1, 0, 1), // 16
            new Color(1, 0, 1), // 17
            new Color(1, 0, 1), // 18
        };
        mesh.boneWeights = new BoneWeight[]
        {
            new BoneWeight() {boneIndex0 = 1, weight0 = 1f }, // 0
            new BoneWeight() {boneIndex0 = 1, weight0 = 1f }, // 1
            new BoneWeight() {boneIndex0 = 1, weight0 = 1f }, // 2
            new BoneWeight() {boneIndex0 = 1, weight0 = 1f }, // 3

            new BoneWeight() {boneIndex0 = 0, weight0 = 1f }, // 4
            new BoneWeight() {boneIndex0 = 5, weight0 = 1f }, // 5
            new BoneWeight() {boneIndex0 = 5, weight0 = 1f }, // 6
            new BoneWeight() {boneIndex0 = 5, weight0 = 1f }, // 7
            
            new BoneWeight() {boneIndex0 = 6, weight0 = 1f }, // 8
            new BoneWeight() {boneIndex0 = 2, weight0 = 1f }, // 9
            new BoneWeight() {boneIndex0 = 6, weight0 = 1f }, // 10
            new BoneWeight() {boneIndex0 = 6, weight0 = 1f }, // 11
            
            new BoneWeight() {boneIndex0 = 3, weight0 = 1f }, // 12
            new BoneWeight() {boneIndex0 = 1, weight0 = 1f }, // 13
            new BoneWeight() {boneIndex0 = 1, weight0 = 1f }, // 14
            new BoneWeight() {boneIndex0 = 4, weight0 = 1f }, // 15
            new BoneWeight() {boneIndex0 = 1, weight0 = 1f }, // 16
            new BoneWeight() {boneIndex0 = 1, weight0 = 1f }, // 17
            new BoneWeight() {boneIndex0 = 1, weight0 = 1f }  // 18
        };
        Matrix4x4[] bindpose = new Matrix4x4[bonse.Length];

        for (int i = 0; i < bonse.Length; ++i)
            bindpose[i] = bonse[i].worldToLocalMatrix * transform.localToWorldMatrix;

        mesh.bindposes = bindpose;
        render.sharedMesh = mesh;
        render.material = mat;
        render.bones = bonse;
        render.rootBone = transform;
        render.quality = SkinQuality.Bone1;
    }

}

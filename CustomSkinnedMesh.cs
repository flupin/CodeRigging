using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSkinnedMesh : MonoBehaviour {

    Mesh mesh;
    SkinnedMeshRenderer render;

    public Material mat;
    public Transform[] bones;

	// Use this for initialization
	void Start () {

        render = GetComponent<SkinnedMeshRenderer>();
        mesh = new Mesh();
        mesh.name = "testSkinnedMesh";

        mesh.vertices = new Vector3[]
        {
            new Vector3( -2f, 9f, 0f ),
            new Vector3( 2f, 9f, 0f ),
            new Vector3( 0f, 6f, 0f ), 

            new Vector3( -4f, 6f, 0f ),
            new Vector3( 4f, 6f, 0f ),
            new Vector3( 0f, 0f, 0f ), 

            new Vector3( -1f, -1f, 0f ),
            new Vector3( 1f, -1f, 0f ),
            new Vector3( 0f, -2f, 0f ), 

            new Vector3( -1f, -7f, 0f ),
            new Vector3( -3f, -7f, 0f ),
            new Vector3( 3f, -7f, 0f ), 

            new Vector3( 1f, -7f, 0f ), //12
            new Vector3( -4f, 1f, 0f ),
            new Vector3( -6f, 1f, 0f ),

            new Vector3( 4f, 1f, 0f ),
            new Vector3( 6f, 1f, 0f ),


        };
        mesh.triangles = new int[]
        {
            0,1,2, // head
            3,4,5, // body
            6,5,7, // pelvis up
            7,8,6, // pelvis down
            6,9,10, // left leg
            7,11,12, // right leg
            3,13,14, // left arm
            4,15,16 // right arm
        };

        Matrix4x4[] bindpose = new Matrix4x4[bones.Length];

        for(int i = 0; i< bones.Length; ++i)
        {
            bindpose[i] = bones[i].worldToLocalMatrix * transform.worldToLocalMatrix;
        }
        mesh.bindposes = bindpose;

        mesh.boneWeights = new BoneWeight[]
        {
            new BoneWeight() { boneIndex0 = 0, weight0 = 1f},
            new BoneWeight() { boneIndex0 = 0, weight0 = 1f},
            new BoneWeight() { boneIndex0 = 0, weight0 = 1f},
            new BoneWeight() { boneIndex0 = 1, weight0 = 1f}, // 3
            new BoneWeight() { boneIndex0 = 2, weight0 = 1f}, // 4
            new BoneWeight() { boneIndex0 = 3, weight0 = 1f}, // 5
            new BoneWeight() { boneIndex0 = 5, weight0 = 1f}, // 6
            new BoneWeight() { boneIndex0 = 5, weight0 = 1f}, // 7
            new BoneWeight() { boneIndex0 = 3, weight0 = 1f}, // 8
            new BoneWeight() { boneIndex0 = 4, weight0 = 1f}, // 9
            new BoneWeight() { boneIndex0 = 4, weight0 = 1f}, // 10
            new BoneWeight() { boneIndex0 = 5, weight0 = 1f}, // 11
            new BoneWeight() { boneIndex0 = 5, weight0 = 1f}, // 12
            new BoneWeight() { boneIndex0 = 1, weight0 = 1f}, // 13
            new BoneWeight() { boneIndex0 = 1, weight0 = 1f}, // 14
            new BoneWeight() { boneIndex0 = 2, weight0 = 1f}, // 15
            new BoneWeight() { boneIndex0 = 2, weight0 = 1f}  // 16
        };


        render.sharedMesh = mesh;
        render.sharedMaterial = mat;

        render.bones = bones;
        render.rootBone = transform;
        render.quality = SkinQuality.Bone1;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

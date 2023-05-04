using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class UpdateNavmesh : MonoBehaviour
{
    public NavMeshSurface surface;

    private void Start() {
        

        surface.BuildNavMesh();
        InvokeRepeating("UpdateMesh", 2f, 0.5f);
    }

    private void UpdateMesh() {
        surface.RemoveData();
        surface.BuildNavMesh();
    }
}

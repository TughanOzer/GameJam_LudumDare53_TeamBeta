using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartup : MonoBehaviour
{
    [SerializeField] List<GameObject> startupPrefabs = new List<GameObject>();


    void Start()
    {
        foreach(GameObject obj in startupPrefabs) {
            Instantiate(obj);
        }
    }

}

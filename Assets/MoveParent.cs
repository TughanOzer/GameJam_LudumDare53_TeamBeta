using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParent : MonoBehaviour
{

    public GameObject movedObjectToRoot;
    // Start is called before the first frame update
    void Start()
    {
        movedObjectToRoot.transform.SetParent(null);
        
        Debug.Log("This");
    }
}

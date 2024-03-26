using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabspawn : MonoBehaviour
{
    public GameObject WorldMap;
    public GameObject imageObject;

    void Start()
    {
        // Get the position of the Image GameObject
        Vector3 imagePosition = imageObject.transform.position;

        // Create an instance of the prefab at the position of the Image GameObject
        Instantiate(WorldMap, imagePosition, Quaternion.identity, imageObject.transform);
    }
}

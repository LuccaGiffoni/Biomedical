using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAction : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public void CreateObject()
    {
        var position = new Vector3(GetUserPosition.headRay.Position.x, GetUserPosition.headRay.Position.y, GetUserPosition.headRay.Position.z + (float)0.65);
        var rotation = prefab.transform.rotation;

        Instantiate(prefab, position, rotation);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}

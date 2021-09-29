using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAction : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private IMixedRealityPointer headRay;

    // Destroy the object attached to the script
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    // Instantiate a prefab at runtime
    private void Update()
    {
        foreach(var source in CoreServices.InputSystem.DetectedInputSources)
        {
            if (source.SourceType == InputSourceType.Hand)
            {
                foreach (var p in source.Pointers)
                {
                    if (p is IMixedRealityNearPointer)
                    {
                        continue;
                    }
                    if (p.Result != null)
                    {
                        headRay = p;
                    }
                }
            }
        }
    }

    public void CreateObject()
    {
        var position = new Vector3(headRay.Position.x, headRay.Position.y, headRay.Position.z + (float)0.65);
        var rotation = prefab.transform.rotation;

        Instantiate(prefab, position, rotation);
    }
}

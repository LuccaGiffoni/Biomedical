using Microsoft.MixedReality.OpenXR;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUserPosition : MonoBehaviour
{
    private IMixedRealityPointer headRay;
    [SerializeField] private Material highlight;

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
                        var startPoint = p.Position;
                        var endPoint = p.Result.Details.Point;
                        var hitObject = p.Result.Details.Object;
                        headRay = p;

                        // Testing the pointer
                        if (hitObject)
                        {
                            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            Renderer rend = sphere.GetComponent<Renderer>();
                            rend.material = highlight;
                            sphere.transform.localScale = Vector3.one * 0.01f;
                            sphere.transform.position = p.Position;
                        }
                    }
                }
            }
        }
    }

    public void SetObjectNearUser()
    {
        var position  = headRay.Position;

        gameObject.transform.position = new Vector3(headRay.Position.x, headRay.Position.y, headRay.Position.z + (float)0.65);
    }
}

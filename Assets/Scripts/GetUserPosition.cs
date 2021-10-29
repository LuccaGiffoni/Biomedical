using Microsoft.MixedReality.OpenXR;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUserPosition : MonoBehaviour
{
    public static IMixedRealityPointer headRay;

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
                        Debug.Log(p.Position.ToString());
                        headRay = p;
                    }
                }
            }
        }
    }
}

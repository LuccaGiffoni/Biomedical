using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectNear : MonoBehaviour
{
    public void SetObjectNearUser()
    {
        // Throw object near user
        gameObject.transform.position = new Vector3(GetUserPosition.headRay.Position.x - 1, GetUserPosition.headRay.Position.y, GetUserPosition.headRay.Position.z + (float)0.65);

        // Set the object visible or not
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}

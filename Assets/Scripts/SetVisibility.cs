using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVisibility : MonoBehaviour
{
    [SerializeField] private GameObject pdfMenu;

    public void ActiveBool()
    {
        // Set the object visible or not
        if (pdfMenu.activeInHierarchy)
        {
            pdfMenu.SetActive(false);
        }
        else
        {
            pdfMenu.SetActive(true);
        }
    }
}

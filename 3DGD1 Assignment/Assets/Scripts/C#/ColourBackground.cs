using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourBackground : MonoBehaviour
{

    public Material nMaterial;
    // Start is called before the first frame update
    public void setColourtoRed()
    {
        nMaterial.SetColor("_Color", Color.red);
    }

        
    
}

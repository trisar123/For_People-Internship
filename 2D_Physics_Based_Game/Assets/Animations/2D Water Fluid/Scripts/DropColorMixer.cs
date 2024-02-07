using UnityEngine;

/***************************************************
 *  * Copyright Azerilo asset store:
 * https://assetstore.unity.com/publishers/36324
 * This script enables color mixing for the drops
 ***************************************************/

namespace AzeriloNamespace
{

    public class DropColorMixer : MonoBehaviour
    {
        Color dropColor;               // It is the current drop color
        public bool mixColors = true;  // If this is set to true then the colors mix together

        void Start()
        {
             dropColor = GetComponent<Renderer>().material.GetColor("_Drop_Color");
        }

        // When the drops collide, their colors mix together
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (mixColors)
            {
                if (collision.gameObject.layer == 4)
                {
                    Color otherColor = collision.gameObject.GetComponent<Renderer>().material.GetColor("_Drop_Color");

                    if (dropColor != otherColor)
                    {
                        Color mixedColor = new Color((dropColor.r + otherColor.r) / 2, (dropColor.g + otherColor.g) / 2, (dropColor.b + otherColor.b) / 2, 0);
                        GetComponent<Renderer>().material.SetColor("_Drop_Color", mixedColor);
                        collision.transform.GetComponent<Renderer>().material.SetColor("_Drop_Color", mixedColor);
                        dropColor = mixedColor;
                    }
                }
            }

        }
    }
}
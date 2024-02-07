using UnityEngine;

/***************************************************
 *  * Copyright Azerilo asset store:
 * https://assetstore.unity.com/publishers/36324
 * 
 ***************************************************/

namespace AzeriloNamespace
{

    // This class defines when to destroy the drop
    public class DropDestroyer : MonoBehaviour
    {
        public float destroyAfterSeconds = -1;
        public bool destroyOutsideBound = false;
        public float minX = 0;
        public float maxX = 0;
        public float minY = 0;
        public float maxY = 0;

        void Start()
        {
            if (destroyAfterSeconds > -1)
            {
                Destroy(gameObject, destroyAfterSeconds);
            }
        }

        void Update()
        {
            if (destroyOutsideBound)
            {
                if (transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

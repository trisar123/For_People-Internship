using UnityEngine;

/***************************************************
 * Copyright Azerilo asset store:
 * 
 * https://assetstore.unity.com/publishers/36324
 * 
 ***************************************************/

namespace AzeriloNamespace
{

    // This is the main class for spawning drops
    public class WaterSpawner : MonoBehaviour
    {
        GameObject DropsParent;                   // This the parent gameobject of all drops
        public GameObject waterDropPrefab;        // Drag the "Drop Quad" prefab here. This is the water drop to be spawned
        public Transform renderQuad;              // Drag the "Render Quad" from the hierarchy to here
        public Material dropMaterial;             // Set the drop material
        [Range(0f, 1.0f)]
        public float opacity = 1.0f;              // Defines the water opacity
        public int dropsCount = 1000;             // The maximum drops to spawn
        int spawnedDrops;                         // Current number of the spawned drops
        public float dropDrag = 0;                // Sets the drop's drag. 0 means no drag. value bigger than 0 means more drag 
        public float dropGravityScale = 1;        // Sets the gravity scale of each drop. Bigger value means more gravity force
        [Range(0, 1.0f)]
        public float dropFriction = 0;            // Sets the drop friction against each other and surfaces.
        [Range(0, 1.0f)]
        public float dropBounciness = 0.2f;       // Sets the drop bounciness against each other and surfaces.
        public float minDropSize = 1.5f;          // Minimum size of each drop
        public float maxDropSize = 2.5f;          // Maximum size of each drop
        public float destroyAfterSeconds = -1;    // After this time the drop will be destroyed. -1 means never destroy drops
        public bool destroyOutsideBound = false;  // If sets to true when the drop goes outside of the min and max bounds it will be destroyed
        public float BoundMinX = 0;               // Set minimum x positon of the bound here
        public float BoundMaxX = 0;               // Set maximum x positon of the bound here
        public float BoundMinY = 0;               // Set minimum y positon of the bound here
        public float BoundMaxY = 0;               // Set maximum y positon of the bound here
        public float timeBetweenSpawning = 15f; // This is the time in milliseconds between spawning the drops. Lower value = Faster spawning
        [Range(0, 1.0f)]
        public float randomSpawnRange = 0.1f;     // Set a rendom distance here to randomly change the spawner position. Enter 0 if you don't want to change the spawner position randomly
        public bool shakingX = false;             // If is set to true the spawner position will shake in X direction
        public bool shakingY = false;             // If is set to true the spawner position will shake in Y direction
        public float shakingRange = 4;            // Sets the shaking distance
        public float shakingSpeed = 5;            // Sets the shaking speed
        float totalShakeTime;

        public bool useForce = false;             // Use the Physics force to shoot drops to the desired direction
        public float forcePower = 6;              // The force power
        [Range(-1.0f, 1.0f)]
        public float forceDirectionX = 0;         // Sets the value of x direction. 0 = no force in x direction 
        [Range(-1.0f, 1.0f)]
        public float forceDirectionY = 0;         // Sets the value of y direction. 0 = no force in y direction

        float x;
        float y;
        float tempX = 0;
        float tempY = 0;
        bool isSpawning = false;
        float timeTotal = 0;

        void Start()
        {
            x = tempX = transform.position.x;
            y = tempY = transform.position.y;

            Initialize();
        }

        void Initialize()
        {
            totalShakeTime = 0;
            spawnedDrops = 0;
            isSpawning = false;
            timeTotal = 0;

            renderQuad.GetComponent<Renderer>().material.SetFloat("_Opacity", opacity);

            // Sets the physics properties of the drop
            var dropRigidbody = waterDropPrefab.GetComponent<Rigidbody2D>();
            dropRigidbody.drag = dropDrag;
            dropRigidbody.angularDrag = dropDrag;
            dropRigidbody.gravityScale = dropGravityScale;

            var dropPhysicMaterial = dropRigidbody.sharedMaterial;
            dropPhysicMaterial.friction = dropFriction;
            dropPhysicMaterial.bounciness = dropBounciness;

            // Define when to destroy the drop
            var dropDestroyer = waterDropPrefab.GetComponent<DropDestroyer>();
            dropDestroyer.destroyAfterSeconds = destroyAfterSeconds;
            dropDestroyer.minX = BoundMinX;
            dropDestroyer.maxX = BoundMaxX;
            dropDestroyer.minY = BoundMinY;
            dropDestroyer.maxY = BoundMaxY;
            dropDestroyer.destroyOutsideBound = destroyOutsideBound;
        }

        void Update()
        {
            if (isSpawning)
            {
                if (shakingX || shakingY)
                    ShakeIt();

                if (timeTotal < (timeBetweenSpawning / 1000))
                    timeTotal += Time.deltaTime;
                else
                {
                    SpawnDrop();
                    timeTotal = 0;
                }
            }
        }


        // Shake the spawner
        void ShakeIt()
        {
            totalShakeTime += Time.deltaTime * shakingSpeed;
            float dis = Mathf.Abs(Mathf.Sin(totalShakeTime)) * shakingRange;

            if (shakingX)
                tempX = x + dis;
            else
                tempX = x;

            if (shakingY)
                tempY = y + dis;
            else
                tempY = y;

            transform.position = new Vector3(tempX, tempY, transform.position.z);
        }

        // The main method for spawning a drop
        void SpawnDrop()
        {
            if (spawnedDrops < dropsCount)
            {
                Vector3 pos = new Vector3(transform.position.x + Random.Range(-randomSpawnRange, randomSpawnRange), transform.position.y + Random.Range(-randomSpawnRange, randomSpawnRange), 0);
                var waterDrop = Instantiate(waterDropPrefab, pos, Quaternion.identity);
                waterDrop.GetComponent<Renderer>().material = dropMaterial;
                waterDrop.transform.parent = DropsParent.transform;
                waterDrop.name = "Drop " + (spawnedDrops + 1);
                waterDrop.transform.localScale = Vector3.one * Random.Range(minDropSize, maxDropSize);

                // If useForce is true apply force to the drop
                if (useForce)
                {
                    Rigidbody2D rb = waterDrop.GetComponent<Rigidbody2D>();

                    rb.AddForce(new Vector2(forceDirectionX, forceDirectionY) * forcePower, ForceMode2D.Impulse);
                }

                spawnedDrops++;
            }
            else
                StopSpawning();

        }

        public void StartSpawning()
        {
            if (DropsParent == null)
                DropsParent = new GameObject("Drops");

            isSpawning = true;
        }

        public void StopSpawning()
        {
            isSpawning = false;
            Initialize();
        }

        public void Reset()
        {
            StopSpawning();
            Destroy(DropsParent);
        }

    }

}

using UnityEngine;

/***************************************************
 *  * Copyright Azerilo asset store:
 * https://assetstore.unity.com/publishers/36324
 * 
 ***************************************************/

namespace AzeriloNamespace
{

    // This class defines actions for the UI buttons
    public class UiManager : MonoBehaviour
    {
        public WaterSpawner waterSpawner1;   // Drag the waterSpawner1 gameobject here
        public WaterSpawner waterSpawner2;   // Drag the waterSpawner2 gameobject here
                                             // You can add as many spawner as you like. I have used two spawner here to show you how to add multiple water spawners.

        public void StartSpawner1()
        {
            waterSpawner1.StartSpawning();            
        }

        public void StopSpawner1()
        {
            waterSpawner1.StopSpawning();
        }

        public void ResetSpawner1()
        {
            waterSpawner1.Reset();
        }

        public void StartSpawner2()
        {
            waterSpawner2.StartSpawning();
        }

        public void StopSpawner2()
        {
            waterSpawner2.StopSpawning();
        }

        public void ResetSpawner2()
        {
            waterSpawner2.Reset();
        }
    }
}

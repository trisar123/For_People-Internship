using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndTriggerSwitchN : MonoBehaviour {

	public string sceneToLoad;
	void OnCollisionEnter(Collision other) {
		
		if (other.gameObject.tag=="win") 
        {
			
			SceneManager.LoadScene(sceneToLoad);
		}
	}
}
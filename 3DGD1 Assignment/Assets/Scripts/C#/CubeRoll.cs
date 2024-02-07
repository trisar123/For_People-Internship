using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeRoll : MonoBehaviour {
	public Transform cubeMesh;
	public bool rollForever = false;
	private float rollSpeed = 400;
	private bool isMoving = false;
	private RaycastHit hit;
	public Vector3 pivot;
	private float cubeSize = 1; // Block cube size
	public static int steps;
	
	public enum CubeDirection {none, left, up, right, down};
	public CubeDirection direction = CubeDirection.none;

	Quaternion lastRotation;
	
	void Start() {
		steps =500;
		lastRotation = Quaternion.identity;
	}

	void Update() {
		if(direction == CubeDirection.none) {
			//if we are niot moving in this frame, listen to input
			if (Input.GetKeyDown(KeyCode.D)) {
				direction = CubeDirection.right;
				
			}
			else if (Input.GetKeyDown(KeyCode.A)) {
				direction = CubeDirection.left;
				
			}
			else if (Input.GetKeyDown(KeyCode.W)) {
				direction = CubeDirection.up;
				
			}
			else if (Input.GetKeyDown(KeyCode.S)) {
				direction = CubeDirection.down;
				
			}
		}
		else {
			if(!isMoving) {
				
				if(CheckCollision(direction)) {
					//if a wall is blocking, then we stop moving
					isMoving = false;
					direction = CubeDirection.none;
					
					//if a push block is in the way we will push it
					if (hit.collider.gameObject.GetComponent<PushBlock>())
					{
						hit.collider.gameObject.GetComponent<PushBlock>().Move((transform.position - hit.collider.transform.position).normalized, 1);
					}

					return;
				} else {
					CalculatePivot();
					DeductStepCount();
					isMoving = true;
				}
			}

			switch(direction) {
				case CubeDirection.right:
					cubeMesh.transform.RotateAround(pivot, -Vector3.forward, rollSpeed * Time.deltaTime);
					if (Quaternion.Angle(lastRotation, cubeMesh.transform.rotation)> 90)
						ResetPosition();
					break;
				case CubeDirection.left:
					cubeMesh.transform.RotateAround(pivot, Vector3.forward, rollSpeed * Time.deltaTime);
					if (Quaternion.Angle(lastRotation, cubeMesh.transform.rotation) > 90)
						ResetPosition();
					break;
				case CubeDirection.up:
					cubeMesh.transform.RotateAround(pivot, Vector3.right, rollSpeed * Time.deltaTime);
					if (Quaternion.Angle(lastRotation, cubeMesh.transform.rotation) > 90)
						ResetPosition();
					break;
				case CubeDirection.down:
					cubeMesh.transform.RotateAround(pivot, -Vector3.right, rollSpeed * Time.deltaTime);
					if (Quaternion.Angle(lastRotation, cubeMesh.transform.rotation) > 90) {
						ResetPosition();
					}
					break;
			}
		}

		if(transform.position.y <= -10) {
			SceneManager.LoadScene("Lose");
		}
	}
	//stops the cube after it finishes moving
	void ResetPosition() {
		//resets the rotatation of the cube mesh, and moves the Player cube object to the position of the cube mesh. finally it centres the cube mesh back on the player cube.
		//cubeMesh.transform.rotation = Quaternion.Euler(Vector3.zero);
		lastRotation = cubeMesh.transform.rotation=Quaternion.Euler(
			Mathf.Round(cubeMesh.transform.rotation.eulerAngles.x/90)*90,
			Mathf.Round(cubeMesh.transform.rotation.eulerAngles.y/90)*90,
			Mathf.Round(cubeMesh.transform.rotation.eulerAngles.z/90)*90
			
			);
		transform.position = new Vector3(
			Mathf.Ceil(cubeMesh.transform.position.x) - 0.5f,
			transform.position.y, 
			Mathf.Ceil(cubeMesh.transform.position.z) - 0.5f
		);
		cubeMesh.transform.localPosition = Vector3.zero;
		isMoving = false; // so the cube does not continue to move


		if (!rollForever)
			direction = CubeDirection.none;
	}

	void CalculatePivot() {
		//setting the pivot based on which direction we are moving
		switch(direction) {
			case CubeDirection.right:
				pivot = new Vector3(1, -1, 0);
				break;
			case CubeDirection.left:
				pivot = new Vector3(-1, -1, 0);
				break;
			case CubeDirection.up:
				pivot = new Vector3(0, -1, 1);
				break;
			case CubeDirection.down:
				pivot = new Vector3(0, -1, -1);
				break;
		}

		// Calculates the point around which the block will flop
		pivot = transform.position + (pivot * cubeSize * 0.5f);
		if(GetComponent<AudioSource>())
			GetComponent<AudioSource>().Play(); // Play the flop sound 
	}

	bool CheckCollision(CubeDirection direction) {
		switch(direction) {
			case CubeDirection.right:
				Physics.Linecast(transform.position, transform.position + transform.right* 1, out hit);
				Debug.DrawLine(transform.position, transform.position + transform.right* 1, Color.black);
				break;
			case CubeDirection.left:
				Physics.Linecast(transform.position, transform.position + transform.right* -1, out hit);
				Debug.DrawLine(transform.position, transform.position + transform.right* -1, Color.black);
				break;
			case CubeDirection.up:
				Physics.Linecast(transform.position, transform.position + transform.forward* 1, out hit);
				Debug.DrawLine(transform.position, transform.position + transform.forward* 1, Color.black);
				break;
			case CubeDirection.down:
				Physics.Linecast(transform.position, transform.position + transform.forward* -1, out hit);
				Debug.DrawLine(transform.position, transform.position + transform.forward* -1, Color.black);
				break;
		}

		if(hit.collider == null || (hit.collider != null && hit.collider.isTrigger && !hit.collider.GetComponent("Player"))) {
			return false;
		} else {
			return true;
		}
	}

	void DeductStepCount() {
		steps -= 1;

		if(steps <= 0) {
			steps = 0;
		}
	}
}
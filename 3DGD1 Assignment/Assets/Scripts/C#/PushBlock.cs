﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour {
	public Vector3 targetPosition;
	public bool isMoving = false;
	private float yOrigin;
	public LayerMask ground;
	public Vector3 velocity;

	void Start() {
		targetPosition = transform.position;
		yOrigin = 0;

	}

	void Update() {
		Vector2 pos = new Vector3(transform.position.x,transform.position.z);
		Vector2 targ = new Vector3(targetPosition.x, targetPosition.z);
		Vector3 dist = pos - targ;

		
		if(dist.sqrMagnitude< 0.0001f) {
			isMoving = false;
		} else if (isMoving) {
			// Fix position
			transform.position = Vector3.Lerp(transform.position, targetPosition, 8 * Time.deltaTime);
		}


	}

	public void Move(Vector3 direction, int distance) {
		RaycastHit hit;
		Debug.Log("yes");
		Physics.Linecast(transform.position, transform.position + direction * -1, out hit);
		Debug.DrawLine(transform.position, transform.position + direction * -1, Color.red);
		if (hit.collider != null && !hit.collider.isTrigger) {
			Debug.Log(hit.collider.name);
		} else {
			transform.position = new Vector3(Mathf.Ceil(transform.position.x) - 0.5f, yOrigin, Mathf.Ceil(transform.position.z) - 0.5f);
			targetPosition = transform.position + (direction * -distance);
			isMoving = true;
			targetPosition = new Vector3(targetPosition.x, yOrigin, targetPosition.z);
		}

	}
}
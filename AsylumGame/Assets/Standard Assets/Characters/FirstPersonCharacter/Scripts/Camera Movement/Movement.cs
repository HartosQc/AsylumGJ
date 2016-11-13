using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 0.00015f;
	private Transform startMarker;
	private Vector3 endMarker;
	private float startTime;
	private float journeyLength;
	private bool moving;

	public void Update() {
		if (moving) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startMarker.position, endMarker, fracJourney);
			if (transform.position == endMarker)
				moving = false;
		}
	}

	public void move(Vector3 movement) {
		if (!moving) {
			startMarker = transform;
			endMarker = transform.position + movement;
			startTime = Time.time;
			journeyLength = Vector3.Distance(startMarker.position, endMarker);
			moving = true;
		}
	}

	public bool isMoving() {
		return moving;
	}
}

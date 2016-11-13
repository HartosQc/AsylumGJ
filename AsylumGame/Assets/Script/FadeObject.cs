using UnityEngine;
using System.Collections;

public class FadeObject : MonoBehaviour {

	Color colorStart;
	Color colorEnd;
	float duration = .1f;
	bool isFading = false;
	const float DISTANCE_MAX = 20;
	GameObject player;
	float distance;

	// Use this for initialization
	void Start () {
		colorStart = GetComponent<MeshRenderer> ().material.color;
		colorEnd = new Color(colorStart.r, colorStart.g, colorStart.b, 0.0f);
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		distance = Vector3.Distance (player.transform.position, this.transform.position);
		updateAlpha ();



	}

	public void fadeMoney()
	{
		for (float t = 0.0f; t < duration; t += Time.deltaTime) {
			GetComponent<MeshRenderer> ().material.color = Color.Lerp (colorStart, colorEnd, t/duration);
		}

		if (GetComponent<MeshRenderer> ().material.color.a <= 0f) {
			Debug.Log ("Money Fading Over");
			isFading = false;
		}
	}

	public void updateAlpha()
	{
		float alpha = distance / DISTANCE_MAX;
		//Debug.Log ("Alpha " + alpha);

		GetComponent<MeshRenderer> ().material.color = new Color(colorStart.r, colorStart.g, colorStart.b, alpha); 

		if (alpha < 0.3f) {

			GetComponentInParent<moneyEvent> ().destroyEvent ();
			GetComponent<MeshRenderer> ().material.color = new Color(colorStart.r, colorStart.g, colorStart.b, 0.0f); 
		}
	}
}

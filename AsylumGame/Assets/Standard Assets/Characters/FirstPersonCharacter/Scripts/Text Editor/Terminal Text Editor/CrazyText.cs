using UnityEngine;
using System.Collections;

public class CrazyText : MonoBehaviour {

	public float crazyTextSpeed = 0.2f;
	private bool ended;
	
	// Update is called once per frame
	void Update () {
		if(!ended) StartCoroutine(crazyTextLoop());
	}
		
	IEnumerator crazyTextLoop() {
		ended = true;
		while (ended) {
			yield return new WaitForSeconds (crazyTextSpeed);
		}
	}
}

using UnityEngine;
using System.Collections;

public class InstanciateRnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void instanciate(GameObject go)
	{
		Rigidbody babyInstances = Instantiate (go, randPos (), transform.rotation) as Rigidbody;

		Destroy (babyInstances, 1f);


	}

	Vector3 randPos()
	{
		int a = Random.Range (-50, 50);
		int c = Random.Range (-50, 50);

		return new Vector3 (a, 1, c);
	}
}

using UnityEngine;
using System.Collections;

public class slideBack : MonoBehaviour {

	GameObject back;
	public GameObject smoke;
	Vector3 targetPos = new Vector3(0,70,50);
	Vector3 initPos;
	float slideTime = 0.1f;

	// Use this for initialization
	void Start () 
	{
		back = GameObject.FindGameObjectWithTag ("Back");
		initPos = back.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public bool slideDown()
	{
		//back.transform.position = Vector3.Lerp(back.transform.position,initPos,10 *  Time.deltaTime);
		back.transform.position = Vector3.MoveTowards(back.transform.position, initPos, Time.deltaTime * 100);
		Debug.Log ("DOWN");
		if (back.transform.position.y <= 50) 
		{
			//Animation Over
			GameObject smokeClone = smoke;
			Instantiate (smoke);
			Destroy (smokeClone, 5f);
			back.transform.position = initPos;
			return true;
		}
		return false;
	}

	public void slideUp()
	{
		back.transform.position = Vector3.Lerp(back.transform.position,targetPos,slideTime * Time.deltaTime);

		Debug.Log (back.transform.position.y);

	}
}

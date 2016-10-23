using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	private Rigidbody2D rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		Vector2 newPosition = new Vector2(transform.position.x + 0.1f, transform.position.y);
		rigidBody.MovePosition(newPosition);
		Debug.Log(newPosition);
	}
}

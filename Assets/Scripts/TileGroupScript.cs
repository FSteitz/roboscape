using UnityEngine;
using System.Collections;

public class TileGroupScript : MonoBehaviour {

	private void Awake () {
		foreach (Transform childTransform in transform) {
			TileScript tileScript = (TileScript) childTransform.gameObject.GetComponent("TileScript");

			if (tileScript != null) {
				tileScript.enabled = false;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TileScript : MonoBehaviour {

	public decimal tileOffset = 0.6m;

	private decimal x = 0m;
	private decimal y = 0m;

	private void Update () {
		if (transform.hasChanged) {
			decimal x = calculatePositionOnAxis((decimal) transform.position.x);
			decimal y = calculatePositionOnAxis((decimal) transform.position.y);

			transform.position = new Vector2((float) x, (float) y);
			transform.hasChanged = false;
		}
	}

	private decimal calculatePositionOnAxis(decimal axis) {
		if (axis % tileOffset != 0m) {
			axis += (tileOffset - (axis % tileOffset));
		}

		return axis;
	}
}

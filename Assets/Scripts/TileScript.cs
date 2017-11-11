﻿using UnityEngine;
using System.Collections;

/// Copyright 2016 Florian Steitz
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///   http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///
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

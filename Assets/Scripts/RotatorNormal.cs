﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorNormal : MonoBehaviour {

	void Start () {

	}

	void Update () {
		transform.Rotate (new Vector3 (0, 45, 0) * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTouchToScale : MonoBehaviour
{
    void OnMouseDown() {
		Scalling.ScaleTransform = this.transform;
	}
}

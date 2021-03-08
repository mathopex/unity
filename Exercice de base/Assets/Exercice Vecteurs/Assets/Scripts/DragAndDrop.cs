using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

	public LayerMask layerMask;
	public float speed = 0.1f;
	
	
	// Update is called once per frame
	void OnMouseDrag () {
		//print("OnMouseDrag");
		Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(r, out hit,100, layerMask.value))
		{
			//print("hit" + hit.collider.name+ " "+hit.collider.gameObject.layer);
			transform.position = Vector3.Lerp(transform.position, hit.point,speed);

		}
	}
}

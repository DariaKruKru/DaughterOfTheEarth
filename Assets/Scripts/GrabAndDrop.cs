//using UnityEngine;
//using System.Collections;
//
//public class GrabAndDrop : MonoBehaviour {
//
//	GameObject grabbedObject
//
//	GameObject GetMouseHoverObject(float range){
//		Vector3 position = gameObject.transform.position;
//		RaycastHit raycastHit;
//		Vector3 target = position + Camera.main.transform.forward * range;
//		if (Physics.Linecast (position, target, out raycastHit))
//						return raycastHit.collider.gameObject;
//		return null;
//						
//					
//	}
//
//	void Update () {
//
//	}
//}


using UnityEngine;



public class GrabAndDrop:MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;
	
	
	void OnMouseDown()
	{ 
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag() 
	{  
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition   = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
}
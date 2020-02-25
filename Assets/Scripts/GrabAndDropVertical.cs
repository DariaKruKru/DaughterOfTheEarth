using UnityEngine;

public class GrabAndDropVertical:MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 localPosition;
	public bool characterOn;
	private Vector3 characterPos;
	public float bounds = 3.5f;


	void OnMouseDown()
	{ 
		localPosition = gameObject.transform.position;

		characterPos = GameObject.Find ("Player").transform.position;

		if ((characterPos.x > (localPosition.x - gameObject.transform.localScale.x)) &&
				(characterPos.x < (localPosition.x + gameObject.transform.localScale.x))) {
				characterOn = true; 		
			} else {
				characterOn = false;
			}

				screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
				offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			
	}		
	
	void OnMouseDrag() 
	{  
		if (characterOn) {
			transform.position += Vector3.zero;
		}
		else {
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);		
			Vector3 curPosition  = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			if (Mathf.Abs(curPosition.y-localPosition.y) > bounds){

				if (curPosition.y > localPosition.y)
					curPosition.y = bounds + localPosition.y;
				else
					curPosition.y = localPosition.y - bounds;
			}
			transform.position = new Vector3( transform.position.x, curPosition.y, transform.position.z);
		}
	}
}
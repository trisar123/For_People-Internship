using UnityEngine;

public class RopeCutter : MonoBehaviour {

	public GameObject Rope;
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null)
			{
				if (hit.collider.tag == "Link")
				{
					Rope = hit.collider.gameObject.GetComponentInParent<Rope>().gameObject;
					Destroy(hit.collider.gameObject);
					Rope.GetComponent<Rope>().DestroyRope();
				}
			}
		}
	}

}

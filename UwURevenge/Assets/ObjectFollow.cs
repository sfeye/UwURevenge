using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public Transform target;
	public float speed = 5f;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = target.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		var newRotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);

		Vector3 newPosition = target.transform.position - target.transform.forward * offset.z - target.transform.up * offset.y;
		transform.position = Vector3.Slerp(transform.position, newPosition, speed * Time.deltaTime);
	}
}
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private InputAction pressed, axis;
	
	private Transform cam;
	[SerializeField] private float speed = 1;
	[SerializeField] private bool inverted;
    Rigidbody rb;
	private Vector2 rotation;
	private bool rotateAllowed;
	private void Awake() 
	{
        rb = GetComponent<Rigidbody>();
		cam = Camera.main.transform;
		pressed.Enable();
		axis.Enable();
		pressed.performed += _ => { StartCoroutine(Move()); };
		pressed.canceled += _ => { rotateAllowed = false; };
		axis.performed += context => { rotation = context.ReadValue<Vector2>(); };	
	}

	private IEnumerator Move()
	{
		rotateAllowed = true;
		while(rotateAllowed)
		{
			// apply rotation
			rotation *= speed;
            rb.AddForce(rotation);
			// transform.Translate(Vector3.left * speed, Space.World);
            Debug.Log(rotation);
			// transform.Translate(cam.right * (inverted? -1: 1), rotation.y, Space.World);
			yield return null;
		}
	}

}

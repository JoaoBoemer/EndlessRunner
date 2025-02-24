using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
	private Touch touch;
	[SerializeField] private float speed = 1;
    Rigidbody rb;
	private void Awake() 
	{
        rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
		if(Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);

			if(touch.phase == UnityEngine.TouchPhase.Moved)
			{
				transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z);
			}
		}
    }
}
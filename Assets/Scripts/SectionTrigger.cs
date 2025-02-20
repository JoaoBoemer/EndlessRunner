using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MapTrigger"))
        {
            Instantiate(roadSection, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}

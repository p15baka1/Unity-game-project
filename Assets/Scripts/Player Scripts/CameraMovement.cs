using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; //reference to what the camera will follow
    public float smoothing; //how quickly the camera moves towards the target

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);


            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);


        }
    }
}

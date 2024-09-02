using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform startPosition; // The starting position of the camera
    public Transform endPosition; // The ending position of the camera
    public float smoothTime = 0.3f; // The time it takes for the camera to smoothly move from one position to another
    public float speed = 2f;
    public Vector3 velocity = Vector3.zero; // The velocity at which the camera moves
    public GameObject midPosition;

    public bool moveToEndPosition = false; // Flag to determine if the camera should move to the end position
    public bool returnToStartPosition = false; // Flag to determine if the camera should return to the starting position
    private basketButton basketButton;
    private MoveCanvasPanal moveCanvas;
    private void Start()
    {
        basketButton = GameObject.Find("Busket start").GetComponent<basketButton>();
        moveCanvas = GetComponent<MoveCanvasPanal>();
    }



    void FixedUpdate()
    {
        if (moveToEndPosition)
        {
            // Smoothly move and rotate the camera from the starting position to the ending position
            transform.position = Vector3.SmoothDamp(transform.position, endPosition.position, ref velocity, smoothTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, endPosition.rotation, Time.fixedDeltaTime * speed);


            // If the camera has reached the end position, disable movement
            if (Vector3.Distance(transform.position, endPosition.position) < 0.01f && Quaternion.Angle(transform.rotation, endPosition.rotation) < 0.01f)
            {
                moveCanvas.OnOffRenderMode();
                moveToEndPosition = false;

                if(moveToEndPosition == false)
                    basketButton.addBusketToScrollBar();
            }

        }

     



        if (returnToStartPosition)
        {
            // Smoothly move and rotate the camera from the ending position to the starting position
            transform.position = Vector3.SmoothDamp(transform.position, startPosition.position, ref velocity, smoothTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, startPosition.rotation, Time.fixedDeltaTime * speed);


            // If the camera has reached the starting position, disable movement
            if (Vector3.Distance(transform.position, startPosition.position) < 0.01f && Quaternion.Angle(transform.rotation, startPosition.rotation) < 0.01f)
            {
                moveCanvas.OnOffRenderMode();
                returnToStartPosition = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == midPosition)
        {
            moveCanvas.changePositionCanva();
            Debug.Log("Вошел в тригерЗону. Середина");
        }
        
    }



    // Function called when the "Move Camera" button is pressed
    public void MoveCamera()
    {
        moveCanvas.OnOffRenderMode();
        moveToEndPosition = true;
        returnToStartPosition = false;
    }

    // Function called when the "Return Camera" button is pressed
    public void ReturnCamera()
    {
        moveCanvas.OnOffRenderMode();
        returnToStartPosition = true;
        moveToEndPosition = false;
    }
}





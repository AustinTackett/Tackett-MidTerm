using UnityEngine;

public class ClawBehaviour : MonoBehaviour
{

    private Vector2 newPosition;
    private Vector3 mousePos;
    private Camera mainCamera;
    public float clawSpeed = 10;
    public float minX = -1.38f;
    public float maxX = 1.1f; 

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Instantiate
        }
    }

    void FixedUpdate()
    {

        
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosX = new Vector2(mousePos.x, transform.position.y);
        if (mousePosX.x < minX)
        {
            mousePosX.x = minX;
        }
        if (mousePosX.x > maxX)
        {
            mousePosX.x = maxX;
        }

        newPosition = Vector2.MoveTowards(transform.position, mousePosX, clawSpeed * Time.fixedDeltaTime);
        transform.position = newPosition;
    }
}

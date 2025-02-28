using UnityEngine;

public class ClawBehaviour : MonoBehaviour
{
    public GameObject[] Candies;
    private Vector2 newPosition;
    private Vector3 mousePos;
    private Camera mainCamera;
    public float clawSpeed = 10;
    public float minX = -1.38f;
    public float maxX = 1.1f; 
    private float spawnCandyStart;
    public float candyCooldown = 1;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && (Time.time - spawnCandyStart) >= candyCooldown)
        {
            spawnCandy();
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

    public void spawnCandy()
    {
        spawnCandyStart = Time.time;
        int randomCandyIndex = Random.Range(0, Candies.Length);
        GameObject CandyToSpawn = Candies[randomCandyIndex];
        Instantiate(CandyToSpawn, transform.position, Quaternion.identity);
    }
}

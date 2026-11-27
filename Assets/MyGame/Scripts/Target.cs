using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager gameManager;
    public int points = 10;
    private bool hit = false;

    public float speedX = 50f;

    public float speedY = 30f;


    // Start ist eine Methode, die aufgerufen wird bevor das erste Frame Update ausgeführt wird
    private void Start()
    {
        //create a reference to the GameManager script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        transform.localPosition += new Vector3(speedX, speedY, 0) * Time.deltaTime;

        if (transform.localPosition.x > 365 || transform.localPosition.x < -365)
        {
            speedX = -speedX;
        }

        if (transform.localPosition.y > 202 || transform.localPosition.y < -202)
        {
            speedY = -speedY;
        }
    }

     //OnmouseDown() ist eine Methode, die aufgerufen wird wenn der Benutzer auf das GameObject klickt auf dem dieses Skript angehängt ist
    private void OnMouseDown()
    {
        if (hit) return;
        hit = true;
        //call the IncrementScore() method from the GameManager Script
        gameManager.IncrementScore(points);
        Destroy(gameObject);
    }
}

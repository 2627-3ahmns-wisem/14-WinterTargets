using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager gameManager;
    public int points = 10;
    private bool hit = false;


    // Start ist eine Methode, die aufgerufen wird bevor das erste Frame Update ausgeführt wird
    private void Start()
    {
        //create a reference to the GameManager script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 2f);
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

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject parentOfTargets;
    public GameObject winSprite;
    public Text scoreText;
    private int score = 0;
    private bool win = false;


    // die Start Methode wird einmalig vor dem ersten Frame aufgerufen, in dem das Skript aktiv ist
    private void Start( )
    {
        // InvokeRepeating ist eine Methode, die eine andere Methode (hier "Spawn") nach einer bestimmten Zeit (hier 1 Sekunde) wiederholt aufruft.
        InvokeRepeating("Spawn",1f,1f);
    }

    // die Update Methode wird einmal pro Frame aufgerufen, solange das Skript aktiv ist
    private void Update()
    {
        //if the player hits 10 times, the player has won and the Spawn method will not called further. 
        if(win)
        {
            // CancelInvoke ist eine Methode, die das wiederholte Aufrufen einer Methode (hier "Spawn") wieder stoppt
            CancelInvoke("Spawn");
        }

        //every shoot (clicking left mouse button) produce a shooting sound.
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    //Spawn a target at a random position within a specified x and y range.
    //Instantiate (make a concrete GameObject, i.e., a clone from the given prefeb target) the target as a child
    //of the GameObject ParentTargets. In this case transform.localPosition instead of transform.position is important!!

    // Spawn ist eine Methode, die ein Zielobjekt (target) an einer zufälligen Position innerhalb eines bestimmten Bereichs erzeugt
        private void Spawn()
    {
        float randomX = Random.Range(-365f, 365f);
        float randomY = Random.Range(-202f, 202f);
        Vector2 random2DPosition = new Vector2(randomX, randomY);

        int index = Random.Range(0, targets.Length);   // NEU: zufälligen Typ wählen
        GameObject newTarget = Instantiate(targets[index], parentOfTargets.transform);
        newTarget.transform.localPosition = random2DPosition;
    }

    //is called in the class Target
        public void IncrementScore(int points)
    {
        if (win) return;

        score += points;
        print(score);

        scoreText.text = score.ToString();

        if (score >= 100)
        {
        win = true;
        winSprite.SetActive(true);
        }
    }
}

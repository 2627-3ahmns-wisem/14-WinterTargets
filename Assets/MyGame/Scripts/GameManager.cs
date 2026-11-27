using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject parentOfTargets;
    public GameObject winSprite;
    public Text scoreText;
    private int score = 0;
    private bool win = false;
    public Text timeText;
    private float timeleft = 60f;

    public TMP_Text endScoreText;
    public TMP_Text highScoreText;
    private int highScore = 0;


    // die Start Methode wird einmalig vor dem ersten Frame aufgerufen, in dem das Skript aktiv ist
    private void Start( )
    {
        // InvokeRepeating ist eine Methode, die eine andere Methode (hier "Spawn") nach einer bestimmten Zeit (hier 1 Sekunde) wiederholt aufruft.
        InvokeRepeating("Spawn",1f,1f);
    }

    // die Update Methode wird einmal pro Frame aufgerufen, solange das Skript aktiv ist
    private void Update()
    {

        if (score > highScore)
        {
            highScore = score;
        }
        endScoreText.text = "Dein Score: " + score;
        highScoreText.text = "Highscore: " + highScore;
        
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

        if (!win)
        {
            timeleft -= Time.deltaTime;
            timeText.text = Mathf.CeilToInt(timeleft).ToString();

            if (timeleft <= 0)
            {
                win = true;
                winSprite.SetActive(true);
            }
        }

        if (win && Input.GetKeyDown(KeyCode.R))
        {
            NextRound();
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

        float zufall = Random.Range(0f, 100f);

        int index;

        if (zufall < 60f)
        {
            index = 0;
        }
        else if (zufall < 90f)
        {
            index = 1;
        }
        else
        {
            index = 2;
        }
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
    }

    public void NextRound()
    {
        score = 0;
        scoreText.text = "0";
        win = false;
        timeleft = 60f;
        winSprite.SetActive(false);
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", 1f, 1f);
    }
}

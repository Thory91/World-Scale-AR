using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    List<float> placenote = new List<float>() { 1, 2, 3, 4, 5, 1, 2, 1, 2, 3, 4, 5, 6, 1, 1, 1, 2, 1, 3, 4, 5, 1, 2, 3, 4, 6, 1, 2, 3, 4, 2, 3, 2, 1, 4, 5, 1, 6, 2, 1, 6, 1, 6, 1, 3, 1, 4, 5, 6, 2, 2, 3, 3, 4, 1, 3, 2, 1, 1, 2, 2, 3, 3, 5 ,2,1,3,4,5,6};

    List<float> placenote2 = new List<float>() { 1, 2, 3, 4, 5, 1, 2, 1, 2, 3, 4, 5, 6, 1, 1, 1, 2, 1, 3, 4, 5, 1, 2, 3, 4, 6, 1, 2, 3, 4, 2, 3, 2, 1, 4, 5, 1, 6, 2, 1, 6, 1, 6, 1, 3, 1, 4, 5, 6, 2, 2, 3, 3, 4, 1, 3, 2, 1, 1, 2, 2, 3, 3, 5 ,4 ,2 ,2 ,1 ,4 ,3 };

    List<float> placenote3 = new List<float>() { 1, 2, 3, 4, 5, 1, 2, 1, 2, 3, 4, 5, 6, 1, 1, 1, 2, 1, 3, 4, 5, 1, 2, 3, 4, 6, 1, 2, 3, 4, 2, 3, 2, 1, 4, 5, 1, 6, 2, 1, 6, 1, 6, 1, 3, 1, 4, 5, 6, 2, 2, 3, 3, 4, 1, 3, 2, 1, 1, 2, 2, 3, 3, 5 ,6,6,2,3,1,4};

    public AudioSource music;

    public Scene m_scene;

    public bool startplaying;

    public int Marker = 0;

    public int tilenum = 1;

    public Transform tileNoteObj;

    public static GameManager instance;

    public string reset = "y";

    public float xPos;

    public int currentscore;
    public int scorepernote;
    public int currentMultiplier;
    public int multipliertracker;
    public int[] multiplierthreshold;

    public Text scoretext;
    public Text multitext;

    public Text score;

    string Objname = "Tilenote";

    // Start is called before the first frame update
    void Start()
    {
        ToggleScore.instance.scoreText.text = "Score";
        instance = this;
        scoretext.text = "Score: 0";
        currentMultiplier = 1;
        tilenum = placenote2.Count;
    }

    // Update is called once per frame
    void Update()
    {
        m_scene = SceneManager.GetActiveScene();
        if(m_scene.name == "Song1")
        {
            if (tilenum == 0)
            {
                music.Stop();
                Time.timeScale = 0;
                ToggleScore.instance.togglemenu();
                ToggleScore.instance.scoreText.text = scoretext.text;
            }

            if (tilenum < 14)
            {
                StartCoroutine(FadeOut(music, 3000.0f));
            }

            if (reset == "y")
            {
                StartCoroutine(spawner());
                reset = "n";
            }
        }
        else if(m_scene.name == "Song2")
        {
            if (tilenum == 0)
            {
                music.Stop();
                Time.timeScale = 0;
                ToggleScore.instance.togglemenu();
                ToggleScore.instance.scoreText.text = scoretext.text;
            }

            if(tilenum < 14)
            {
                StartCoroutine(FadeOut(music,3000.0f));
            }

            if (reset == "y")
            {
                StartCoroutine(spawner2());
                reset = "n";
            }
        }
    }

    IEnumerator spawner()
    {
        yield return new WaitForSeconds(1);
        if(placenote [Marker] == 1)
        {
            xPos = -1.135f;

        }
        if(placenote [Marker] == 2)
        {
            xPos = -0.57f;

        }
        if(placenote[Marker] == 3)
        {
            xPos = 0.005f;

        }
        if(placenote[Marker] == 4)
        {
            xPos = 0.604f;

        }
        if(placenote[Marker] == 5)
        {
            xPos = 1.234f;

        }
        tilenum = tilenum - 1;
        Debug.Log(tilenum);
        Marker += 1;
        
        reset = "y";
        tileNoteObj.name = Objname + " " + Marker;
        Instantiate(tileNoteObj, new Vector3(xPos, 1.91f, -3.821f), tileNoteObj.rotation);
    }

    IEnumerator spawner2()
    {
        yield return new WaitForSeconds(1);
        if (placenote2[Marker] == 1)
        {
            xPos = -1.135f;

        }
        if (placenote2[Marker] == 2)
        {
            xPos = -0.57f;

        }
        if (placenote2[Marker] == 3)
        {
            xPos = 0.005f;

        }
        if (placenote2[Marker] == 4)
        {
            xPos = 0.604f;

        }
        if (placenote2[Marker] == 5)
        {
            xPos = 1.234f;

        }
        tilenum = tilenum - 1;
        Debug.Log(tilenum);
        Marker += 1;

        reset = "y";
        tileNoteObj.name = Objname + " " + Marker;
        Instantiate(tileNoteObj, new Vector3(xPos, 1.91f, -3.821f), tileNoteObj.rotation);
    }

    public void NoteHit() // checking for if player actually hits the noted
    {
        Debug.Log("hit on time!");

        if (currentMultiplier - 1 < multiplierthreshold.Length)
        {
            multipliertracker++; //combo multiplier

            if (multiplierthreshold[currentMultiplier - 1] <= multipliertracker)//if player exceeds certain combo thresholds, it will increase the multiplier making the player earning more score
            {
                multipliertracker = 0;
                currentMultiplier++;
               if(currentMultiplier == 2)
                {
                    scorepernote = 100;
                }
               else if(currentMultiplier == 3)
                {
                    scorepernote = 150;
                }
               else if(currentMultiplier == 4)
                {
                    scorepernote = 200;
                }
            }
        }
        multitext.text = "Multiplier x " + currentMultiplier;
        currentscore = (currentscore + scorepernote);/* * currentMultiplier;*/
        scoretext.text = "Score: " + currentscore;
        Debug.Log(currentscore);
    }

    public void NoteMiss() //checking statement for if player miss a note. if MISS, then current multiplier or combo will be reset to 1;
    {
        Debug.Log("Missed the note!");
        currentMultiplier = 1;
        multipliertracker = 0;
        scorepernote = 50;
        multitext.text = "Multiplier x " + currentMultiplier;
    }

    IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }

    public void tapscore()
    {

    }
}


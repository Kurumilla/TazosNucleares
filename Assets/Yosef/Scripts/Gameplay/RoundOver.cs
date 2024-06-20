using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RoundOver : MonoBehaviour
{
    [Header("Settings")]
    public bool active = true;
    public float countdown;
    private float maxCount;

    [Header("Scores")]
    public bool isPlayersTurn;  // 0 = Player
    public int[] score;         // 1 = Enemy

    [Header("Lista de tazos")]
    private GameObject current;
    public List<GameObject> tazos;

    [Header("Object References")]
    public Transform camera;
    public UI_Shrink scoreboard;
    public TMP_Text txtHeadsCounter;
    public TMP_Text txtTailsCounter;

    void Awake()
    {
        maxCount = countdown;
    }

    void Update()
    {
        if (active && countdown<=0)
        {
            active = false;
            // Count
            GameObject[] board = GameObject.FindGameObjectsWithTag("Tazo");
            foreach (GameObject item in board)
            {
                if (Vector3.Angle(item.transform.forward, Vector3.up) < 90f)
                {
                    score[isPlayersTurn ? 0 : 1]++; //Use boolean as int
                    Destroy(item);
                }
            }
            // Update score
            txtHeadsCounter.text = "PLAYER: " + score[0].ToString();
            txtTailsCounter.text = "ENEMY: " + score[1].ToString();
            scoreboard.ShowScores();

            // Change turn
            isPlayersTurn = !isPlayersTurn;
            if (isPlayersTurn && tazos.Count > 0)
                PlayerPhase();
            else if (tazos.Count > 0)
                EnemyPhase();
            else
                GameOver();
        }
        else if (active)
        {
            countdown -= Time.deltaTime;
        }
    }

    // Time to watch the tazos bounce around
    public void SystemPhase()
    {
        countdown = maxCount;
        active = true;
    }

    public void PlayerPhase()
    {
        // Spawn tazo at player's hand
        current = (GameObject)Instantiate(tazos[0], camera);
        current.transform.localPosition = new Vector3(0, -0.2f, 0.5f);
    }

    public void EnemyPhase()
    {
        // Locate target
        GameObject[] board = GameObject.FindGameObjectsWithTag("Tazo");
        Vector3 pos = new Vector3(0, 1f, 0);
        Vector3 rot = new Vector3(1f, 0, 0);

        // Exclude self
        if (board[0] != gameObject)
            pos += board[0].transform.position;
        else
            pos += board[1].transform.position;

        // Spawn tazo above the target
        GameObject token = (GameObject)Instantiate(tazos[0], pos, Quaternion.Euler(rot));
        token.GetComponent<Tazo>().OnClick();
        tazos.RemoveAt(0); //Enemy removes because they go 2nd
    }

    private void GameOver()
    {
        if (score[0] > score[1])
            SceneManager.LoadScene("GameOverWin");
        else //if (score[0] < score[1])
            SceneManager.LoadScene("GameOverLose");
    }

    public void CambiarTiro()
    {
        current.GetComponent<Tazo>().tiroCurvo = !current.GetComponent<Tazo>().tiroCurvo;
    }
}

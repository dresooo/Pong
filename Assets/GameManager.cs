using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score1;
    public int score2;
    public Text Textscore1;
    public Text Textscore2;
    public Trajectory trajectory;
    public Rigidbody2D Ball;
    public Player_movement Player1;
    public Player_movement Player2;
    private bool isDebugWindowShown = false;
    public int maxscore;
    private void Start()
    {
        trajectory.enabled = false;
    }
    public void AddscoreLeft()
    {
        score1 += 1;
    }
    public void AddscoreRight()
    {
        score2 += 1;
    }
    void Update()
    {
        Textscore1.text = score1.ToString();
        Textscore2.text = score2.ToString();
        if (score1 >= 10)
        {

            //resetgame
        }
        else if (score2 >= 10)
        {
            //resetgame
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }
    void OnGUI()
    {
        if (isDebugWindowShown)
        {
            GUIStyle guistyle = new GUIStyle();
            guistyle.fontSize = 5;
            float impulsePlayer1X = Player1.LastContactPoint.normalImpulse;
            float impulsePlayer1Y = Player1.LastContactPoint.tangentImpulse;
            float impulsePlayer2X = Player2.LastContactPoint.normalImpulse;
            float impulsePlayer2Y = Player2.LastContactPoint.tangentImpulse;

            string debugText =
                  "Ball mass = " + Ball.mass + "\n" +
                  "Ball velocity = " + Ball.velocity + "\n" +
                  "Ball speed = " + Ball.velocity.magnitude + "\n" +
                  "Ball momentum = " + Ball.mass * Ball.velocity + "\n" +
                  "Last impulse from player 1 = (" + impulsePlayer1X + ", " + impulsePlayer1Y + ")\n" +
                  "Last impulse from player 2 = (" + impulsePlayer2X + ", " + impulsePlayer2Y + ")\n";

            // Tampilkan debug window
            GUIStyle guiStyle = new GUIStyle(GUI.skin.textArea);
            guiStyle.alignment = TextAnchor.UpperCenter;
            GUI.TextArea(new Rect(Screen.width / 2 - 200, Screen.height - 200, 400, 110), debugText, guiStyle);


        }
       
        if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height - 73, 120, 53), "TOGGLE\nDEBUG INFO"))
        {
            isDebugWindowShown = !isDebugWindowShown;
            trajectory.enabled = !trajectory.enabled;
            GameObject BOC = GameObject.Find("BallAtCollision");
            if (!BOC.activeInHierarchy) BOC.SetActive(true);
            else BOC.SetActive(false);
        }
        
        if (score1 == maxscore)
        {
            GUI.Label(new Rect(Screen.width / 6, Screen.height / 2 - 10, 2000, 1000), "PLAYER ONE WINS");
            Ball.gameObject.SetActive(false);

        }

        else if (score2 == maxscore)
        {
            GUI.Label(new Rect(Screen.width / 2 + 170, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS");
            Ball.gameObject.SetActive(false);
        }

    }
    public void debugON()
    {
        isDebugWindowShown = !isDebugWindowShown;
        trajectory.enabled = !trajectory.enabled;

    }
    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }

}

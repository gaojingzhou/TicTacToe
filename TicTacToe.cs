using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    private int turns; //who's playing
    private int count; //counter
    private int res = 0; //who wins
    private int[,] board = new int[3, 3]; //chess board
    public Texture2D img1;
    public Texture2D img2;
    public Texture2D background;
    void restart()
    {
        turns = 1;
        count = 0;
        for (int i = 0; i < 3; i ++)
        {
            for (int j = 0; j < 3; j ++)
            {
                board[i, j] = 0; //restartialize
            }
        }
    }

    int checkWins()
    {
        for (int i = 0; i < 3; i ++) //win case 1
        {
            if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return board[i, 0];
        }
        for (int i = 0; i < 3; i++) //win case 2
        {
            if (board[0, i] != 0 && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                return board[0, i];
        }

        if (board[1, 1] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] ||
            board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]
            )
            return board[1, 1];
        if (count == 9) return 3; //tie
        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        restart();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 880, 580), background); //background

        GUIStyle fontstyle = new GUIStyle();
        fontstyle.normal.background = null;
        fontstyle.normal.textColor = new Color(255, 192, 203);
        fontstyle.fontSize = 50;

        GUI.Label(new Rect(250, 15, 100, 100), "TicTacToe", fontstyle); //title


        if (GUI.Button(new Rect(320, 350, 100, 50), "RESTART")) { //restart button
            restart();
        }

        GUIStyle fontstyle2 = new GUIStyle();
        fontstyle.normal.background = null;
        fontstyle.normal.textColor = new Color(255, 192, 203);
        fontstyle.fontSize = 30;

        res = checkWins();
        if (res == 1) GUI.Label(new Rect(500, 180, 100, 50), "PLAYER1 WINS", fontstyle2);
        if (res == 2) GUI.Label(new Rect(500, 180, 100, 50), "PLAYER2 WINS", fontstyle2);
        if (res == 3) GUI.Label(new Rect(500, 180, 100, 50), "TIE GAME", fontstyle2);

        for (int i = 0; i < 3; i ++)
        {
            for (int j = 0; j < 3; j ++)
            {
                if (board[i, j] == 1) GUI.Button(new Rect(300 + i * 50, 130 + j * 50, 50, 50), img1);
                if (board[i, j] == 2) GUI.Button(new Rect(300 + i * 50, 130 + j * 50, 50, 50), img2);
                if (GUI.Button(new Rect(300 + i * 50, 130 + j * 50, 50, 50), ""))
                {
                    if (res == 0) //still playing
                    {
                        if (turns == 1) board[i, j] = 1;
                        if (turns == -1) board[i, j] = 2;
                        count++;
                        turns = -turns;
                    }
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

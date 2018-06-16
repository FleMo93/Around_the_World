using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Game : MonoBehaviour
{
    private static scr_Game thisScript;
    public static scr_Game Get
    {
        get
        {
            if(thisScript == null)
            {
                thisScript = FindObjectOfType<scr_Game>();
            }

            return thisScript;
        }
    }

    public delegate void GameStartEventHandler();
    public event GameStartEventHandler OnGameStart;

    public delegate void GameEndEventHandler();
    public event GameEndEventHandler OnGameEnd;

    public bool GameRunning { get; private set; }
    public bool End { get; private set; }

    private scr_Car car;


    void Start ()
    {
        GameRunning = false;
        car = FindObjectOfType<scr_Car>();
	}
	
	void Update ()
    {
		if(GameRunning && !car.Alive && !End)
        {
            End = true;

            if(OnGameEnd != null)
            {
                OnGameEnd();
            }
        }
	}

    public void StartGame()
    {
        if(GameRunning)
        {
            return;
        }

        GameRunning = true;

        if(OnGameStart != null)
        {
            OnGameStart();
        }
    }
}

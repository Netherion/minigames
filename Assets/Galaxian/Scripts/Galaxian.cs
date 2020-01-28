﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Galaxian : IMiniGame
{
    public NaveGalaxian nave;
    public int enemyCount;
    GameObject[] enemyList;
    GameManager gameManagerInstance;
    void Awake()
    {
        //Init Juego
        enemyList = GameObject.FindGameObjectsWithTag("GalaxianEnemy");
        enemyCount = enemyList.Length;
    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");

        foreach (GameObject enemy in enemyList)
        {
            enemy.GetComponent<EnemyGalaxian>().alive = true;
        }

        nave.alive = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        nave.init(gm);
        gameManagerInstance = gm;
    }

    private void Update()
    {
        if(nave == null){ return; }
        if (!nave.alive)
        {
            gameManagerInstance.EndGame(MiniGameResult.LOSE);
        }

        if (enemyCount == 0)
        {
            gameManagerInstance.EndGame(MiniGameResult.WIN);
        }
     
        enemyCount = GameObject.FindGameObjectsWithTag("GalaxianEnemy").Length;
    }

    public override string ToString()
    {
        return "Galaxian";
    }

}

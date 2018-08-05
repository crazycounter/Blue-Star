﻿using UnityEngine;
using System.Collections;

public class CityGUI : MonoBehaviour {


    public DataBaseManager dataBaseManager;
    public SaveAndLoad saveAndLoad;
    public CubeManager cubeManager;
    private Vector2 worldStartPoint;
    public BasePlayer Player=new BasePlayer();

    void Start () {

        
        Player = saveAndLoad.LoadPlayerChoicesFromDataBase();

        cubeManager.GenerateRandomUnderground();


    }



}

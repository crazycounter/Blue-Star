﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveGameMenuButtons : MonoBehaviour {

	public MenuGUI menuGUI;
	private Canvas SaveGameMenu;

    public DataBaseManager dataBaseManager;
    private ArrayList Names = new ArrayList();


    void Start(){
        
        SaveGameMenu = GetComponent<Canvas>();
		SaveGameMenu.enabled = false;

        Names = dataBaseManager.getArrayData("select Slot, FirstName, LastName from PlayerStaticChoices order by Slot asc");
        for (int i = 1; i< 4; i++) { SaveGameMenu.GetComponentsInChildren<Text>()[i].text = (string)((ArrayList)Names[i])[1]; }

    }
	
	public void Next(int position){

        // Save in place (a ajouter)

        menuGUI.Slot = position;
        menuGUI.MenuGoNext(0);
        SaveGameMenu.enabled = false;
    }


    public void Back(){
        menuGUI.MenuGoBack (0);
        SaveGameMenu.enabled = false;
    }


    public void ActivateMenu() {
        SaveGameMenu.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.SAVE;


        //Auto-select first slot for saving if no save information
        if ((string)((ArrayList)Names[1])[2] == null)
        {
            Next(1);

        }


    }




}

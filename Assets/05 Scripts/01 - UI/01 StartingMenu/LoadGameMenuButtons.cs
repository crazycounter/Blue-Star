﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadGameMenuButtons : MonoBehaviour {

	public MenuGUI menuGUI;
	private Canvas LoadGameMenu;

    public DataBaseManager dataBaseManager;
    private ArrayList Names = new ArrayList();
    private ArrayList RefErrors = new ArrayList();



    void Start(){
		LoadGameMenu = GetComponent<Canvas>();
		LoadGameMenu.enabled = false;

        Names = dataBaseManager.getArrayData("select Slot, FirstName, LastName from PlayerStaticChoices order by Slot asc");
        RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' order by Id asc");
        for (int i = 1; i < 4; i++) { LoadGameMenu.GetComponentsInChildren<Text>()[i].text = (string)((ArrayList)Names[i])[1]; }

    }



	public void Next(int position){


        //Load à ajouter
        if (!((string)((ArrayList)Names[position])[2]==null)) {
            menuGUI.Slot = position;
            menuGUI.MenuGoNext(0);
            LoadGameMenu.enabled = false;
        }
        else
        {
            menuGUI.dialogue.UpdateDialogue(true, (string)((ArrayList)RefErrors[5])[2], (string)((ArrayList)RefErrors[5])[3], (string)((ArrayList)RefErrors[5])[4]);
        }
    }

    public void Back(){
        menuGUI.MenuGoBack (0);
        LoadGameMenu.enabled = false;
    }

    public void ActivateMenu() {
        LoadGameMenu.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.LOAD;

        //Auto-select first slot for saving if no save information
        if ((string)((ArrayList)Names[2])[2] == null && (string)((ArrayList)Names[3])[2] == null)
        {
            Next(1);

        }

    }





}

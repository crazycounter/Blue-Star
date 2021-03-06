﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundSelectionButtons : MonoBehaviour {

    public DataBaseManager dataBaseManager;
    private Canvas BackgroundSelection;
    public MenuGUI menuGUI;

    private ArrayList RefErrors = new ArrayList();


    private GridLayoutGroup[] ChoiceDisplay = new GridLayoutGroup[2]; 

    public string PlayerBio;
    public string PlayerGender;

    private string[] genderSelectionNames = new string[] { "Male", "Female", "Bigender", "Pangender", "Agender", "Other" };

    public int genderSelection=0;

	void Start () {

        RefErrors = dataBaseManager.getArrayData("select * from REF_Dialogues where Context='Errors' order by Id asc", "BlueStarDataWarehouse.db");

        BackgroundSelection = GetComponent<Canvas>();

		for (int i=0;i<2;i++) {
			ChoiceDisplay[i]=BackgroundSelection.GetComponentsInChildren<GridLayoutGroup>()[i];
		}
		BackgroundSelection.enabled = false;
	}

	void UpdateDetails () {
		PlayerBio=ChoiceDisplay [0].GetComponentsInChildren<Text> () [2].text;
		
		for (int i=0; i<6; i++) {
			if (ChoiceDisplay [1].GetComponentsInChildren<Toggle> () [i].isOn==true) {
                genderSelection =i+1;
                PlayerGender = genderSelectionNames[genderSelection - 1];
            }
		}
        
	}


    public bool TestDetails()
    {
        if (!(PlayerGender == "") && PlayerBio.IndexOf("'")==-1) { return true; } else { return false; }
    }

    public void Next (){

        if (System.Convert.ToInt32(((ArrayList)menuGUI.PlayerAccountStatsBefore[menuGUI.Slot])[2]) == 0)
        {
            menuGUI.MenuGoNext(0);
            BackgroundSelection.enabled = false;
        }
        else {
   
            UpdateDetails();

            if (TestDetails() == true)
                {
                menuGUI.MenuGoNext(0);
                BackgroundSelection.enabled = false;
            }
            else
                { menuGUI.dialogue.UpdateDialogue(false, (string)((ArrayList)RefErrors[3])[2], (string)((ArrayList)RefErrors[3])[3], (string)((ArrayList)RefErrors[3])[4]); }
        } 
    }

    public void Back()
    {
        menuGUI.MenuGoBack(0);
        BackgroundSelection.enabled = false;

    }

    public void ActivateMenu()
    {
        BackgroundSelection.enabled = true;
        menuGUI.currentState = MenuGUI.CreateAPlayerStates.FINALSETUP;

        if (System.Convert.ToInt32(((ArrayList)menuGUI.PlayerAccountStatsBefore[menuGUI.Slot])[2]) == 0) {

            menuGUI.PlayerFirstName = "Ephan";
            PlayerBio = "Ephan is the last vampyri lord of his forgotten house, and seeks to restore the glory of his name through military feats. He embarks in a perilous invasion of foreign and unknown lands to build his new legacy.";
            PlayerGender = "Bigender";

            Next();
        }



    }


}

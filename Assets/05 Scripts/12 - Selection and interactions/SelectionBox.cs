﻿using UnityEngine;
using System.Collections;

public class SelectionBox : MonoBehaviour {

    private Transform Selectionbox;
    public JoystickMenu leftJoystick;
    public WindowsCamera windowsCamera;
    public InteractionMenu interactionMenu;

    private Vector3 IdlePosition = new Vector3(0, -10, 0);


    // Use this for initialization
    void Start () {
        Selectionbox = GetComponent<Transform>();
        Selectionbox.transform.position = IdlePosition;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Select(GameObject SelectedObject)
    {
        switch (SelectedObject.GetComponentsInChildren<GameObjectInformation>()[0].objectCategory)
        {
            case GameObjectInformation.ObjectCategory.Ground:
                Selectionbox.transform.position = new Vector3(SelectedObject.transform.position.x-0.25f, SelectedObject.transform.position.y + 0.01f, SelectedObject.transform.position.z-0.25f);
                break;

            case GameObjectInformation.ObjectCategory.Player:
                Selectionbox.transform.position = IdlePosition;
                windowsCamera.characterSelected = SelectedObject;
                leftJoystick.ActivateJoystick();
                break;

            default:
                Selectionbox.transform.position = new Vector3(SelectedObject.transform.position.x, SelectedObject.transform.position.y + 0.01f, SelectedObject.transform.position.z);
                break;
        }

        ActionButtonUpdate(SelectedObject, windowsCamera.characterSelected);

    }

    public void Deselect()
    {
        Selectionbox.transform.position = IdlePosition;
    }


    public void ActionButtonUpdate(GameObject SelectedObject, GameObject Character) {

        // Reset everything
        interactionMenu.ResetActionButtons();

        // If character exist and is nearby
        if ( Character != null 
            &&
            Mathf.Abs(SelectedObject.transform.position.x- Character.transform.position.x)<=1.5f
            &&
            Mathf.Abs(SelectedObject.transform.position.z - Character.transform.position.z) <= 1.5f)
        {

            if (SelectedObject.GetComponentsInChildren<GameObjectInformation>()[0].CanBeDigged <= Character.GetComponentsInChildren<GameObjectInformation>()[0].basePlayer.DiggingLevel)
            { interactionMenu.InstantiateDigThrough(); }

            if (SelectedObject.GetComponentsInChildren<GameObjectInformation>()[0].CanBeBuilt <= Character.GetComponentsInChildren<GameObjectInformation>()[0].basePlayer.BuildingLevel)
            { interactionMenu.InstantiatePaving(); }

        }


    }


}

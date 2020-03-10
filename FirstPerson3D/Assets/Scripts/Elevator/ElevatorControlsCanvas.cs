﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorControlsCanvas : MonoBehaviour, IPuzzleCanvas
{
    [SerializeField] Button upButton;
    [SerializeField] Button downButton;
    [SerializeField] Button talkButton;
    [SerializeField] Button controlsButton;
    [SerializeField] ElevatorPuzzleCanvas circuit;
    [SerializeField] DialogueBase dialogue;
    [SerializeField] DialogueCanvas diaCanvas;
    

    private void Awake()
    {
        upButton.interactable = false;
        downButton.interactable = false;
        talkButton.interactable = true;
        controlsButton.interactable = true;
    }

    public void Activate()
    {
        GameManager.gameManager.SwitchCameras("2D");
        gameObject.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Reactivate()
    {
        gameObject.SetActive(true);
        if (circuit.circuitSet)
        {
            controlsButton.interactable = false;
            ActivateUp();

        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameManager.gameManager.SwitchCameras("3D");
    }

    private void ActivateUp()
    {
        //enable the entrance door
        //...
        //disable exit door
        //...
        upButton.interactable = true;
        downButton.interactable = false;

    }

    private void ActivateDown()
    {
        //disable the entrance door
        //...
        //enable exit door
        //...
        upButton.interactable = false;
        downButton.interactable = true;
    }

    public void TalkButton()
    {
        diaCanvas.Activate();
        //start Conversation with Roboter
        DialogueManager.instance.EnqueueDialogue(
            DialogueTracker.dialogueTracker.ChooseDialogue());
    }

    public void UpButton()
    {
        //play animation + Sound
        //...
        ActivateDown();
    }

    public void DownButton()
    {
        //play animation + Sound
        //...
        ActivateUp();
    }

    public void ControlsButton()
    {
        //close this canvas so there is no confusion when clicking
        gameObject.SetActive(false);
        //open circuit Canvas
        circuit.Activate();
        
    }


}

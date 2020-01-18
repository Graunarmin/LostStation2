﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//create Logic for events here!
//use References to acces GameObjects

[CreateAssetMenu(fileName = "New DialogueEvent", menuName = "DialogueEvent")]
public class DialogueEvents : ScriptableObject
{
    
    public void AddJournalPage(JournalPage jp)
    {
        Reference.instance.journalManager.UpdateJournal(jp);
    }

    #region Dialogue  01
    public void SetAmAlice()
    {
        Debug.Log("You chose 'Alice'");
        DialogueTracker.dialogueTracker.start = false;

        DialogueTracker.dialogueTracker.amAlice = true;
        DialogueTracker.dialogueTracker.willHelp = false;
        DialogueTracker.dialogueTracker.wontHelp = false;

        ResetNobody();
    }

    public void ResetAlice()
    {
        DialogueTracker.dialogueTracker.amAlice = false;
        DialogueTracker.dialogueTracker.willHelp = false;
        DialogueTracker.dialogueTracker.wontHelp = false;
    }

    public void SetWillHelp()
    {
        Debug.Log("You chose to help");
        DialogueTracker.dialogueTracker.willHelp = true;
    }

    public void SetWontHelp()
    {
        Debug.Log("You chose not to help");
        DialogueTracker.dialogueTracker.wontHelp = true;

    }

    public void SetAmNobody()
    {
        Debug.Log("You chose 'Nobody'");
        DialogueTracker.dialogueTracker.start = false;

        DialogueTracker.dialogueTracker.amNobody = true;
        DialogueTracker.dialogueTracker.comeBack = false;

        ResetAlice();
    }

    public void ResetNobody()
    {
        DialogueTracker.dialogueTracker.amNobody = false;
        DialogueTracker.dialogueTracker.comeBack = false;
    }

    public void SetComeBack()
    {
        DialogueTracker.dialogueTracker.comeBack = true;
        DialogueTracker.dialogueTracker.amNobody = false;
        ResetAlice();
        
    }
    #endregion

    #region Dialogue 03

    public void SetFlashlight()
    {
        DialogueTracker.dialogueTracker.gotFlashlight = true;
        GameManager.gameManager.flashlightEnabled = true;
        TutorialManager.tutorialManager.StartCoroutine(TutorialManager.tutorialManager.WaitForEndOfDialogue());
        Debug.Log("Moving on");
    }

    #endregion
}

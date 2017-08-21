using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePageNote : MonoBehaviour {

    public int ID;
    public Text Body;

    public void Clicked()
    {
        NotePageManager.ButtonClicked(ID);
    }

    public void AddNoteButton()
    {
        Body.text = "Add New Note";
    }
}

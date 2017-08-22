using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePageNote : MonoBehaviour {

    public int ID;
    public InputField Body;
    public Text BodyDesign;

    public void Clicked()
    {
        NotePageManager.ButtonClicked(ID);
    }

    public void AddNoteButton()
    {
        Body.text = "Add New Note";
    }

    internal void LoadNote(DataNoteBody item)
    {
        //Body.text = "NOTE:" + item.BodyText;
        Body.text = item.BodyText;

        if (item.Done == true)
        {
            BodyDesign.fontStyle = FontStyle.Italic;
            BodyDesign.color = Color.gray;
        }
        else
        {
            BodyDesign.fontStyle = FontStyle.Normal;
            BodyDesign.color = Color.black;
        }
    }

    public void TextUpdate()
    {
        NotePageManager.UpdateNote(ID, Body.text);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePageNote : MonoBehaviour {

    public int ID;
    public InputField Body;
    public Text BodyDesign;
    private DataNoteBody storedBody;

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
        storedBody = item;
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
        if (storedBody == null) return;

        NotePageManager.UpdateNote(ID, Body.text);

        var minHeight = storedBody.NumOfLines > 4 ? storedBody.NumOfLines : 4;
        var actualCount = minHeight % 2 + minHeight / 2;
        GetComponent<RectTransform>().sizeDelta = new Vector2(640, actualCount * 75);
    }
}

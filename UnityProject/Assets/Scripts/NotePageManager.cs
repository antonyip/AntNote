using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePageManager : MonoBehaviour
{
    private static NotePageManager instance;

    public GameObject NotePrefab;
    public Transform ContentHolder;
    long NoteSelected = -1;
    bool EditMode = false;

    public List<long> noteBodyIDsAppearing = new List<long>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static void UpdateNote(int NoteID, string text)
    {
        if (NoteID == 0) return;

        Debug.Log("UpdateNote: " + NoteID + " (" + text + ")");
        var CurrentNote = DataContainer.GetInstance().notes.Find(x => x.ID == instance.NoteSelected);
        var BodyEdit = CurrentNote.Body.Find(x => x.ID == NoteID);
        BodyEdit.BodyText = text;
        DataContainer.GetInstance().SaveNotesToDB();
        DataContainer.GetInstance().LoadNotesFromDB();
    }

    internal static void ButtonClicked(int buttonID)
    {
        if (buttonID == 0 && instance.EditMode == true)
        {
            // add a note was clicked
            instance.AddBody();
        }
        else if (instance.EditMode == true)
        {

        }
        else if (instance.EditMode == false)
        {
            var NoteID = instance.noteBodyIDsAppearing[buttonID];
            var CurrentNote = DataContainer.GetInstance().notes.Find(x => x.ID == instance.NoteSelected);
            var BodyToBeToggled = CurrentNote.Body.Find(x => x.ID == NoteID);
            foreach (var item in CurrentNote.Body)
            {
                Debug.Log(item.ID.ToString());
            }
            Debug.Log("nid" + NoteID);
            
            BodyToBeToggled.Done = BodyToBeToggled.Done ? false : true;

        }

        instance.OnEnable();
    }

    private void AddBody()
    {
        var CurrentNote = DataContainer.GetInstance().notes.Find(x => x.ID == instance.NoteSelected);
        DataNoteBody dnb = new DataNoteBody();
        dnb.ID = CurrentNote.Body.Count + 1;
        CurrentNote.Body.Add(dnb);
        DataContainer.GetInstance().SaveNotesToDB();
        DataContainer.GetInstance().LoadNotesFromDB();
    }

    // Use this for initialization
    void OnEnable()
    {
        noteBodyIDsAppearing.Clear();

        for (int i = 0; i < ContentHolder.childCount; i++)
        {
            ContentHolder.GetChild(i).gameObject.SetActive(false);
        }

        if (NoteSelected != -1)
        {
            var CurrentNote = DataContainer.GetInstance().notes.Find(x => x.ID == NoteSelected);

            var counter = 0;
            if (EditMode)
            {
                var go = Instantiate(NotePrefab) as GameObject;
                go.transform.SetParent(ContentHolder);
                go.transform.localScale = Vector3.one;
                go.GetComponent<NotePageNote>().ID = counter++;
                go.GetComponent<NotePageNote>().AddNoteButton();
                noteBodyIDsAppearing.Add(-1);
                go.GetComponent<NotePageNote>().Body.interactable = false;
                go.GetComponent<NotePageNote>().Body.GetComponent<Image>().raycastTarget = false;
            }

            foreach (var item in CurrentNote.Body)
            {
                var go = Instantiate(NotePrefab) as GameObject;
                go.transform.SetParent(ContentHolder);
                go.transform.localScale = Vector3.one;
                go.GetComponent<NotePageNote>().ID = counter++;
                go.GetComponent<NotePageNote>().LoadNote(item);
                noteBodyIDsAppearing.Add(item.ID);

                if (EditMode)
                {
                    go.GetComponent<NotePageNote>().Body.interactable = true;
                    go.GetComponent<NotePageNote>().Body.GetComponent<Image>().raycastTarget = true;
                }
                else // not edit mode
                {
                    go.GetComponent<NotePageNote>().Body.interactable = false;
                    go.GetComponent<NotePageNote>().Body.GetComponent<Image>().raycastTarget = false;
                }
            }
            var height = counter * 150 + (counter - 1) * 10;
            ContentHolder.GetComponent<RectTransform>().sizeDelta = new Vector2(640, height);
            //ContentHolder.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
    }

    // Update is called once per frame
    void OnDisable()
    {
        NoteSelected = -1;

    }

    internal void LoadScreen(long noteSelected)
    {
        NoteSelected = noteSelected;
        OnEnable();
    }

    public void ToggleEdit()
    {
        if (EditMode)
            EditMode = false;
        else
            EditMode = true;

        OnEnable();
    }
}

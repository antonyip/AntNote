using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour {

    private static DataContainer instance;

    public List<DataNote> notes = new List<DataNote>();

    public static DataContainer GetInstance()
    {
        return instance;
    }

	// Use this for initialization
	void Awake ()
    {
		if (instance == null)
        {
            instance = this;
            LoadNotesFromDB();
        }
        else
        {
            Debug.Log("Double Init");
        }
	}

    private void HACKEDSTART()
    {
        DataNote dn = new DataNote();
        dn.Title = "FirstNote!";
        notes.Add(dn);
    }
	
    public List<DataNote> GetNotes()
    {
        return notes;
    }

    public void AddNote(string title)
    {
        DataNote dn = new DataNote();
        dn.Title = title;
        notes.Add(dn);
        SaveNotesToDB();
    }

    public void SaveNotesToDB()
    {
        JSONObject json = new JSONObject();
 
        foreach (var item in notes)
        {
            json.Add(item.Encode());
        }

        PlayerPrefs.SetString("notes", json.Print());
    }

    public void LoadNotesFromDB()
    {
        JSONObject json = new JSONObject(PlayerPrefs.GetString("notes", "{}"));
        Debug.Log(json.Print(true));

        notes.Clear();
        foreach (var item in json.list)
        {
            DataNote dn = new DataNote();
            dn.Decode(item);
            notes.Add(dn);
        }
    }


}

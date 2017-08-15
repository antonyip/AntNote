using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour {

    private static DataContainer instance;

    private List<DataNote> notes = new List<DataNote>();

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
            HACKEDSTART();
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
    }

    public void SaveNotesToDB()
    {
       
    }


}

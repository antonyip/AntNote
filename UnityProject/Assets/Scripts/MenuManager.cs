using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject NoteMenu;

	// Use this for initialization
	void OnEnable ()
    {
        MainMenu.SetActive(true);

        var Notes = DataContainer.GetInstance().GetNotes();
    }
	
	// Update is called once per frame
	void OnDisable () {
		
	}
}

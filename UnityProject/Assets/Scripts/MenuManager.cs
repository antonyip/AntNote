using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance;
    
    public static MenuManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }

    public GameObject MainMenu;
    public GameObject NoteMenu;

	// Use this for initialization
	void OnEnable ()
    {
        MainMenu.SetActive(true);
        NoteMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void OnDisable () {
		
	}

    public static void GoToNote(int id)
    {
        long NoteSelected = instance.MainMenu.GetComponent<MainPageManager>().noteIDsAppearing[id];
        instance.MainMenu.SetActive(false);
        instance.NoteMenu.SetActive(true);
        instance.NoteMenu.GetComponent<NotePageManager>().LoadScreen(NoteSelected);
    }
}

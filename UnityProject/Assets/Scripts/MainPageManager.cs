using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageManager : MonoBehaviour {

    private static MainPageManager instance;

    public GameObject mainMenuNotePrefab;
    public GameObject ListOfNotesHolder;

    public static MainPageManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

	// Use this for initialization
	void OnEnable ()
    {
        // clean up
        // while (ListOfNotesHolder.transform.childCount > 0)
        // {
        //     Destroy(ListOfNotesHolder.transform.GetChild(0).gameObject);
        // }

        for (int i = 0; i < ListOfNotesHolder.transform.childCount; i++)
        {
            ListOfNotesHolder.transform.GetChild(i).gameObject.SetActive(false);
        }

        //add back
        var notes = DataContainer.GetInstance().GetNotes();
        int counter = 0;
        foreach (var item in notes)
        {
            var go = Instantiate(mainMenuNotePrefab) as GameObject;
            go.transform.SetParent(ListOfNotesHolder.transform);
            go.transform.localScale = Vector3.one;
            go.GetComponent<MainPageButton>().ID = counter++;
        }
	}
	
	// Update is called once per frame
	void OnDisable () {
		
	}

    public void AddNote()
    {
        DataContainer.GetInstance().AddNote("MainPageManager.cs Note");
        OnEnable();
    }

    public static void MainButtonClicked(int id)
    {
        MenuManager.GoToNote(id);
        Debug.Log(id);
    }
}

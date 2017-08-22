using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPageButton : MonoBehaviour {

    public int ID;

    public Text Title;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clicked()
    {
        MainPageManager.MainButtonClicked(ID);

    }

    public void Load(DataNote item)
    {
        Title.text = item.Title;
        GetComponent<Button>().colors = DataContainer.GetInstance().colorBlock[item.Color];
    }
}

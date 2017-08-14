using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageButton : MonoBehaviour {

    public int ID;
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
}

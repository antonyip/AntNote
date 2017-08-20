using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataNoteBody
{
    public string BodyText = "";
    public bool Done = false;
}

public class DataNote
{
    public long ID;
    public string Title;
    public List<DataNoteBody> Body = new List<DataNoteBody>();
    public long Color = 0;

    public JSONObject Encode()
    {
        JSONObject json = new JSONObject(JSONObject.Type.OBJECT);

        json.AddField("ID", ID);
        json.AddField("Title", Title);
        json.AddField("Color", Color);

        return json;
    }

    public void Decode(JSONObject json)
    {
        Debug.Log(json.Print());
        ID = json.GetField("ID").i;
        Title = json.GetField("Title").str;
        Color = json.GetField("Color").i;
    }
}
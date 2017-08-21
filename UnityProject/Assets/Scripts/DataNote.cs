using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataNoteBody
{
    public string BodyText = "";
    public bool Done = false;

    public JSONObject Encode()
    {
        JSONObject json = new JSONObject(JSONObject.Type.OBJECT);

        json.AddField("BodyText", BodyText);
        json.AddField("Done", Done);

        return json;
    }

    public void Decode(JSONObject json)
    {
        BodyText = json.GetField("BodyText").str;
        Done = json.GetField("Done").b;
    }
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

        JSONObject body = new JSONObject(JSONObject.Type.OBJECT);

        foreach (var item in Body)
        {
            body.Add(item.Encode());
        }
        json.AddField("Body", body);

        return json;
    }

    public void Decode(JSONObject json)
    {
        ID = json.GetField("ID").i;
        Title = json.GetField("Title").str;
        Color = json.GetField("Color").i;

        Body.Clear();
        if (json.HasField("Body"))
        {
            
            JSONObject body = json.GetField("Body");
            foreach (var item in body.list)
            {
                DataNoteBody dnb = new DataNoteBody();
                dnb.Decode(item);
                Body.Add(dnb);
            }
        }
    }
}
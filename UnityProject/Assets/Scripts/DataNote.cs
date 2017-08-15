using System.Collections;
using System.Collections.Generic;


public class DataNote
{
    public int ID;
    public string Title;
    public List<string> Body = new List<string>();
    public bool Done = false;
    public COLOR color = COLOR.WHITE;
}

public enum COLOR
{
    WHITE,
    RED,
    BLUE,
    GREEN,
    YELLOW,
    ORANGE,
    PURPLE,
    BLACK,
};
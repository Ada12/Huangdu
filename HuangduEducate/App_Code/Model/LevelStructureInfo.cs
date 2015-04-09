using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///LevelStructureInfo 的摘要说明
/// </summary>
public class LevelStructureInfo
{
    private string _iterm;

    public string Iterm
    {
        get { return _iterm; }
    }
    private string _subiterm;

    public string Subiterm
    {
        get { return _subiterm; }
    }
    private int _position;

    public int Position
    {
        get { return _position; }
    }
    private string _five;

    public string Five
    {
        get { return _five; }
    }

    private string _four;

    public string Four
    {
        get { return _four; }
    }
    private string _three;

    public string Three
    {
        get { return _three; }
    }
    private string _two;

    public string Two
    {
        get { return _two; }
    }
    private string _one;

    public string One
    {
        get { return _one; }
    }

	public LevelStructureInfo(string item,string subitem,int position,string[] describe)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        this._iterm = item;
        this._subiterm = subitem;
        this._position = position;
        this._five = describe[0];
        this._four = describe[1];
        this._three = describe[2];
        this._two = describe[3];
        this._one = describe[4];
	}

    public LevelStructureInfo(string item, string subitem, int position)
    {
        //当不需要具体说明时重载此构造函数
        this._iterm = item;
        this._subiterm = subitem;
        this._position = position;
        this._five = "";
        this._four = "";
        this._three = "";
        this._two = "";
        this._one = "";
    }
    public string[] toStringList()
    {
        return new string[] { this.Iterm, this.Subiterm, this.Position.ToString(), this.Five, this.Four, this.Three, this.Two, this.One };
    }

    public string[] FiveToOne()
    {
        return new string[] { this.Five, this.Four, this.Three, this.Two, this.One };
    }

    public string[] toStringToShow()
    {
        return new string[] { this.Iterm, this.Subiterm, this.Five, this.Four, this.Three, this.Two, this.One };
    }
}
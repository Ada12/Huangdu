using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///AdminInfo 的摘要说明
/// </summary>
public class AdminInfo
{
    private string _ID;
    private string _Password;

	public AdminInfo()
	{
	}

    public AdminInfo(string my_id, string my_Password)
    {
        this._ID = my_id;
        this._Password = my_Password;
    }

    public string ID
    {
        get { return _ID; }
    }

    public string Password
    {
        get { return _Password; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///QYDCompare 的摘要说明
///用于比较两个字符串
///针对List.sort中第三个重载delegate而写。
/// </summary>
public class QYDCompare
{
    static public int stringCompare(string strx, string stry)
    {
        if (strx == stry)
        {
            return 0;
        }
        char[] xc = strx.ToCharArray();
        char[] yc = stry.ToCharArray();
        int ilength = Math.Min(strx.Length, stry.Length);
        for (int icounter = 0; icounter < ilength; ++icounter)
        {
            if (xc[icounter] > yc[icounter])
            {
                return 1;
            }
            else if (xc[icounter] < yc[icounter])
            {
                return -1;
            }
        }
        if (xc.Length < yc.Length)
        {
            return 1;
        }
        if (xc.Length > yc.Length)
        {
            return -1;
        }
        return 0;
    }


    public QYDCompare()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//

	}
}
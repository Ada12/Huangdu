<%@ WebHandler Language="C#" Class="LevelStrctHandler" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Collections.Generic;

public class LevelStrctHandler : IHttpHandler {
    
    private const string SessionIdLevelStructuers = "HDLevelStructMgmt";
    
    public void ProcessRequest (HttpContext context) {

        if (context.Request.Params["operation"].ToString() == "delete")
        {
            int irow = Convert.ToInt32(context.Request.Params["number"]);
            
            LevelStructure lvs = new LevelStructure();
            lvs.deleteItem(irow);
        }
        if (context.Request.Params["operation"].ToString() == "change")
        {
            string iptitem = context.Request.Params["item"];
            string iptsubitem = context.Request.Params["subitem"];
            string iptfive = context.Request.Params["five"];
            string iptfour = context.Request.Params["four"];
            string iptthree = context.Request.Params["three"];
            string ipttwo = context.Request.Params["two"];
            string iptone = context.Request.Params["one"];
            LevelStructureInfo li = new LevelStructureInfo(iptitem, iptsubitem, 0,
                new string[5] { iptfive, iptfour, iptthree, ipttwo, iptone });
            LevelStructure lvs = new LevelStructure();
            lvs.updateLevelInfo(li, 0);
        }
        
        
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
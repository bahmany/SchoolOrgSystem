using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// XHandle is a class that treats an xml file and represents it as a chat room,
/// create the file or load it, read, write or modify data using Linq to XML
/// </summary>
public class XHandle
{
    private string _path;
    private string _xPageName;
    private string _FullPath;

    private XDocument _xDoc;
    private bool _xDocCreated;

    private XElement _usersRoot;
    private int _onlineUsers;


	public XHandle(string _path)
	{
        this._path = _path;
        this._xDocCreated = false;
        this._xPageName = "Default";
        this._FullPath = this._path + @"\" + this._xPageName + ".xml";
        this._onlineUsers = 0;

        //Check the xml page if already exist
        LoadXPage();

        //or create it if it doesnt
        if (!_xDocCreated)
        {
            CreateXPage();
        }
        
	}

    public XHandle(string _path, string ChatRoomName)
    {
        this._path = _path;
        this._xDocCreated = false;
        this._xPageName = ChatRoomName;
        this._FullPath = this._path + @"\" + this._xPageName + ".xml";

        //Check the xml page if already exist
        LoadXPage();

        //or create it if it doesnt
        if (!_xDocCreated)
        {
            CreateXPage();
        }

    }

    private void CreateXPage()
    {
        _xDoc = new XDocument();
        XDeclaration dec = new XDeclaration("1.0", "utf-8", "yes");
        _xDoc.Declaration = dec;
        _usersRoot = new XElement("users");
        _xDoc.Add(_usersRoot);
        _xDoc.Save(_FullPath);
        _xDocCreated = true;
    }

    private void LoadXPage()
    {
        try
        {
            _usersRoot = XElement.Load(_FullPath);
            _xDocCreated = true;
        }
        catch
        {
            _xDocCreated = false;
        }
    }

    public void Say(string userName, string msg, DateTime dateTime)
    {
        XElement user = new XElement("user");
        XElement elementName = new XElement("name", userName);
        XElement elementLastMsg = new XElement("message", msg);
        XElement elementDate = new XElement("date", dateTime.ToString());
        user.Add(elementName);
        user.Add(elementLastMsg);
        user.Add(elementDate);
        _usersRoot.Add(user);
        _usersRoot.Save(_FullPath);
    }

    public void Join(string userName, DateTime dateTime)
    {
        string systemMsg = userName + " joined chat room.";
        this.Say(userName, systemMsg, dateTime);
    }

    public void Leave(string userName, DateTime dateTime)
    {
        var user = from o in _usersRoot.Elements("user")
                   where (string)o.Element("name").Value == userName
                   select o;

        user.Remove();

        _usersRoot.Save(_FullPath);
    }

    public List<string> GetOnlineNames()
    {
        List<string> names = new List<string>();
        var users = (from o in _usersRoot.Elements("user")
                    select o).Distinct();

        foreach (var user in users)
        {
            if (!names.Contains(user.Element("name").Value))
            {
                names.Add(user.Element("name").Value);
            }
        }
        _onlineUsers = names.Count;

        return names;
    }

    public int GetNumberOfOnlines()
    {
        var users = (from o in _usersRoot.Elements("user")
                     select o).Distinct();
        List<string> names = new List<string>();
        foreach (var user in users)
        {
            if (!names.Contains(user.Element("name").Value))
            {
                names.Add(user.Element("name").Value);
            }
        }
        if (names.Count > 0)
        {
            _onlineUsers = names.Count;
            return names.Count;
        }
        _onlineUsers = 0;
        return 0;
    }

    public List<string> GetMessagesHistory()
    {
        List<string> messages = new List<string>();
        var users = (from o in _usersRoot.Elements("user")
                     where o.Element("message").Value != string.Empty
                     orderby DateTime.Parse(o.Element("date").Value) ascending
                     select o).Distinct();
        foreach (var user in users)
        {
            string fullString = user.Element("name").Value + " : " + user.Element("message").Value;
            if (!messages.Contains(fullString))
            {
                messages.Add(fullString);
            }
        }
        return messages;
    }

    
}


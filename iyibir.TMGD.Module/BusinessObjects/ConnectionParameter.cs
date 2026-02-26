using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace iyibir.TMGD.Module.BusinessObjects;

[DefaultClassOptions]
[NavigationItem("Settings")]
public class ConnectionParameter(Session session) : BaseObject(session)
{
    private string _serverName;
    private string _databaseName;
    private string _userName;
    private string _password;

    public string ServerName
    {
        get => _serverName;
        set => SetPropertyValue(nameof(ServerName), ref _serverName, value);
    }

    public string DatabaseName 
        { get => _databaseName; set => SetPropertyValue(nameof(DatabaseName), ref _databaseName, value); }

    public string UserName { get => _userName; set => SetPropertyValue(nameof(UserName), ref _userName, value); }

    public string Password { get => _password; set => SetPropertyValue(nameof(Password), ref _password, value); }
}

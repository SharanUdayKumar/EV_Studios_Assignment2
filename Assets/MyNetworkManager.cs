using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class MyNetworkManager : NetworkManager
{


    // Start is called before the first frame update
    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("ServerStarted0");
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        Debug.Log("ServerStopped0");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.Log("Connected to Server");
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        Debug.Log("Disconnected from server");
    }
}

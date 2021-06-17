using System.IO.Pipes;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnityPipeServer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Thread serverReadThread = new Thread(ServerThread_Read);
        serverReadThread.Start();
    }

    private void ServerThread_Read(object obj)
    {
        Debug.Log("Server: Thread started");

       NamedPipeServerStream namedPipeServerStream = new NamedPipeServerStream("ServerRead_ClientWrite", PipeDirection.In);

        namedPipeServerStream.WaitForConnection();
        Debug.Log("Server: Client has connected");

        StreamString streamString = new StreamString(namedPipeServerStream);
        string message = streamString.ReadString();
        Debug.Log("Server: Recieved " + message);

        namedPipeServerStream.Close();
    }
}

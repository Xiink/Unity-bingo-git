using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class Client : MonoBehaviour
{
    WebSocket ws = new WebSocket("ws://localhost:443");
    // Start is called before the first frame update
    void Awake()
    {
        ws.OnError += (sender, e) => {
            Debug.LogException(e.Exception);
        };

        ws.OnMessage += (sender, e) => {
            Debug.Log("Says: " + e.Data);
        };

        ws.OnClose += (sender, e) => {
            Debug.Log("Closed");
        };

        ws.OnOpen += (sender, e) => {
            //ws.Send("Hello server");
            //ws.Send("Siyuan");
            //ws.Send("Wang");
        };

        try {
            ws.Connect();
        }catch(Exception e) {
            Debug.Log(e.ToString());
        }
    }
}

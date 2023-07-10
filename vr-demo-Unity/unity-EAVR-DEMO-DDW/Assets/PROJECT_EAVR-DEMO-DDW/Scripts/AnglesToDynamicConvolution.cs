using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class AnglesToDynamicConvolution : MonoBehaviour
{
    float RotateY = 0f;
    float RotateY0 = 0f;
    private static int localPort;
    private GameObject[] camera;
    // prefs

    private string IP;  // define in init
    public int port = 8052;  // define in init

    // "connection" things
    IPEndPoint remoteEndPoint;
    UdpClient client;

    // Use this for initialization
    void Start()
    {

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        // define
        IP = "127.0.0.1";
        port = 8052;

        // ----------------------------
        // Senden
        // ----------------------------
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();

    }

    void Send_rotation(float RotateY)
    {

        if (Math.Abs(RotateY - RotateY0) < 1)
            return;

        try
        {
            string text;

            Vector3 xyz = camera[0].transform.eulerAngles;
            float angle = xyz[1];
            text = angle.ToString();

            if (text != "")
            {
                byte[] data = Encoding.ASCII.GetBytes(text);

                client.Send(data, data.Length, remoteEndPoint);
            }
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
        RotateY0 = RotateY;
    }

    // Update is called once per frame
    void Update()
    {
        //RotateY = Input.GetAxis("RotateY"); //Corresponds to the Input Manager in Unity. If the correct key is pressed to activate RotateY.
        //Send_rotation(RotateY); //Calls the Rotate function, which actually rotate funtion
        camera = GameObject.FindGameObjectsWithTag("MainCamera");
        Vector3 xyz = camera[0].transform.eulerAngles;

        RotateY = xyz[1];
        Send_rotation(RotateY);

    }
}

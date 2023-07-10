using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseEnvironment : MonoBehaviour
{
    public Button SportsHall;
    public Button ReverberationRoom;
    public Text WelcomeText;

    private static int localPort;
    private string IP;  // define in init
    public int port = 8051;  // define in init


    // "connection" things
    IPEndPoint remoteEndPoint;
    UdpClient client;
    void Start()
    {

        IP = "127.0.0.1";
        port = 8051;

        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();

    }

    // Update is called once per frame
    public void SportHall()
    {
        SceneManager.LoadScene(1);
        byte[] data1;
        data1 = Encoding.ASCII.GetBytes("S");
        client.Send(data1, data1.Length, remoteEndPoint);
        Debug.Log("S");

    }

    public void RevRoom()
    {
        SceneManager.LoadScene(2);
        byte[] data1;
        data1 = Encoding.ASCII.GetBytes("R");
        client.Send(data1, data1.Length, remoteEndPoint);
        Debug.Log("R");


    }

    public void MainScreen()
    {
        SceneManager.LoadScene(0);
        byte[] cleanGPU = Encoding.ASCII.GetBytes("H"); //Try sending K
        client.Send(cleanGPU, cleanGPU.Length, remoteEndPoint);

    }
}

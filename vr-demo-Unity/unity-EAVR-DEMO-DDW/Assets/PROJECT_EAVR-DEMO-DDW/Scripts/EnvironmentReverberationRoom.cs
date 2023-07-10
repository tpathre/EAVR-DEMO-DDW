using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class EnvironmentReverberationRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Intropanel;
    public GameObject GamePanel;
    public GameObject EndPanel;

    public Button Play;
    public Button choiceRed;
    public Button choiceYellow;
    public Button choiceGreen;

    public Text Instruction;
    public Text wrongTryAgain;
    public Button tryAgain;
    public Button goBackMainScreen;

    public ChooseEnvironment scriptB;

    public int counter = 0;

    private string IP;  // define in init
    public int port = 8053;  // define in init

    // "connection" things
    IPEndPoint remoteEndPoint;
    UdpClient client;
    // Start is called before the first frame update

    void Start()
    {

        scriptB = GameObject.Find("Canvas").GetComponent<ChooseEnvironment>();

        // define
        IP = "127.0.0.1";
        port = 8053;

        // ----------------------------
        // Senden
        // ----------------------------
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();


        Play.gameObject.SetActive(false);
        choiceRed.gameObject.SetActive(false);
        choiceYellow.gameObject.SetActive(false);
        choiceGreen.gameObject.SetActive(false);
        tryAgain.gameObject.SetActive(false);
        wrongTryAgain.gameObject.SetActive(false);
        Instruction.gameObject.SetActive(false);
        goBackMainScreen.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(false);
        EndPanel.gameObject.SetActive(false);

        Play.onClick.AddListener(GameReverberationRoom);

    }

    // Update is called once per frame
    public void GameReverberationRoom()
    {

        byte[] micon = Encoding.ASCII.GetBytes("M");
        client.Send(micon, micon.Length, remoteEndPoint);

        Intropanel.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(true);
        Instruction.gameObject.SetActive(true);
        EndPanel.gameObject.SetActive(false);
        tryAgain.gameObject.SetActive(false);
        wrongTryAgain.gameObject.SetActive(false);

        choiceRed.gameObject.SetActive(true);
        choiceYellow.gameObject.SetActive(true);
        choiceGreen.gameObject.SetActive(true);

        choiceRed.onClick.AddListener(Correct); //Red is from where your voice comes
        choiceYellow.onClick.AddListener(Incorrect);
        choiceGreen.onClick.AddListener(Incorrect);

    }

    public void Correct()
    {

        Intropanel.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(false);
        EndPanel.gameObject.SetActive(true);
        Instruction.gameObject.SetActive(false);
        choiceRed.gameObject.SetActive(false);
        choiceYellow.gameObject.SetActive(false);
        choiceGreen.gameObject.SetActive(false);
        goBackMainScreen.gameObject.SetActive(true);
        goBackMainScreen.onClick.AddListener(scriptB.MainScreen);
        Debug.Log("Yay thats correct");
        counter++;
        saveScore();
    }

    public void Incorrect()
    {
        Intropanel.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(true);
        Instruction.gameObject.SetActive(false);
        EndPanel.gameObject.SetActive(false);
        choiceRed.gameObject.SetActive(false);
        choiceYellow.gameObject.SetActive(false);
        choiceGreen.gameObject.SetActive(false);
        wrongTryAgain.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);
        tryAgain.onClick.AddListener(GameReverberationRoom);
        counter--;
        saveScore();

    }

    public void saveScore()
    {
        SaveResponse.AppendToData(
            new string[3] {
                SceneManager.GetActiveScene().buildIndex.ToString(),
                SceneIndexToName.GetSceneIndex(SceneManager.GetActiveScene().buildIndex),
                counter.ToString(),
    }
            ); ;
    }
}

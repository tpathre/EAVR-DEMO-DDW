using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class EnvironmentSportsHall : MonoBehaviour
{
    public GameObject Intropanel;
    public GameObject GamePanel;
    public GameObject EndPanel;

    public Button Play;
    public Button choiceRed;
    public Button choiceBlue;
    public Button choiceOrange;

    public Text Instruction;
    public Text wrongTryAgain;
    public Button tryAgain;
    public Button goBackMainScreen;

    public int counter = 0;
    public ChooseEnvironment scriptB;

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
        choiceBlue.gameObject.SetActive(false);
        choiceOrange.gameObject.SetActive(false);
        tryAgain.gameObject.SetActive(false);
        wrongTryAgain.gameObject.SetActive(false);
        Instruction.gameObject.SetActive(false);
        goBackMainScreen.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(false);
        EndPanel.gameObject.SetActive(false);
        Play.onClick.AddListener(GameSportsHall);

    }

    // Update is called once per frame
    public void GameSportsHall()
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
        choiceBlue.gameObject.SetActive(true);
        choiceOrange.gameObject.SetActive(true);
        choiceRed.onClick.AddListener(Incorrect);
        choiceBlue.onClick.AddListener(Incorrect);
        choiceOrange.onClick.AddListener(Correct);

    }

    public void Correct()
    {

        Intropanel.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(false);
        EndPanel.gameObject.SetActive(true);
        Instruction.gameObject.SetActive(false);
        choiceRed.gameObject.SetActive(false);
        choiceBlue.gameObject.SetActive(false);
        choiceOrange.gameObject.SetActive(false);
        goBackMainScreen.gameObject.SetActive(true);
        goBackMainScreen.onClick.AddListener(scriptB.MainScreen);
        Debug.Log("Yay! that's correct");
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
        choiceBlue.gameObject.SetActive(false);
        choiceOrange.gameObject.SetActive(false);
        wrongTryAgain.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);
        tryAgain.onClick.AddListener(GameSportsHall);
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

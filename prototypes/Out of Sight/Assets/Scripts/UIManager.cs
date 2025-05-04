using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager sharedInstance;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject lossPanel;
    [SerializeField] GameObject winPanel;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject controlPanel1;
    [SerializeField] GameObject controlPanel2;

    void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        winPanel.SetActive(false);
        lossPanel.SetActive(false);
        startPanel.SetActive(true);

        if (GameManager.checkScene("NewAntiBreakout2")||GameManager.checkSceneContains("AB2LV"))
        {
            controlPanel1.SetActive(false);
            controlPanel2.SetActive(false);
        }
    }

    void Update()
    {
        UpdateLivesText();
        UpdateScoreText();

        if (gameOver())
        {
            lossPanel.SetActive(true);
        }
        else if (gameWon())
        {
            winPanel.SetActive(true);
        }
    }

    void UpdateLivesText()
    {
        livesText.text = "Lives: " + GameManager.sharedInstance.getLives();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.sharedInstance.getScore();
    }

    bool gameOver()
    {
        return GameManager.sharedInstance.getGameEnded();
    }

    bool gameWon()
    {
        return GameManager.sharedInstance.getGameWon();
    }

    public void startGame()
    {
        winPanel.SetActive(false);
        lossPanel.SetActive(false);
        startPanel.SetActive(false);
    }

    public void controlScreen()
    {
        if (GameManager.sharedInstance.getRuleset() == 0)
        {
            controlPanel1.SetActive(true);
            controlPanel2.SetActive(false);
        }
        else
        {
            controlPanel1.SetActive(false);
            controlPanel2.SetActive(true);
        }
    }

    public void controlBack()
    {
        Start();
    }
}

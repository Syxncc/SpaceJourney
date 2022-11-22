using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;
    public GameObject Retry;
    public GameObject Exit;
    public GameObject Done;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI MessageTxt;
    public TextMeshProUGUI RewardTxt;

    int totalQuestions;
    public int score;
    public int coinGain;

    public void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void End()
    {
        GoPanel.SetActive(false);
        QuizPanel.SetActive(false);
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        score = 0;
        
    }
    
    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + " out of " + totalQuestions;

        if(score >= totalQuestions/2)
        {
            MessageTxt.text = "Great, you learned!\n keep it up";
            RewardTxt.text = "Coin Reward: " + coinGain;
            Done.SetActive(true);
        }
        else
        {
            MessageTxt.text = "Too bad, review again the book of records";
            RewardTxt.text = ".";
            Retry.SetActive(true);
            Exit.SetActive(true);
        }
    }

    public void correct()
    {
        score += 1;
        coinGain += 100;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length ; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;    
            options[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Finish");
            GameOver();
        }

    }
}

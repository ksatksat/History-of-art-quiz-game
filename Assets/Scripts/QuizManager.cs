using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace HistoryOfArtQuizGame
{
    public class QuizManager : MonoBehaviour
    {
        public List<QuestionAndAnswers> qAndAs;
        public GameObject[] options;
        public int currentQuestion;
        public Text questionTxt;
        public GameObject quizPanel;
        public GameObject gameOverPanel;
        public Text scoreTxt;
        int totalQuestions = 0;
        public int score;
        public Color startColorOfAnswerButtons;
        private void Start()
        {
            totalQuestions = qAndAs.Count;
            gameOverPanel.SetActive(false);
            GenerateQuestion();
        }
        public void Correct()
        {
            score += 1;
            qAndAs.RemoveAt(currentQuestion);
            StartCoroutine(WaitForNextQuestion());
        }
        public void Wrong()
        {
            qAndAs.RemoveAt(currentQuestion);
            StartCoroutine(WaitForNextQuestion());
        }
        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        void GenerateQuestion()
        {
            if (qAndAs.Count > 0)
            {
                currentQuestion = Random.Range(0, qAndAs.Count);
                questionTxt.text = qAndAs[currentQuestion].question;
                SetAnswers();
            }
            else
            {
                GameOver();
            }
        }
        void SetAnswers()
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<Image>().color = startColorOfAnswerButtons;
                options[i].GetComponent<AnswerScript>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<Image>().sprite 
                = qAndAs[currentQuestion].answers[i];
                if (qAndAs[currentQuestion].correctAnswer == i + 1)
                {
                    options[i].GetComponent<AnswerScript>().isCorrect = true;
                }
            }
        }
        void GameOver()
        {
            quizPanel.SetActive(false);
            gameOverPanel.SetActive(true);
            scoreTxt.text = score + "/" + totalQuestions;
        }
        IEnumerator WaitForNextQuestion()
        {
            yield return new WaitForSeconds(0.5f);
            GenerateQuestion();
        }
    }
}


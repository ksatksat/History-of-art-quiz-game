using UnityEngine;
using UnityEngine.UI;
namespace HistoryOfArtQuizGame
{
    public class AnswerScript : MonoBehaviour
    {
        public bool isCorrect = false;
        public QuizManager quizManager;
        public void Answer()
        {
            if (isCorrect)
            {
                GetComponent<Image>().color = Color.green;
                quizManager.Correct();
            }
            else
            {
                GetComponent<Image>().color = Color.red;
                quizManager.Wrong();
            }
        }
    }
}


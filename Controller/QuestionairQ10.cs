using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class QuestionairQ10
    {
        public QuestionairQ10() { }
        private Guid formID;
        private int compantID;

        private string questionNumber;
        private string questionText;
        private string questionAnswer;
        private bool showHideProperty;

        private string Q1;
        private bool Q1Answer;
        private bool Q1ShowHide;


        private string Q2;
        private bool Q2Answer;
        private string Q3;
        private bool Q3Answer;
        private string Q4;
        private bool Q4Answer;
        private string Q5;
        private bool Q5Answer;
        private string Q6;
        private bool Q6Answer;
        private string Q7;
        private bool Q7Answer;
        private string Q8;
        private bool Q8Answer;
        private string Q9;
        private bool Q9Answer;
        private string Q10;

        private string Q11;
        private string Q12;
        private bool Q10Answer;
        private bool Q11Answer;
        private bool Q12Answer;

        private bool Q2ShowHide;
        private bool Q3ShowHide;
        private bool Q4ShowHide;
        private bool Q5ShowHide;
        private bool Q6ShowHide;
        private bool Q7ShowHide;
        private bool Q8ShowHide;
        private bool Q9ShowHide;
        private bool Q10ShowHide;
        private bool Q11ShowHide;
        private bool Q12ShowHide;


        public string QuestionNumber { get { return questionNumber; } set { questionNumber = value; } }
        public string QuestionText { get { return questionText; } set { questionText = value; } }
        public string QuestionAnswer { get { return questionAnswer; } set { questionAnswer = value; } }
        public bool ShowHideProperty { get { return showHideProperty; } set { showHideProperty = value; } }

        public Guid FormID { get { return formID; } set { formID = value; } }
        public int CompantID { get { return compantID; } set { compantID = value; } }
        public string _Q1  { get { return Q1; } set {  Q1 = value; } }
        public string _Q2 { get { return Q2; } set { Q2 = value; } }
        public string _Q3 { get { return Q3; } set { Q3 = value; } }
        public string _Q4 { get { return Q4; } set { Q4 = value; } }
        public string _Q5 { get { return Q5; } set { Q5 = value; } }
        public string _Q6 { get { return Q6; } set { Q6 = value; } }
        public string _Q7 { get { return Q7; } set { Q7 = value; } }
        public string _Q8 { get { return Q8; } set { Q8 = value; } }
        public string _Q9 { get { return Q9; } set { Q9 = value; } }
        public string _Q10 { get { return Q10; } set { Q10 = value; } }
        public string _Q11 { get { return Q11; } set { Q11 = value; } }
        public string _Q12 { get { return Q12; } set { Q12 = value; } }

        public bool _Q1Answer { get { return Q1Answer; } set { Q1Answer = value; } }
        public bool _Q2Answer { get { return Q2Answer; } set { Q2Answer = value; } }
        public bool _Q3Answer { get { return Q3Answer; } set { Q3Answer = value; } }
        public bool _Q4Answer { get { return Q4Answer; } set { Q4Answer = value; } }
        public bool _Q5Answer { get { return Q5Answer; } set { Q5Answer = value; } }
        public bool _Q6Answer { get { return Q6Answer; } set { Q6Answer = value; } }
        public bool _Q7Answer { get { return Q7Answer; } set { Q7Answer = value; } }
        public bool _Q8Answer { get { return Q8Answer; } set { Q8Answer = value; } }
        public bool _Q9Answer { get { return Q9Answer; } set { Q9Answer = value; } }
        public bool _Q10Answer { get { return Q10Answer; } set { Q10Answer = value; } }
        public bool _Q11Answer { get { return Q11Answer; } set { Q11Answer = value; } }
        public bool _Q12Answer { get { return Q12Answer; } set { Q12Answer = value; } }
        public bool _Q1ShowHide { get { return Q1ShowHide; } set { Q1ShowHide = value; } }
        public bool _Q2ShowHide { get { return Q2ShowHide; } set { Q2ShowHide = value; } }
        public bool _Q3ShowHide { get { return Q3ShowHide; } set { Q3ShowHide = value; } }
        public bool _Q4ShowHide { get { return Q4ShowHide; } set { Q4ShowHide = value; } }
        public bool _Q5ShowHide { get { return Q5ShowHide; } set { Q5ShowHide = value; } }
        public bool _Q6ShowHide { get { return Q6ShowHide; } set { Q6ShowHide = value; } }
        public bool _Q7ShowHide { get { return Q7ShowHide; } set { Q7ShowHide = value; } }
        public bool _Q8ShowHide { get { return Q8ShowHide; } set { Q8ShowHide = value; } }
        public bool _Q9ShowHide { get { return Q9ShowHide; } set { Q9ShowHide = value; } }
        public bool _Q10ShowHide { get { return Q10ShowHide; } set { Q10ShowHide = value; } }
        public bool _Q11ShowHide { get { return Q11ShowHide; } set { Q11ShowHide = value; } }
        public bool _Q12ShowHide { get { return Q12ShowHide; } set { Q12ShowHide = value; } }
    }
}

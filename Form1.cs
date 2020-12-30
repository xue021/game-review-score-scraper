using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GameReviewScoreScraper
{
    public partial class Form1 : Form
    {
        string selectedYear = "2020";
        int numResults = 25;
        

        public Form1()
        {
            InitializeComponent();
        }



        private void btnFetch_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            //get currentYear, if selected year is greater than the current year, replace selected year with current year (so you cant pull querys for years that havent happened yet
            DateTime now = DateTime.Today;
            int currentYear = Int16.Parse(now.ToString("yyyy"));
            if (Int16.Parse(selectedYear) > currentYear)
            {
                numericYear.Value = currentYear;
                selectedYear = currentYear.ToString();
            }

            //empty txtMainTxt
            txtMainTxt.Text = "";

            //get web data for google query of "best games <year>"
            string webText = getWebData("https://www.google.com/search?q=best+games+" + selectedYear);



            ArrayList gameList = new ArrayList();//create list of game names

            //parse google query for numResults # of top games found in the google query
            for (int i = 0; i < numResults; i++)
            {
                webText = webText.Substring(webText.IndexOf("amp;q=") + 6);
                gameList.Add(webText.Substring(0, webText.IndexOf("&amp")));
            }


            for (int i = 0; i < numResults; i++)
            {
                //few char replacements, added as found (hacky i know)
                gameList[i] = gameList[i].ToString().Replace("+", " ");
                gameList[i] = gameList[i].ToString().Replace("%2B", "+");
                gameList[i] = gameList[i].ToString().Replace("%C3%A9", "é");
                gameList[i] = gameList[i].ToString().Replace("%E2%80%93", "-");
                gameList[i] = gameList[i].ToString().Replace("%26", "&");
                gameList[i] = gameList[i].ToString().Replace("%C3%BC", "ü");
                gameList[i] = gameList[i].ToString().Replace("%C5%8C", "Ō");

                //txtMainTxt.Text += gameList[i] + "\n";

            }


            //creates array that will store both game names and scores
            Game[] gamesArr = new Game[gameList.Count];

            //stores name and fetches + stores the games score into games arr for each item in gameList
            for (int i = 0; i < gameList.Count; i++)
            {
                try
                {
                    gamesArr[i] = new Game(gameList[i].ToString(), getOpenCriticScoreFromUrl(getOpenCriticUrl(gameList[i].ToString())));

                }
                catch
                {
                    Console.WriteLine("No score found for " + gameList[i].ToString());
                    gamesArr[i] = new Game(gameList[i].ToString(), -1);

                }

                //calculate total progress in fetching data and update progress bar
                double prog = Math.Round((double)(i + 1) / (double)gameList.Count * 100);
                Console.WriteLine(prog + "%");
                progressBar.Value = (int)prog;
            }

            //sort the array of games in descending order of score
            Array.Sort(gamesArr, new GameScoreComparer());
            Array.Reverse(gamesArr);

            //write game score data to text field in form: <game name>(<score>), if a score is unavailable put "n/a" instead of -1
            for (int i = 0; i < gamesArr.Length; i++)
            {
                if (gamesArr[i].score > -1)
                {
                    Console.WriteLine(gamesArr[i].name + " - " + gamesArr[i].score);
                    txtMainTxt.Text += gamesArr[i].name + " (" + gamesArr[i].score + ")\n";
                }
                else
                {
                    Console.WriteLine(gamesArr[i].name + " - " + gamesArr[i].score);
                    txtMainTxt.Text += gamesArr[i].name + " (n/a)\n";
                }

            }
        }


        //this function takes a url and returns the raw html text of the page
        private string getWebData(string siteUrl)
        {
            //this code snippet modified from: https://stackoverflow.com/questions/16642196/get-html-code-from-website-in-c-sharp
            string webText = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(siteUrl);
            request.Timeout = 2000; //set timeout is important 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                string data = readStream.ReadToEnd();
                webText = data;
                response.Close();
                readStream.Close();
            }
            return webText;
            //end snippet
        }
        
        //functions to update variables when their respective fields change
        private void numericYear_ValueChanged(object sender, EventArgs e)
        {
            selectedYear = numericYear.Value.ToString();
        }

        private void numericNumResults_ValueChanged(object sender, EventArgs e)
        {
            numResults = Int16.Parse(numericNumResults.Value.ToString());
        }




        //gets the url of the first page from opencritic in a google query using the games name + opencritic as the search (i.e.: "Cyberpunk 2077 opencritic")
        private string getOpenCriticUrl(string gameName)
        {

            string query = gameName + "+opencritic";
            query = query.Replace(" ", "+");
            string searchResult = getWebData("https://www.google.com/search?q=" + query);


            searchResult = searchResult.Substring(searchResult.IndexOf("https://opencritic.com/"));
            searchResult = searchResult.Substring(0, searchResult.IndexOf("&amp"));
            return searchResult;
        }

        //finds the score value for a game given an opencritic url for a game, if it cant returns -1
        private short getOpenCriticScoreFromUrl(string ocUrl)
        {
            string webData = getWebData(ocUrl);
            webData = webData.Substring(webData.IndexOf("ratingValue") + 14);
            webData = webData.Substring(0, webData.IndexOf(","));
            Console.WriteLine(webData);
            try
            {
                return (short)(float.Parse(webData) + 0.5f);
            }
            catch
            {
                return -1;
            }

        }

       
    }
}

//simple object to store game name and score
class Game
{
    public string name = "null";
    public short score = -1;
    public Game(string gameName, short gameScore)
    {
        name = gameName;
        score = gameScore;

    }
}

//used for comparing scores of game objects
class GameScoreComparer : IComparer
{
    public int Compare(object x, object y)
    {
        return (new CaseInsensitiveComparer()).Compare(((Game)x).score, ((Game)y).score);
    }
}

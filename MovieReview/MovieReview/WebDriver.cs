using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace MovieReview
{
    /// <summary>
    /// This class is created for the seeking browser
    /// </summary>
    class WebDriver
    {
        static IWebDriver driver;

        static Dictionary<string, int> adjs;
        /// <summary>
        /// Cretes new Feature and initializes all adjecctives 
        /// </summary>
        static public void init()
        {
            driver = new ChromeDriver(@"C:\Users\Асем Зайткалиева\Desktop\chromedriver_win32");
            MovieFeature.features = new List<MovieFeature>();
            adjs = new Dictionary<string, int>();
            FileStream fs = new FileStream("all_adjectives.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                adjs.Add(line, 0);
            }
            sr.Close();
            fs.Close();
            AddingFeatures();
        }

        /// <summary>
        /// This method adds features
        /// </summary>
        static public void AddingFeatures()
        {
            FileStream fs = new FileStream("all-words.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = "", name = "";
            List<string> syn;
            bool newOne = true;
            while ((line = sr.ReadLine()) != null)
            {
                if (newOne)
                {
                    name = line;
                    newOne = false;
                }
                else
                {
                    syn = new List<string>();
                    syn.Add(line);
                    while ((line = sr.ReadLine()) != "-" && line != null)
                    {
                        syn.Add(line);
                    }
                    MovieFeature.features.Add(new MovieFeature(name, syn, new Dictionary<string, int>(adjs)));
                    newOne = true;
                }
            }
            fs.Close();
            sr.Close();
        }

        /// <summary>
        /// This method parses reviews from webpage
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Summary</returns>
        public static string FindingMovieReview(string name)
        {
            driver.Navigate().GoToUrl("http://www.imdb.com/");
            IWebElement input = driver.FindElement(By.XPath("//*[@id='navbar-query']"));
            IWebElement button = driver.FindElement(By.XPath("//*[@id='navbar-submit-button']"));
            input.SendKeys(name);
            button.Click();
            IWebElement first = driver.FindElement(By.XPath("//*[@id='main']/div/div[2]/table/tbody/tr[1]/td[2]/a"));
            driver.Navigate().GoToUrl(first.GetAttribute("href"));

            IWebElement review = driver.FindElement(By.XPath("//*[@id='titleUserReviewsTeaser']/div/div[3]/a[2]"));
            driver.Navigate().GoToUrl(review.GetAttribute("href"));
            for (int i = 2; i <= 490; i++)
            {
                try
                {
                    searching();
                    if (i <= 8) review = driver.FindElement(By.XPath("//*[@id='tn15content']/table[1]/tbody/tr/td[2]/a[" + i + "]"));
                    else review = driver.FindElement(By.XPath("//*[@id='tn15content']/table[1]/tbody/tr/td[2]/a[8]"));
                    driver.Navigate().GoToUrl(review.GetAttribute("href"));
                }
                catch (NoSuchElementException)
                {
                    break;
                }
            }
            return MovieFeature.getSummary();
        }
        /// <summary>
        /// Parses each sentence and checks it for feature and adjectives
        /// </summary>
        private static void searching()
        {
            for (int i = 1; i <= 10; i++)
            {
                string review_text = getText(i);
                MovieFeature feature;
                string curAd;
                char[] pun = { '.', '!', '?' };
                string[] sep = { ",", " ", ";", ":", "/", ")", "(", "\"", "<", ">", "\r\n", "\n" };
                string[] sentences = review_text.Split(pun, StringSplitOptions.RemoveEmptyEntries);
                foreach (string sentence in sentences)
                {
                    curAd = null;
                    string[] words = sentence.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < words.Length; j++)
                    {
                        if (words[j].Length >= 4)
                        {
                            if (IsAdj(words[j])) { curAd = words[j]; }
                            else if ((feature = MovieFeature.getMF(words[j])) != null)
                            {
                                if (curAd != null) { feature.adjs[curAd]++; curAd = null; }
                                else
                                {
                                    for (int k = j + 1; k < words.Length; k++)
                                    {
                                        if (IsAdj(words[k])) { feature.adjs[words[k]]++; break; }
                                        else if (MovieFeature.getMF(words[k]) != null) { feature = MovieFeature.getMF(words[k]); break; }
                                        j = k + 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets text from review
        /// </summary>
        /// <param name="i"></param>
        /// <returns>string text</returns>
        private static string getText(int i)
        {
            return driver.FindElement(By.XPath("//*[@id='tn15content']/p[" + i + "]")).Text;
        }
        /// <summary>
        ///  Check if the word is adjective
        /// </summary>
        /// <param name="s">Word to be checked</param>
        /// <returns> boolean value</returns>
        private static bool IsAdj(string s)
        {
            if (adjs.Keys.Contains(s)) return true;
            else return false;
        }

    }
}
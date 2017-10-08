using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BigWords
{
    [Serializable]
    public class Program
    {
        public static Dictionary<string, int> features;

        static void Main(string[] args)
        {
            features = new Dictionary<string, int>();
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Асем Зайткалиева\Documents");
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                //string review = sr.ReadToEnd();
                //char[] sep = { ',', '.', '_', '!', '?', ' ', '/', '<', '>', ':', ';', ')', '(', '"', '\'' };
                /*string [] words = review.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    string w = word.ToLower();
                    if (features.Keys.Contains(w)) features[w]++;
                    else if (w.Length >= 4) features.Add(w, 1);
                }*/
                string line;
                char [] sep = { ' ' };
                while ((line = sr.ReadLine()) != null)
                {
                        string[] words = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            if (features.Keys.Contains(words[0])) features[words[0]] += int.Parse(words[1]);
                            else features.Add(words[0], int.Parse(words[1]));
                        }
                        catch (IndexOutOfRangeException) { continue; }
                }

                sr.Close();
                fs.Close();
            }


           /* FileStream fs = new FileStream(@"C:\Users\Асем Зайткалиева\Documents\dataOfWord.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string [] words = line.Split(' ');
                try
                {
                    features.Add(words[0], int.Parse(words[1]));
                }
                catch (ArgumentException)
                {
                    continue;
                }
                if (features.Keys.Contains(words[0])) features[words[0]] += int.Parse(words[1]);
                else features.Add(words[0], int.Parse(words[1]));
            }
            sr.Close();
            fs.Close();*/


            FileStream fw = new FileStream(@"C:\Users\Асем Зайткалиева\Documents\FinalDataOfWord.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fw);
            var List1 = features.ToList();
            List1.Sort((p1, p2) => -1 * p1.Value.CompareTo(p2.Value));
            foreach (var item in List1)
            {
                if (item.Value >= 100) sw.WriteLine(item.Key + " " + item.Value);
            }
            sw.Close();
            fw.Close();
            //FindingMovieReview("Schindler's List");
        }

        static void FindingMovieReview (string name)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Асем Зайткалиева\Desktop\chromedriver_win32");
            driver.Navigate().GoToUrl("http://www.imdb.com/");
            IWebElement input = driver.FindElement(By.XPath("//*[@id='navbar-query']"));
            IWebElement button = driver.FindElement(By.XPath("//*[@id='navbar-submit-button']"));
            input.SendKeys(name);
            button.Click();
            IWebElement first = driver.FindElement(By.XPath("//*[@id='main']/div/div[2]/table/tbody/tr[1]/td[2]/a"));
            driver.Navigate().GoToUrl(first.GetAttribute("href"));

            Stopwatch time = new Stopwatch();
            time.Start();
            IWebElement review = driver.FindElement(By.XPath("//*[@id='titleUserReviewsTeaser']/div/div[3]/a[2]"));
            driver.Navigate().GoToUrl(review.GetAttribute("href"));
            for (int i = 2; i <= 490; i++)
            {
                try
                {
                    searching(driver);
                    if (i <= 8) review = driver.FindElement(By.XPath("//*[@id='tn15content']/table[1]/tbody/tr/td[2]/a[" + i + "]"));
                    else review = driver.FindElement(By.XPath("//*[@id='tn15content']/table[1]/tbody/tr/td[2]/a[8]"));
                    driver.Navigate().GoToUrl(review.GetAttribute("href"));
                }
                catch (NoSuchElementException)
                {
                    break;
                }
            }
            time.Stop();
            Console.WriteLine(time.ElapsedMilliseconds);
           
            FileStream fw = new FileStream(@"C:\Users\Асем Зайткалиева\Documents\dataOfWord.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fw);
            var List1 = features.ToList();
            List1.Sort((p1, p2) => -1 * p1.Value.CompareTo(p2.Value));
            foreach (var item in List1)
            {
                sw.WriteLine(item.Key + " " + item.Value);
            }
            sw.Close();
            fw.Close();
        }

        static void searching(IWebDriver driver)
        {
            for (int i = 1; i <= 10; i++)
            {
                string review_text = getText(driver, i);
                var punctuation = review_text.Where(Char.IsPunctuation).Distinct().ToArray();
                var words = review_text.Split().Select(x => x.Trim(punctuation).ToLower());
                foreach (string word in words)
                {
                    if (word.Length > 2)
                    {
                        if (features.ContainsKey(word)) features[word]++;
                        else features.Add(word, 0);
                    }
                }
            }
        }

        static string getText(IWebDriver driver, int i)
        {
            return driver.FindElement(By.XPath("//*[@id='tn15content']/p[" + i + "]")).Text;
        }
    }
}

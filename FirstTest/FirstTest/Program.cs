using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace FirstTest
{
    class Program
    {
        static Dictionary<string, int> features;
        static void Main(string[] args)
        {
            string[] films = { "The Shawshank Redemption", "The Godfather", "The Godfather: Part II", "The Dark Knight", "Schindler's List" };
            foreach (var film in films)
            {
                new Thread(() => doing(film)).Start();
            }
            Console.WriteLine("Done");
            Console.ReadKey();

        }

        static void doing (string name)
        {
            FileStream fs = new FileStream(@"C:\Users\Асем Зайткалиева\Desktop\dictionary2.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string text;
            features = new Dictionary<string, int>();
            while ((text = sr.ReadLine()) != null)
            {
                string[] words = text.Split('_');
                foreach (var word in words)
                {
                    features.Add(word, 0);
                }
            }
            sr.Close();
            fs.Close();

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
            for (int i = 2; i <= 240; i++)
            {
                try
                {
                    searching(driver);
                    if (i <= 8) review = driver.FindElement(By.XPath("//*[@id='tn15content']/table[1]/tbody/tr/td[2]/a[" + i + "]"));
                    else review = driver.FindElement(By.XPath("//*[@id='tn15content']/table[1]/tbody/tr/td[2]/a[8]"));
                    driver.Navigate().GoToUrl(review.GetAttribute("href"));
                } catch (NoSuchElementException)
                {
                    break;
                }
            }
            time.Stop();
            Console.WriteLine(time.ElapsedMilliseconds);
            Random rn = new Random();
            int ind = rn.Next(1, 100);
            FileStream fw = new FileStream(@"C:\Users\Асем Зайткалиева\Documents\file" + ind + ".txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fw);
            foreach (var item in features)
            {
                sw.WriteLine(item.Key + " " + item.Value);
            }
        }
        static void searching (IWebDriver driver)
        {
            
            for (int i = 1; i <= 10; i++)
            {
                string review_text = getText(driver, i);
                var punctuation = review_text.Where(Char.IsPunctuation).Distinct().ToArray();
                var words = review_text.Split().Select(x => x.Trim(punctuation).ToLower());
                foreach (var word in words)
                {
                    foreach (string feature in features.Keys.ToList())
                    {
                        if (feature.Equals(word)) features[feature]++;
                    }
                }
            }
            
        }
        static string getText (IWebDriver driver, int i)
        {
            return driver.FindElement(By.XPath("//*[@id='tn15content']/p[" + i + "]")).Text;
        }
    }
}

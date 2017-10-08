using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo reviews = new DirectoryInfo(@"C:\Users\Асем Зайткалиева\Downloads\aclImdb_v1\aclImdb\test\pos");
            FileInfo[] files = reviews.GetFiles();

            DirectoryInfo dictionary = new DirectoryInfo(@"C:\Users\Асем Зайткалиева\Desktop\fisrtCase");
            FileInfo[] dics = dictionary.GetFiles();

            Dictionary<string, Dictionary<string, int>> features = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> emotion = new Dictionary<string, int>();
            //Dictionary<string, int> negative = new Dictionary<string, int>();

            string[] feature_words = { }, words = { };
            foreach (var dic in dics)
            {
                switch (dic.Name)
                {
                    case "dictionary2.txt":
                        feature_words = new StreamReader(new FileStream
                            (dic.FullName, FileMode.Open, FileAccess.Read)).ReadToEnd().Split('_');
                        break;
                    case "emotion-words.txt":
                        words = new StreamReader(new FileStream
                            (dic.FullName, FileMode.Open, FileAccess.Read)).ReadToEnd().Split
                            (new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string word in words)
                        {
                            emotion.Add(word, 0);
                        }
                        break;
                }
            }

            foreach (string f in feature_words)
            {
                features.Add(f, emotion);
            }

            Stopwatch time = new Stopwatch();
            time.Start();
            foreach (var file in files)
            {
                FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                char[] sep = { '.', '!', '?' };
                string[] review = sr.ReadToEnd().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                foreach (string sentence in review)
                {
                    foreach (string feature in features.Keys.ToList())
                    {
                        if (sentence.Contains(feature))
                        {
                            foreach (string adj in features[feature].Keys.ToList())
                            {
                            }
                        }
                    }
                }
                sr.Close();
                fs.Close();


            }
            time.Stop();
            Console.WriteLine(time.Elapsed);

            /*Random rn = new Random();
            int ind = rn.Next(1, 100);
            FileStream fst = new FileStream(@"C:\Users\Асем Зайткалиева\Documents\file7.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter srt = new StreamWriter(fst);
            StreamReader srd = new StreamReader(fst);
            string all = srd.ReadToEnd();
            foreach (var feature in features)
            {
                if (feature.Value > 0 && !all.Contains(feature.Key)) srt.WriteLine(feature.Key);
            }
            srt.Close();
            srd.Close();
            fst.Close();
            Console.ReadKey();*/
        }
    }
}

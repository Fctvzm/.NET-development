using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview
{

    /// <summary>
    /// This class collects all Features
    /// </summary>
    public class MovieFeature
    {
        public string name;
        public static List<MovieFeature> features;
        public List<string> syns;
        public Dictionary<string, int> adjs;
        /// <summary>
        /// Constructor of MovieFeature
        /// </summary>
        /// <param name="name"> name of feature</param>
        /// <param name="syns"> synonyms of feature</param>
        /// <param name="adjs">adjectives for this feature</param>
        public MovieFeature(string name, List<string> syns, Dictionary<string, int> adjs)
        {
            this.name = name;
            this.syns = syns;
            this.adjs = adjs;
            if (MovieFeature.features == null)
            {
                features = new List<MovieFeature>();
            }
        }

        /// <summary>
        /// Static method which find MovieFeature in list features
        /// </summary>
        /// <param name="s"> name of feature</param>
        /// <returns></returns>
        public static MovieFeature getMF(string s)
        {
            foreach (MovieFeature MF in features)
            {
                if (MF.name.Equals(s)) return MF;

                foreach (string syn in MF.syns)
                {
                    if (syn.Equals(s)) return MF;
                }
            }
            return null;
        }

        /// <summary>
        /// This is a scale of output
        /// </summary>
        /// <returns>string with output</returns>
        public static string getSummary()
        {
            string text = "";
            text += "Majority of people think that " + features[0].name + " is " + getMax(features[0]) +
                " and " + features[1].name + " is " + getMax(features[1]) + ". " + "In addition, most of reviewers wrote that " +
                features[2].name + " is " + getMax(features[2]) + ". " + " Also, it is identfied that " + features[3].name + " is " +
                getMax(features[3]) + " and " + features[4].name + " is " + getMax(features[4]) + ". " + "In conclusion, the main feature of movie, " +
                features[5].name + ", is determined as " + getMax(features[5]) + ".";

            return text;
        }

        /// <summary>
        /// To find an adjective with maximum value of counter
        /// </summary>
        /// <param name="mf"></param>
        /// <returns>returns a maximum value of adjective</returns>
        public static string getMax(MovieFeature mf)
        {
            int max = int.MinValue;
            string s = "";
            foreach (var ads in mf.adjs)
            {
                if (ads.Value > max) { max = ads.Value; s = ads.Key; }
            }
            return s;
        }
    }
}
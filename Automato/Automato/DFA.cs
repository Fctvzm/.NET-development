using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automato
{
    //Zaitkaliyeva Assem 15BD02083
    class DFA
    {
        class Alphabet //each state have zero or one
        {
            public string state, zero, one;
            public Alphabet(string state, string zero, string one)
            {
                this.state = state;
                this.zero = zero;
                this.one = one;
            }
        }

        struct Group //uses when minimize dfa; dividing into eq. sets
        {
            public string state;
            public int set;

            public Group (string state, int set)
            {
                this.state = state;
                this.set = set;
            }
        }

        static List<Alphabet> initTable, outTable;
        static int NStates;
        static string [] finalStates; // array of final states
        static string last_state = ""; 
        static List<Group> dfaStates; //uses when minimize dfa

        static public void init (string input) // get data from input and put into initTable
        {
            initTable = new List<Alphabet>();
            string[] rows = input.Split(new string[] { Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            NStates = rows.Length - 1;
            for (int i = 0; i < NStates; i++) {
                string[] row = rows[i].Split(' ');
                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j].Contains(',')) {
                        string[] val = row[j].Split(',');
                        string newVal = "";
                        foreach (string v in val)
                        {
                            newVal += v + "_"; // state with "_" sign considered as one union state
                        }
                        row[j] = newVal.Remove(newVal.Length - 1);
                    }
                }
                initTable.Add(new Alphabet(row[0], row[1], row[2]));
            }
            finalStates = rows[NStates].Split(','); // in the end of input text must enter final states
            last_state = initTable[NStates - 1].state;
        }

        static public void converting ()
        {
            HashSet<string> mark = new HashSet<string>(); // uses to exclude same states
            outTable = new List<Alphabet>();
            mark.Add(initTable[0].state);
            outTable.Add(initTable[0]);
            Queue<string> q = new Queue<string>(); 
            if (mark.Add(outTable[0].zero)) q.Enqueue(outTable[0].zero);
            if (mark.Add(outTable[0].one)) q.Enqueue(outTable[0].one);
            while (q.Count > 0)
            {
                string state = q.Dequeue();
                Alphabet a = union(state);
                if (mark.Add(a.zero)) q.Enqueue(a.zero);
                if (mark.Add(a.one)) q.Enqueue(a.one);
                outTable.Add(a);
            }

        }

        static Alphabet union (string union_state) //union two or more states
        {
            string zero = "", one = "";
            string [] states = union_state.Split('_');
            foreach (string s in states)
            {
                Alphabet a = find(s);
                if (zero.Equals("") && !a.zero.Equals("-")) zero = a.zero + "_"; // first case for zero
                else if (!a.zero.Equals("-")) {
                    string[] temp = a.zero.Split('_');
                    foreach (string t in temp)
                        if (!zero.Contains(t)) zero += t + "_"; 
                }
                if (one.Equals("") && !a.one.Equals("-")) one = a.one + "_"; // first case for one
                else if (!a.one.Equals("-"))
                {
                    string[] temp = a.one.Split('_');
                    foreach (string t in temp)
                        if (!one.Contains(t)) one += t + "_";
                }
            }
            if (zero.Length > 0)
            {
                zero = zero.Remove(zero.Length - 1);
                if (zero.Length > 2) zero = sorting(zero);
            }
            else // if states goes nowhere, create a new state (trap) for zero
            {
                increment();
                zero = last_state;
            }
            if (one.Length > 0)
            {
                one = one.Remove(one.Length - 1);
                if (one.Length > 2) one = sorting(one);
            }
            else // if states goes nowhere, create a new state (trap) for one
            {
                increment();
                one = last_state;
            }
            return new Alphabet(union_state, zero, one);
        }

        static Alphabet find (string state) // find state in iniTable and return row
        {
            foreach (Alphabet a in initTable)
                if (a.state.Equals(state)) return a;
            return null;
        }

        static void increment () // to create a new state (trap)
        {
            int incre = (last_state[1] - '0');
            incre++;
            last_state = last_state[0] + incre.ToString();
            initTable.Add(new Alphabet(last_state, last_state, last_state));
        }

        static public string show() // show final output
        {
            string all = "state" + "\t" + "0" + "\t" + "1" + Environment.NewLine;
            foreach (Alphabet row in outTable) {
                all += row.state + "\t" + row.zero + "\t" + row.one + Environment.NewLine;
            }
            all += "Final states: ";
            foreach(Alphabet a in outTable)
            {
                foreach (string s in finalStates)
                {
                    if (a.state.Contains(s)) all += a.state + ", ";
                }
            }
            return all;
        }

        static string sorting (string state) //sort union states in asc order for comparison of uniques
        {
            string [] temp = state.Split('_');
            int[] ind = new int[temp.Length];
            for (int i = 0; i < temp.Length; i++)
                ind[i] = temp[i][1] - '0';

            Array.Sort(ind);
            string s = "";
            for (int i = 0; i < temp.Length; i++)
                s += temp[i][0] + ind[i].ToString() + "_";
            s = s.Remove(s.Length - 1);
            return s;
        }

        static int findInSets (string s) //find in which set state is
        {
            foreach (Group g in dfaStates)
                if (g.state.Equals(s)) return g.set;
            return -1;
        }

        static public void minimize() 
        {
            dfaStates = new List<Group>();
            int set = 1;
            foreach (Alphabet a in initTable) // divide final sets fron other states
            {
                foreach (string s in finalStates)
                {
                    if (a.state.Contains(s)) dfaStates.Add(new Group(a.state, set));
                    else dfaStates.Add(new Group(a.state, set + 1));
                }
            }
            set++;
            
            bool change = true;
            while (change == true) // do until nothing change, prev and last equ. sets are similar
            {
                change = false;
                for (int i = 0; i < dfaStates.Count - 1; i++)
                {
                    for (int j = i + 1; j < dfaStates.Count; j++)
                    {
                        Alphabet a = find(dfaStates[i].state);
                        Alphabet b = find(dfaStates[j].state);
                        if (findInSets(a.zero) == findInSets(b.zero) && findInSets(a.one) == findInSets(b.one) && 
                            dfaStates[i].set != 1 && dfaStates[j].set != 1) //if it is not a final state and are in same sets
                        {
                            dfaStates[j] = new Group(dfaStates[j].state, dfaStates[i].set);
                        }
                        else if (dfaStates[i].set == dfaStates[j].set) //if not, create a new set for that element
                        {
                            dfaStates[j] = new Group(dfaStates[j].state, ++set);
                            change = true;
                        }
                    }
                }
            }
            outTable = new List<Alphabet>();
            List<string> allMin = new List<string>();
            for (int i = 1; i <= set; i++) //combine all states in the same eq. sets
            {
                string state = "";
                foreach(Group g in dfaStates)
                    if (g.set == i) state += g.state + "_";
                if (state.Length > 0)
                {
                    state = state.Remove(state.Length - 1);
                    allMin.Add(state);
                }
            }
            foreach (string s in allMin) //find corresponding zero and one for new states
            {
                Alphabet a;
                if (s.Length > 2) a = union(s); 
                else a = find(s);
                foreach (string val in allMin)
                {
                    if (val.Contains(a.zero)) a.zero = val; //corres. zero in new states
                    if (val.Contains(a.one)) a.one = val; // corres. one in new states
                }
                outTable.Add(a);
            }
            
        }
    }
}

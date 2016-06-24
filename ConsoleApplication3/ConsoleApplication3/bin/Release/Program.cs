using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApplication3
{
    
    class wordentryfuction
    {
        

        public void outputmatch(int num, Dictionary<string,int>[] pList, int [] wordsum)
        {
            Dictionary<string, double> Tobesort = new Dictionary<string, double>();
            foreach (var dic in pList[num - 1])
            {
                int e = 0;
                if (e < 20 && e < pList[num - 1].Count())              //only find match for the top 20 words from given user
                {
                    for (int m = 0; m < 10; m++)
                    {
                        if (m != num - 1)
                        {
                            double ratioadd;
                            String name = "U" + (m + 1);
                            if (pList[m].ContainsKey(dic.Key) == true)
                            {
                                ratioadd = Math.Pow((pList[m][dic.Key] * 1000 / wordsum[m] - dic.Value * 1000 / wordsum[num - 1]), 2);  //calculate the proportion of the words of given user in other users 
                            }                                                                                                          // sqrt ratio difference as distance 
                            else ratioadd = Math.Pow((dic.Value * 1000 / wordsum[num - 1]), 2);                               
                            //Console.WriteLine("float:"+ ratioadd.ToString("f8"));
                            if (Tobesort.ContainsKey(name) == false)
                                Tobesort.Add(name, ratioadd);
                            else
                            {

                                Tobesort[name] += ratioadd;
                            }

                        }
                    }
                }


            }
            Tobesort = this.SortDictionary_Asc(Tobesort);
            foreach (var Dic in Tobesort)
            {
                Console.WriteLine("Similarity Sort Desc : {0}, Value : {1} ", Dic.Key, Math.Sqrt(Dic.Value).ToString("f7"));


            }





        }
        public Dictionary<string, int> SortDictionary_Desc(Dictionary<string, int> dic)
        {
            List<KeyValuePair<string, int>> myList = new List<KeyValuePair<string, int>>(dic);
            myList.Sort(delegate(KeyValuePair<string, int> s1, KeyValuePair<string, int> s2)
            {
                ;
                int k = s2.Value - s1.Value;
                if (k > 0)
                    return 1;
                else if (k == 0)
                    return s2.Key.CompareTo(s1.Key);
                else return -1;

            });
            dic.Clear();
            foreach (KeyValuePair<string, int> pair in myList)
            {
                dic.Add(pair.Key, pair.Value);
            }
            return dic;
        }

        public Dictionary<string, double> SortDictionary_Asc(Dictionary<string, double> dic)
        {
            List<KeyValuePair<string, double>> myList = new List<KeyValuePair<string, double>>(dic);
            myList.Sort(delegate(KeyValuePair<string, double> s1, KeyValuePair<string, double> s2)
            {
              
                double k = s2.Value - s1.Value;
                if (k > 0)
                    return -1;
                else if (k == 0)
                    return 0;
                else return 1;

            });
            dic.Clear();
            foreach (KeyValuePair<string, double> pair in myList)
            {
                dic.Add(pair.Key, pair.Value);
            }
            return dic;
        }
        public  bool Isatoz(string input)
        {
            string pattern = @"^[a-z]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);

        }

        public bool Isexpression(string input)
        {
            string pattern = @"^[a-fx]+$";
            
            Regex regex = new Regex(pattern);
            if (input.Length == 3)
                return regex.IsMatch(input);
            else return false;
        }  
    }
    class Program
    {
       
      
        static void Main(string[] args)
        {
            char[] separator = { ' ',',' };
            wordentryfuction A = new wordentryfuction();
            List<String> stopwords = new List<String>();
            FileStream bFile = new FileStream("stopwords.txt", FileMode.Open);
            StreamReader st1 = new StreamReader(bFile);            //readin stopwords
            string strLine1 = st1.ReadLine();
            while (strLine1 != null)
            {


                string[] splitStrings;
                splitStrings = strLine1.Split(separator);
                int k=0;
                while(k<splitStrings.Length)
                {
                    if (splitStrings[k]!=null)
                    {
                        stopwords.Add(splitStrings[k]);
                        //Console.WriteLine(splitStrings[k]);
                    }
                    k++;
                }
                strLine1 = st1.ReadLine();
            }
            st1.Close();

            Dictionary<string, int>[] pList = new Dictionary<string, int>[10];
            int [] wordsum = new int[10];
            for(int n=1;n<=10;n++)
            {
                pList[n-1]=new Dictionary<string, int>();
      
                string path;
                path = "U" + n + ".txt";
               
            
                FileStream aFile = new FileStream(path, FileMode.Open);                  //readin user txt file
                StreamReader sr = new StreamReader(aFile);
                string strLine = sr.ReadLine();
                while (strLine != null)
                {

                  
                    Regex reg = new Regex("(http|https|ftp)://[^\\s\\n]+");
                    strLine = reg.Replace(strLine, " ");                                           //delete urls
                                                                 
                    strLine = strLine.ToLower();

                    reg = new Regex(@"i'm");
                    strLine = reg.Replace(strLine, " ");

                    
                    reg = new Regex("(can't|n't|'s|'ve|'ll)");               //delete I'am Can't n't 've 's 'll
                    strLine = reg.Replace(strLine, " ");

                    reg = new Regex(@"[\s]*[A-Za-z0-9]{1}[.]");
                    strLine = reg.Replace(strLine, " ");                   //delete surname like H.

                    reg = new Regex(@"[\(\)]+");
                    strLine = reg.Replace(strLine, "");                  //merge brackets and character example:(M)ove

                    reg = new Regex("[^\\sA-Z'\"a-z0-9][A-Za-z0-9]+");            //delet expressions an other labels like /xf0 #daddad
                    strLine = reg.Replace(strLine, " ");


                    reg = new Regex("[^A-Za-z0-9\\s]+");
                    strLine = reg.Replace(strLine, " ");                        //remove all none A-Za-Z0-9 charater

                    //Console.WriteLine(strLine);
                    string[] splitStrings;

                    splitStrings = strLine.Split(separator);           //split words
                    int i = 0;
                   
                    while (i < splitStrings.Length)
                    {
                        splitStrings[i] = splitStrings[i].ToLower();
                        //Console.WriteLine(splitStrings[i]);
                        if ( A.Isatoz(splitStrings[i]) && !stopwords.Contains(splitStrings[i]))             //merge repeated character like angryyyyyy fell feel
                        {
                            int j = 0;
                            while (j<splitStrings[i].Length-1)
                            {
                                if (splitStrings[i].Substring(j, 1) == splitStrings[i].Substring(j + 1, 1))
                                {
                                    splitStrings[i] = splitStrings[i].Remove(j + 1, 1);
                                }
                                else j++;
                            }  

                            if (pList[n - 1].ContainsKey(splitStrings[i]) == false)                     //add to the dictionary
                                pList[n - 1].Add(splitStrings[i], 1);
                            else
                            {
                                pList[n - 1][splitStrings[i]]++;
                            }
                        }
                        i++;
                    }

                    strLine = sr.ReadLine();
                }

                pList[n - 1] = A.SortDictionary_Desc(pList[n - 1]);
                int e = 0;
                foreach (var dic in pList[n - 1])
                {
                    if (e <10)
                    Console.WriteLine("Output Key : {0}, Value : {1} ", dic.Key, dic.Value);
                    e++;
                    if (e >= 10)
                        break;
                    
                }
                Console.WriteLine("Total number of words in dictionary U" + n + ": " + pList[n - 1].Count()+"\n");
                wordsum[n-1]=pList[n-1].Count();                 //store total number of words for each user
                sr.Close();
            }

            Console.WriteLine("which one of the ten user to be compared?  U1 to U10 \n input q to quit");
            string username;
            username = Console.ReadLine();
            while(username.Length>0)
            {
                int num = int.Parse(username.Substring(1));
                A.outputmatch(num, pList, wordsum);                        //rank the similarities with Euclidean Distance
                 Console.WriteLine("which one of the ten users to be compared?  U1 to U10 \n input q to quit");
                 username = Console.ReadLine();
                 if (username == "q")
                     break;

            }
            

        }


    }
}

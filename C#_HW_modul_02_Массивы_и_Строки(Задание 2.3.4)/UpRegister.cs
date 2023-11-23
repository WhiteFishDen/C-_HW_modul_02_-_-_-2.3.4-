using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__HW_modul_02_Массивы_и_Строки_Задание_2._3._4_
{
    internal class UpRegister
    {
        public string StrFromUser { get; set; }
        public void ToUp()
        {
            string[] proffer = StrFromUser.Split('.');
            for (int i = 0; i < proffer.Length; i++)
            {
                if (proffer[i] == "")
                    break;
                if (proffer[i][0] == ' ')
                    proffer[i] = proffer[i].TrimStart();
                string tmp = proffer[i][0].ToString().ToUpper();
                proffer[i] = proffer[i].TrimStart(proffer[i][0]).Insert(0, tmp);
                proffer[i] += ". ";
            }

            foreach (var item in proffer)
            {
                Console.Write(item);
            }
        }
    }
    internal class Censor
    {
        string _poem = " To be, or not to be that is the question, \n " +
                       "Whether 'tis nobler in the mind to suffer \n "+
                       "The slings and arrows of outrageous fortune, \n " +
                       "Or to take arms against a sea of troubles, \n " +
                       "And by opposing end them? To die: to sleep; \n " +
                       "No more; and by a sleep to say we end \n " +
                       "The heart-ache and the thousand natural shocks \n " +
                       "That flesh is heir to, 'tis a consummation \n " +
                       "Devoutly to be wish'd. To die, to sleep.";
        char[] _simbol = { '.', ',', ':', '?', ';' };
        public int Amount { get; set; } = 0;
        public string InadmissWord { get; set; } = "";
        private KeyValuePair<char,bool> ContainsSimbol(string str)
        {
            for (int i = 0; i < _simbol.Length; i++)
            {
                if (str.Contains(_simbol[i]))
                    return KeyValuePair.Create(_simbol[i],true);
            }
            return KeyValuePair.Create(' ',false);
        }

        public override string ToString()
        {
            return _poem;
        }
        public void inadmissible()
        {
            InadmissWord = InadmissWord.ToLower();
            _poem = _poem.ToLower();
            string[] listWords = _poem.Split(' ');
            for (int i = 0; i < listWords.Length; i++)
            {
                char punctation = ' ';
                KeyValuePair<char, bool> check = ContainsSimbol(listWords[i]);
                if (check.Value)
                {
                    punctation = check.Key;
                    int index = listWords[i].IndexOf(punctation);
                    listWords[i] = listWords[i].Remove(index);
                }

                int result = string.Compare(listWords[i], InadmissWord);
                if (result == 0)
                {
                    string star = "";
                    for (int j = 0; j < listWords[i].Length; j++)
                        star += "*";
                    
                    star += punctation.ToString();
                    if(punctation!=' ')
                    star += ' ';
                    listWords[i] = listWords[i].Replace(listWords[i], star);
                    Amount++;
                }
                else
                {
                    if(punctation!=' ')
                    {
                        listWords[i] += punctation.ToString();
                        listWords[i] += ' ';
                    }
                    else
                        listWords[i] += ' ';
                }
            }
            UpRegister(listWords);
            foreach (var item in listWords)
                Console.Write(item);
            Console.WriteLine();
        }
         private void UpRegister(string[] listWords)
         {
            for (int i = 0; i < listWords.Length; i++)
            {
                int stepNext = i + 1;
                char punctation = ContainsSimbol(listWords[i]).Key;
                if (i == listWords.Length - 1 || listWords[stepNext].Contains('*'))
                    continue;
                if (listWords[i].Contains('\n') || i == 0 || punctation == '.' || punctation == '?')
                {
                    string tmp = listWords[stepNext][0].ToString().ToUpper();
                    listWords[stepNext] = listWords[stepNext].TrimStart(listWords[stepNext][0]).Insert(0,tmp);
                }
            }
        }
        public void Staticstic()
        {
            Console.WriteLine($"\tСлово: <{InadmissWord}> заменено {Amount} раз");
        }
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__HW_modul_02_Массивы_и_Строки_Задание_2._3._4_
{
    internal class EncryptCezar
    {
        char[] _letters = { 'А', 'Б', 'В', 'Г', 'Д','Е',
            'Ё', 'Ж','З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О',
            'П', 'Р', 'С', 'Т', 'У','Ф','Х','Ц','Ч','Ш','Щ',
            'Ъ','Ы','Ь','Э','Ю','Я' };
        string str;
        public EncryptCezar(string str)
        {
            this.str = str;
        }
        public string Encryptor()
        {
            string code="";
            str = str.ToUpper();
            foreach (var item in str)
            {

                int index = Array.IndexOf(_letters, item);
                    switch (item)
                    {
                        case ' ': code += ' '; break;
                        case ',': code += ','; break;
                        case '.': code += '.'; break;
                        case '!': code += '!'; break;
                        case '?': code += '?'; break;

                        default:

                            if (index == 32)
                                code += _letters[2];
                            else if (index == 31)
                                code += _letters[1];
                            else if (index == 30)
                                code += _letters[0];
                            else
                                code += _letters[index + 3];
                            break;

                    }
            }
            Console.WriteLine(code);
            return code;
        }

        public void Decryptor(string str)
        {
            string code="";
            str = str.ToUpper();
            foreach (var item in str)
            {

                int index = Array.IndexOf(_letters, item);
                switch (item)
                {
                    case ' ': code += ' '; break;
                    case ',': code += ','; break;
                    case '.': code += '.'; break;
                    case '!': code += '!'; break;
                    case '?': code += '?'; break;

                    default:

                        if (index == 2)
                            code += _letters[32];
                        else if (index == 1)
                            code += _letters[31];
                        else if (index == 0)
                            code += _letters[30];
                        else
                            code += _letters[index - 3]; 
                        break;

                }
            }
            Console.WriteLine(code);
        }
    }
}

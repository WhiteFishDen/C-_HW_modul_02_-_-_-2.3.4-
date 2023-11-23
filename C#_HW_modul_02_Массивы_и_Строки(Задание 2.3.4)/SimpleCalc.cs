using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__HW_modul_02_Массивы_и_Строки_Задание_2._3._4_
{
        public delegate double CalcDelegate(double x, double y);
        public class Calculator
        {
            public double Add(double x, double y)
            {
                return x + y;
            }
            public static double Sub(double x, double y)
            {
                return x - y;
            }
        }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_03.Task_01
{
    delegate double CalcDelegate(double left, double right, char sign);
    class CalcProgram
    {
        public static double Calc(double left, double right, char sign)
        {
            switch (sign)
            {
                case '+':
                    return left + right;
                case '-':
                    return left - right;
                case '*':
                    return left * right;
                case '/':
                    if (right == 0)
                    {
                        return 0;
                    }
                    return left / right;
                default:
                    throw new Exception("InvalidOperationSignException");
            }
        }
    }
}

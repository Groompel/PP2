using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public delegate void MyDelegate(string text);

    enum CalcState
        {
            ZERO,
            AC_DGTS,
            AC_DGTS_WDCML,
            COMPUTE,
            RESULT
        }

    class Calc
    { 
        MyDelegate displayMsg;
        private CalcState calcState = CalcState.ZERO;
        private string tempNumber;
        private string resNumber;
        private string operation;


        int FindPrimes(int n1, int n2)
        {
            int sum = 0;
            for(int i = n2; i <= n1; i++)
            {
                bool isPrime = true;
                for(int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if(i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    
                }

                if (isPrime)
                    sum += i;


            }
            return sum;

            
        }


        public Calc(MyDelegate displayMsg)
        {
            this.displayMsg = displayMsg;
            tempNumber = "";
            resNumber = "";
            operation = "";
        }

        public void Process(string text)
        {
            if(text == "C")
            {
                tempNumber = "";
                resNumber = "";
                operation = "";
                calcState = CalcState.ZERO;
                displayMsg("0");
            }
            switch (calcState)
            {
                case CalcState.ZERO:
                    Zero(false, text);
                    break;
                case CalcState.AC_DGTS:
                    AccumulateDigits(false, text);
                    break;
                case CalcState.AC_DGTS_WDCML:
                    AccumulateDigitsWithDecimal(false, text);
                    break;
                case CalcState.COMPUTE:
                    Compute(false, text);
                    break;
                case CalcState.RESULT:
                    Result(false, text);
                    break;
            }
        }

       

        private void Zero(bool isInput, string msg)
        {
            if (isInput)
            {
                calcState = CalcState.ZERO;
                operation = "";
                tempNumber = "";
                displayMsg("0");
                
            }
            else
            {
                if (Rules.IsNonZeroDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
                if (Rules.IsSeparator(msg))
                {
                    tempNumber = "0";
                    AccumulateDigitsWithDecimal(true, msg);
                }
            }
        }

        private void AccumulateDigits(bool isInput, string msg)
        {
            if (isInput)
            {
                calcState = CalcState.AC_DGTS;
               
                tempNumber += msg;
                displayMsg(tempNumber);
            }
            else
            {
                if (Rules.IsPrimeSum(msg))
                {
                    Compute(true, msg);
                }
                if (Rules.IsChangeSign(msg))
                {
                    
                        if (double.Parse(tempNumber) > 0)
                        {
                            tempNumber = "-" + tempNumber;
                        }
                        else
                        {
                            tempNumber = tempNumber.Substring(1, tempNumber.Length - 2);
                        }
                    
                    displayMsg(tempNumber);

                    AccumulateDigits(false, " ");
                }

                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsOperator(msg))
                {
                    Compute(true, msg);
                }
                else if (Rules.IsEqualSign(msg))
                {
                    Result(true, msg);
                }
                if (Rules.IsSeparator(msg))
                {
                    AccumulateDigitsWithDecimal(true, msg);
                }
                if (Rules.IsBackSpace(msg))
                {
                    if (tempNumber.Length != 1)
                    {
                        tempNumber = tempNumber.Substring(0, tempNumber.Length - 1);
                        displayMsg(tempNumber);
                        AccumulateDigits(false, " ");
                    }

                    else
                    {
                        tempNumber = tempNumber.Substring(0, tempNumber.Length - 1);
                        displayMsg("0");
                        AccumulateDigits(false, " ");

                    }

                }
            }
        }

        private void AccumulateDigitsWithDecimal(bool isInput, string msg)
        {
            if (isInput)
            {
                calcState = CalcState.AC_DGTS_WDCML;
                if (!tempNumber.Contains(","))
                {
                    tempNumber += ",";
                }
                displayMsg(tempNumber);
            }
            else
            {
                if (Rules.IsChangeSign(msg))
                {
                    if (double.Parse(tempNumber) > 0)
                    {
                        tempNumber = "-" + tempNumber;
                    }
                    else
                    {
                        tempNumber = tempNumber.Substring(1, tempNumber.Length - 2);
                    }
                    displayMsg(tempNumber);
                    AccumulateDigits(false, " ");

                }

                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsOperator(msg))
                {
                    Compute(true, msg);
                }
                else if (Rules.IsEqualSign(msg))
                {
                    Result(true, msg);
                }
                if (Rules.IsBackSpace(msg))
                {
                    tempNumber = tempNumber.Substring(0, tempNumber.Length - 2);
                    AccumulateDigits(false, msg);
                }
            }
        }

        private void Compute(bool isInput, string msg)
        {
            if (isInput)
            {
                calcState = CalcState.COMPUTE;

                if (operation.Length > 0)
                {
                    Calculate();
                    displayMsg(resNumber);
                }
                else
                {
                    resNumber = tempNumber;
                }

                tempNumber = "";
                operation = msg;

            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }

            }
        }

        private void Result(bool isInput, string msg)
        {
            if (isInput)
            {
                calcState = CalcState.RESULT;
                Calculate();
                displayMsg(resNumber);
            }
            else
            {
                if (Rules.IsZero(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsNonZeroDigit(msg))
                {
                    tempNumber = "";
                    operation = "";
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsOperator(msg))
                {
                    operation = "";
                    tempNumber = resNumber;
                    Compute(true, msg);
                }
                else if (Rules.IsEqualSign(msg))
                {
                    Calculate();
                    displayMsg(resNumber);
                }
            }
        }
    
        private void Calculate()
        {
            
            double t = double.Parse(tempNumber);
            double r = double.Parse(resNumber);
            if (tempNumber[0] == '-')
                t *= -1;
            if (resNumber[0] == '-')
                r *= -1;


            if(operation == "Prime Sum")
            {
                resNumber = FindPrimes((int)t, (int)r).ToString();
            }

            if (operation == "+")
            {
                resNumber = (t + r).ToString();
            }
            else if (operation == "-")
            {
                resNumber = (r - t).ToString();
            }
            else if (operation == "x")
            {
                resNumber = (r * t).ToString();
            }
            else if (operation == "/")
            {
                resNumber = (r / t).ToString();
            }
        }
    }
}

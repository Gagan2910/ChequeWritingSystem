using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ChequeWritingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string isNegative = "";
            try
            {
                Console.WriteLine("Enter a number to convert to currency");
                string number = Console.ReadLine();
                number = Convert.ToDouble(number).ToString();

                if (number.Contains("-"))
                {
                    isNegative = "Minus ";
                    number = number.Substring(1);
                }
                if (number == "0")
                {
                    Console.WriteLine("The number in currency format is \n Zero Only");
                }
                else
                {
                    Console.WriteLine("The number in currency format is \n {0}",isNegative + ConvertToWords(number));
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private static string Ones(string Number)
        {
            int _number = Convert.ToInt32(Number);
            string name = "";
            switch (_number)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private static string Tens(string Number)
        {
            int _number = Convert.ToInt32(Number);
            string name = null;
            switch (_number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_number > 0)
                    {
                        name = Tens(Number.Substring(0, 1) + "0") + " " + Ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static string ConvertWholeNumber(string Number)
        {
            string word = "";
            try
            {  
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(Number));
                if (dblAmt > 0)
                {    
                    int numDigits = Number.Length;
                    int pos = 0;   
                    string place = "";//hundreds,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' place    

                            word = Ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' place    
                            word = Tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' place   
                            pos = (numDigits % 3) + 1;
                            place = " Hundred, ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand, ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million, ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion, ";
                            break; 
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        
                    }
                   
                }
            }
            catch { }
            return word;
        }
        private static string ConvertToWords(string numb)
        {
            string val = "", wholeNo = numb, decimalNo = "", pointStr = "";
            string andStr=" dollars";
            string endStr = "";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    decimalNo = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(decimalNo) > 0)
                    {
                        andStr = " dollars and ";
                        endStr = " cents";//Cents    
                        pointStr = ConvertDecimals(decimalNo);
                    }
                }
                val = ConvertWholeNumber(wholeNo)+andStr+pointStr+endStr;
            }
            catch { }
            return val;
        }
        private static string ConvertDecimals(string Number)
        {
            string cd = "";
            if (Number.Length==1)
            {
                cd = Ones(Number);
            }
            else if (Number.Length == 2)
            {
                //Check for ten's place decimal in a number.
                cd = Tens(Number);
            }

            return cd;
        }
    }
}

using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Calculator
    {
        /// <summary>
        /// 对一个字符串算是进行计算，支持加减乘除与括号，运算范围不超过double
        /// </summary>
        private static string calulateString = null;
        private static string calculateResult = null;
        private static Dictionary<string, int> _operatorLevel;
        private static Stack<string> CalculateOperationStack = new Stack<string>();
        private static Stack<string> CalculateNumberStack = new Stack<string>();


        public static string CalulateString { get => calulateString; set => calulateString = value; }
        public static string CalulateResult { get => calculateResult; set => calculateResult = value; }

        /// <summary>
        /// 运算符字典，方便确定运算顺序
        /// </summary>
        private static Dictionary<string, int> OperatorLevel
        {
            get
            {
                if(_operatorLevel == null)
                {
                    _operatorLevel = new Dictionary<string, int>
                    {
                        { "+", 0 },
                        { "-", 0 },
                        { "(", 1 },
                        { "*", 1 },
                        { "/", 1 },
                        { ")", 0 }
                    };
                }
                return _operatorLevel;
            }
        }

        /// <summary>
        /// 计算结果
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <returns>计算结果</returns>
        public static string Calculate(string source = null)
        {
            CalculateOperationStack.Clear();
            CalculateNumberStack.Clear();
            if (source != null)
            {
                CalulateString = source;
            }
            if(CalulateString == null)
            {
                CalulateResult = null;
            }
            else
            {
                string result = InsertBlank(CalulateString);
                result = ConvertToRPN(result);
                result = GetResult(result);
                CalulateResult = result;
            }
            return CalulateResult;
        }

        /// <summary>
        /// 分割算式,将运算符与数字之间插入空格
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <returns>处理后的字符串</returns>
        private static string InsertBlank(string source)
        {
            StringBuilder result = new StringBuilder();
            var list = source.ToCharArray();
            foreach (var temp in list)
            {
                if (OperatorLevel.ContainsKey(temp.ToString()))
                {
                    result.Append(" ");
                    result.Append(temp.ToString());
                    result.Append(" ");
                }
                else
                {
                    result.Append(temp);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// 将算式字符串转换为逆波兰表达式
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <returns>逆波兰表达式</returns>
        private static string ConvertToRPN(string source)
        {
            StringBuilder result = new StringBuilder();
            
            string[] list = source.Split(' ');
            for(int i = 0; i < list.Length; i++)
            {
                string current = list[i];
                // 正则表达式验证
                if(Regex.IsMatch(current, @"^[-]?\d+[.]?\d*$"))
                {
                    result.Append(current + " ");
                }
                else if(OperatorLevel.ContainsKey(current))
                {
                    if(CalculateOperationStack.Count > 0)
                    {
                        var prev = CalculateOperationStack.Peek();
                        if(prev == "(")
                        {
                            CalculateOperationStack.Push(current);
                            continue;
                        }
                        if(current == "(")
                        {
                            CalculateOperationStack.Push(current);
                            continue;
                        }
                        if(current == ")")
                        {
                            while (CalculateOperationStack.Count > 0 && CalculateOperationStack.Peek() != "(")
                            {
                                result.Append(CalculateOperationStack.Pop() + " ");
                            }
                            // 弹出'('
                            CalculateOperationStack.Pop();
                            continue;
                        }
                        if(OperatorLevel[current] < OperatorLevel[prev])
                        {
                            while (CalculateOperationStack.Count > 0)
                            {
                                var top = CalculateOperationStack.Pop();
                                if (top != "(" && top != ")")
                                {
                                    result.Append(top + " ");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            CalculateOperationStack.Push(current);
                        }
                        else
                        {
                            CalculateOperationStack.Push(current);
                        }
                    }
                    else
                    {
                        CalculateOperationStack.Push(current);
                    }
                }
            }
            if (CalculateOperationStack.Count > 0)
            {
                while (CalculateOperationStack.Count > 0)
                {
                    var top = CalculateOperationStack.Pop();
                    if (top != "(" && top != ")")
                    {
                        result.Append(top + " ");
                    }
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// 计算逆波兰表达式
        /// </summary>
        /// <param name="source">逆波兰表达式</param>
        /// <returns>计算结果</returns>
        private static string GetResult(string source)
        {
            var list = source.Split(' ');
            for(int i = 0; i < list.Length; i++)
            {
                string current = list[i];
                if(Regex.IsMatch(current, @"^[-]?\d+[.]?\d*$"))
                {
                    CalculateNumberStack.Push(current);
                }
                else if(OperatorLevel.ContainsKey(current))
                {
                    double right = double.Parse(CalculateNumberStack.Pop());
                    double left = double.Parse(CalculateNumberStack.Pop());
                    // 计算数值
                    CalculateNumberStack.Push(GetValue(left, right, current[0]).ToString());
                }
            }
            return CalculateNumberStack.Pop();
        }

        /// <summary>
        /// 计算数值
        /// </summary>
        /// <param name="left">计算数字</param>
        /// <param name="right">计算数字</param>
        /// <param name="_operator">操作符,支持加减乘除</param>
        /// <returns>计算数值</returns>
        private static double GetValue(double left, double right, char _operator)
        {
            switch(_operator)
            {
                case '+':
                    return left + right;
                case '-':
                    return left - right;
                case '*':
                    return left * right;
                case '/':
                    return left / right;
            }
            return 0.0 / 0;
        }
    }
}

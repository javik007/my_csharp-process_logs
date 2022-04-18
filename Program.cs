using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace AmazonTest1
{
    class Result
    {

        /*
        * Complete the 'processLogs' function below.
        *
        * The function is expected to return a STRING_ARRAY.
        * The function accepts following parameters:
        *  1. STRING_ARRAY logs
        *  2. INTEGER threshold
        */

        public static List<string> processLogs(List<string> logs, int threshold)
        {
            List<string> result = new List<string>();
            List<int> priceIndex = new List<int>();
            string[] logArray = logs.ToArray();
            for (int i = 2; i < logArray.Length -1; i+=3)
            {
                priceIndex.Add(i);
            }
            
            for (int i = 0; i < logArray.Length -1; i++)
            {
                if (!priceIndex.Contains(i))
                {
                    result.Add(logArray[i]);
                }
            }

            result = result.Where(x => x.Count() > threshold).ToList();
           
            return result;
        }

}
    class Program
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int logsCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> logs = new List<string>();

            for (int i = 0; i < logsCount; i++)
            {
                string logsItem = Console.ReadLine();
                logs.Add(logsItem);
            }

            int threshold = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> result = Result.processLogs(logs, threshold);

            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}

// 88 99 200, 88 99 300, 99 32 100, 12 12 15
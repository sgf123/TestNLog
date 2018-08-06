﻿using System;


namespace TestNLog
{
    class Program
    {
     
        static void Main(string[] args)
        {
            try
            {
                LogHelper.Default.Info("Nlog,Info");
                LogHelper.Default.Debug("Nlog,Debug");
                var i = 0;
                var r = 1 / i;
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("测试Error写入", ex);
                new LogHelper("LnProcessDBLog").Log("测试Error写入", "{name:i,value:1}", ex);
            }
            Console.ReadKey();
        }
    }
}

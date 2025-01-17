﻿using System;
using AdmPwd.PDSUtils;
using System.ServiceModel;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(string.Format("Getting the password for computer {0}", args[0]));
                AdmPwd.Types.PasswordInfo pwdData = PdsWrapper.GetPassword(forestName: string.Empty, ComputerName: args[0], IncludePasswordHistory: false);
                Console.WriteLine(string.Format("Password: {0}", pwdData.Password));
                Console.WriteLine(string.Format("Expires: {0}", pwdData.ExpirationTimestamp.ToString()));

                Console.Write("Resetting password ... ");

                PdsWrapper.ResetPassword(forestName: string.Empty, computerName: args[0], whenEffective: DateTime.Now);
                Console.WriteLine("done");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

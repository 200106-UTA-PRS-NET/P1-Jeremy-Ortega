﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PizzaBox.Storing.Logic.Login
{
    class FirstNameCheck
    {
        public static string NewFirstNameChecker()
        {
            string namePattern = RegexAndLoginExpressions.nameRegex();
            // phone pattern complete
            Match rxFname = Regex.Match("", namePattern);
            string fname = "";
            while (!rxFname.Success)
            {
                // First Name
                Console.Clear();
                Console.WriteLine("\n ---- first name ----");
                RegexAndLoginExpressions.quitPrompt();
                fname = Console.ReadLine();
                if (fname.Equals("quit"))
                {
                    return "quit";
                }
                rxFname = Regex.Match(fname, namePattern);
            }
            return fname;
        }
    }
}

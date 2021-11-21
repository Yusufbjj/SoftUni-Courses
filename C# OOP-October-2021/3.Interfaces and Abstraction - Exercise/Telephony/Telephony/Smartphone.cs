using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Smartphone : ICaller, IBrowser
{
    public string Browse(string url)
    {
        if (url.Any(Char.IsDigit))
        {
            return "Invalid URL!";
        }

        return $"Browsing: {url}!";
    }

    public string Call(string number)
    {
        if (!number.All(Char.IsDigit))
        {
            return "Invalid number!";
        }

        if (number.Length == 7)
        {
            return $"Dialing... {number}";
        }
        return $"Calling... {number}";
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class Expressive : IExpressable
{
    private readonly string[] wordmap =
    {
        "Zero ",
        "One ",
        "Two ",
        "Three ",
        "Four ",
        "Five ",
        "Six ",
        "Seven ",
        "Eight ",
        "Nine ",
        "Ten ",
        "Eleven ",
        "Twelve ",
        "Thirteen ",
        "Fourteen ",
        "Fifteen ",
        "Sixteen ",
        "Seventeen ",
        "Eighteen ",
        "Nineteen ",
        "Twenty ",
        "Thirty ",
        "Forty ",
        "Fifty ",
        "Sixty ",
        "Seventy ",
        "Eighty ",
        "Ninty "
    };

    private readonly string[] suffixes =
    {
        "",
        "Thousand ",
        "Million ",
        "Billion ",
        "Trillion ",
    };

    public Expressive()
    {

    }
    private string GetNumber(int number, string suff)
    {
        return wordmap[number] + suff;
    }

    private string GetNumber10(int number, string suff)
    {
        if (number == 1)
        {
            return wordmap[10] + suff;
        }
        return wordmap[number + 19] + suff;
    }
    private List<int> SplitNumber(int number)
    {
        List<int> l = new();
        while (number > 0)
        {
            l.Add(number % 1000);
            number /= 1000;
        }
        return l;
    }
    public string Express(int number)
    {
        if (number < 21)
        {
            return GetNumber(number, "");
        }
        List<int> l = SplitNumber(number);
        var hundred = "Hundred ";
        var strings = new List<string>();
        

        foreach (var (num, suff) in l.Zip(suffixes))
        {
            string str = "";
            if (num == 0)
            {
                continue;
            }
            if (num > 99)
            {
                str += GetNumber(num / 100, hundred);
            }
            int temp = num % 100;
            if (temp == 0)
            {
                str += suff;
                strings.Add(str);
                continue;
            }
            if (temp < 21)
            {
                str += GetNumber(temp, suff);
            }
            else
            { 
                str += GetNumber10(temp / 10, "") + GetNumber(temp % 10, suff);
            }
            strings.Add(str);
        }
        strings.Reverse();
        return string.Join("", strings);
    }
}
using System;
using System.Text;

public class Solution
{
    public string solution(string my_string, int n)
    {
        string answer = "";
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < my_string.Length; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sb.Append(my_string[i]);
            }
        }
        answer = sb.ToString();
        return answer;
    }
}
using System;

class LongestCommonSubsequence
{
    static void Main()
    {
        char[] S1 = "ACADB".ToCharArray();
        char[] S2 = "CBDA".ToCharArray();
        int m = S1.Length;
        int n = S2.Length;

        LCSAlgorithm(S1, S2, m, n);
    }

    static void LCSAlgorithm(char[] S1, char[] S2, int m, int n)
    {
        int[,] LCSTable = new int[m + 1, n + 1];

        for (int row = 0; row <= m; row++)
        {
            for (int col = 0; col <= n; col++)
            {
                if (row == 0 || col == 0)
                    LCSTable[row, col] = 0;
                else if (S1[row - 1] == S2[col - 1])
                    LCSTable[row, col] = LCSTable[row - 1, col - 1] + 1;
                else
                    LCSTable[row, col] = Math.Max(LCSTable[row - 1, col], LCSTable[row, col - 1]);
            }
        }

        int index = LCSTable[m, n];
        char[] lcs = new char[index];
        int i = m, j = n;

        while (i > 0 && j > 0)
        {
            if (S1[i - 1] == S2[j - 1])
            {
                lcs[index - 1] = S1[i - 1];
                i--;
                j--;
                index--;
            }
            else if (LCSTable[i - 1, j] > LCSTable[i, j - 1])
                i--;
            else
                j--;
        }

        Console.WriteLine("S1 : " + new string(S1) + "\nS2 : " + new string(S2) + "\nLCS: " + new string(lcs));
    }
}

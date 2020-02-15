﻿// -----------------------------------------------
//     Author: Ramon Bollen
//       File: Challenge1.TestData.cs
// Created on: 20200215
// -----------------------------------------------

namespace Challenge1
{
    public static class TestData
    {
        public static int[][] Get()
        {
            var testData = new int[10][];

            for (var i = 0; i < testData.GetLength(0); i++)
            {
                testData[i] = new int[10];
            }

            //  0                   1                   2                   3                   4                   5                   6                   7                   8                   9
            testData[0][0] = 1; testData[0][1] = 2; testData[0][2] = 2; testData[0][3] = 2; testData[0][4] = 2; testData[0][5] = 2; testData[0][6] = 2; testData[0][7] = 2; testData[0][8] = 2; testData[0][9] = 2;
            testData[1][0] = 1; testData[1][1] = 1; testData[1][2] = 2; testData[1][3] = 1; testData[1][4] = 1; testData[1][5] = 1; testData[1][6] = 1; testData[1][7] = 1; testData[1][8] = 1; testData[1][9] = 2;
            testData[2][0] = 2; testData[2][1] = 2; testData[2][2] = 1; testData[2][3] = 1; testData[2][4] = 2; testData[2][5] = 2; testData[2][6] = 2; testData[2][7] = 1; testData[2][8] = 1; testData[2][9] = 2;
            testData[3][0] = 2; testData[3][1] = 1; testData[3][2] = 3; testData[3][3] = 1; testData[3][4] = 1; testData[3][5] = 1; testData[3][6] = 2; testData[3][7] = 1; testData[3][8] = 2; testData[3][9] = 2;
            testData[4][0] = 2; testData[4][1] = 1; testData[4][2] = 3; testData[4][3] = 1; testData[4][4] = 1; testData[4][5] = 1; testData[4][6] = 2; testData[4][7] = 1; testData[4][8] = 3; testData[4][9] = 2;
            testData[5][0] = 2; testData[5][1] = 1; testData[5][2] = 3; testData[5][3] = 1; testData[5][4] = 1; testData[5][5] = 1; testData[5][6] = 2; testData[5][7] = 1; testData[5][8] = 3; testData[5][9] = 2;
            testData[6][0] = 2; testData[6][1] = 1; testData[6][2] = 3; testData[6][3] = 3; testData[6][4] = 3; testData[6][5] = 1; testData[6][6] = 2; testData[6][7] = 1; testData[6][8] = 3; testData[6][9] = 2;
            testData[7][0] = 2; testData[7][1] = 1; testData[7][2] = 3; testData[7][3] = 3; testData[7][4] = 3; testData[7][5] = 1; testData[7][6] = 1; testData[7][7] = 1; testData[7][8] = 3; testData[7][9] = 2;
            testData[8][0] = 2; testData[8][1] = 2; testData[8][2] = 2; testData[8][3] = 3; testData[8][4] = 3; testData[8][5] = 2; testData[8][6] = 3; testData[8][7] = 1; testData[8][8] = 2; testData[8][9] = 2;
            testData[9][0] = 2; testData[9][1] = 2; testData[9][2] = 2; testData[9][3] = 2; testData[9][4] = 2; testData[9][5] = 2; testData[9][6] = 2; testData[9][7] = 2; testData[9][8] = 2; testData[9][9] = 2;

            return testData;
        }
    }
}
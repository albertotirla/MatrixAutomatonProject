using System;
using System.Collections.Generic;
using System.Text;


int n;
Queue<SortedSet<(int, int)>> QA = new();
Queue<SortedSet<(int, int)>> QD = new();
int counter = 0;
Console.Write("n=");
n = int.Parse(Console.ReadLine()!);
string[,] a = new string[n, n];
// Read matrix a from console
init_matrix(a, n);

Console.WriteLine("S | a | d");
var FirstA = GasesteAdiacent(new() { (0, 0) });
var FirstD = GasesteDiagonal(new() { (0, 0) });
QA.Enqueue(FirstA);
QD.Enqueue(FirstD);
PrintAutomatonLine(new() { (0, 0) }, FirstA, FirstD);
while (counter < 2 * n + 1)
{
    var A = QA.Dequeue();
    var D = QD.Dequeue();
    var MA = GasesteAdiacent(A);
    var MD = GasesteDiagonal(A);
    PrintAutomatonLine(A, MA, MD);
    QA.Enqueue(MA);
    QD.Enqueue(MD);
    counter++;
    MA = GasesteAdiacent(D);
    MD = GasesteDiagonal(D);
    PrintAutomatonLine(D, MA, MD);
    QA.Enqueue(MA);
    QD.Enqueue(MD);
    counter++;
}
// Function to map and print the set
void MapAndPrintSet(SortedSet<(int, int)> set)
{
    StringBuilder sb = new("{");
    foreach (var (row, col) in set)
    {
        sb.Append(a[row, col]).Append(", ");
    }
    sb.Length -= 2; // Remove the trailing comma and space
    sb.Append('}');
    Console.Write(sb.ToString());
}
//initialize matrix with user input
void init_matrix(string[,] a, int n)
{
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine($"type line {i + 1}, then press enter");
        string[] input = Console.ReadLine()!.Split(' ');
        for (int j = 0; j < n; j++)
        {
            a[i, j] = input[j];
        }
    }
    Console.WriteLine("matrix reading finished successfully");
}

SortedSet<(int, int)> GasesteAdiacent(SortedSet<(int, int)> x)
{
    SortedSet<(int, int)> MRet = new();
    foreach ((int i, int j) in x)
    {
        SortedSet<(int, int)> MElem = new();
        if (j + 1 < n)
        {
            MElem.Add((i, j + 1));
        }
        if (j - 1 >= 0)
        {
            MElem.Add((i, j - 1));
        }
        if (i + 1 < n)
        {
            MElem.Add((i + 1, j));
        }
        if (i - 1 >= 0)
        {
            MElem.Add((i - 1, j));
        }
        MRet = new SortedSet<(int, int)>(MRet.Union(MElem));
    }
    return MRet;
}
SortedSet<(int, int)> GasesteDiagonal(SortedSet<(int, int)> x)
{
    SortedSet<(int, int)> MRet = new();
    foreach ((int i, int j) in x)
    {
        SortedSet<(int, int)> MElem = new();
        if (i + 1 < n && j + 1 < n)
        {
            MElem.Add((i + 1, j + 1));
        }
        if (i - 1 >= 0 && j - 1 >= 0)
        {
            MElem.Add((i - 1, j - 1));
        }
        if (i + 1 < n && j - 1 >= 0)
        {
            MElem.Add((i + 1, j - 1));
        }
        if (i - 1 >= 0 && j + 1 < n)
        {
            MElem.Add((i - 1, j + 1));
        }
        MRet = new SortedSet<(int, int)>(MRet.Union(MElem));
    }
    return MRet;
}
void PrintAutomatonLine(SortedSet<(int, int)> state, SortedSet<(int, int)> Adjacent, SortedSet<(int, int)> Diagonal)
{
    MapAndPrintSet(state);
    Console.Write(" | ");
    MapAndPrintSet(Adjacent);
    Console.Write(" | ");
    MapAndPrintSet(Diagonal);
    Console.WriteLine();
}
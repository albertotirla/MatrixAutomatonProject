using System.Collections.Generic;
Console.Write("n=");
int n = (int)uint.Parse(Console.ReadLine());
int[,] a = new int[n, n];
Queue<(int, int)> q = new();
//an ordered set is, as the name implies, a set of items which preserves insertion order, while also upholding all the properties of a set, for example element uniqueness
//in c#, there's no built-in class which implements an ordered set
//while I could make one combining a hashmap and a linked list, the code will be too much for this relatively simple program
//so, I'm using a simple List<T> to store the result-set, manually checking if an element exists before insertion to avoid duplicates.
//Note: for large result sets, this might be inefficient because after a time, generic searching algorythms are inefficient without hand-tuned optimisations. However, for the data-set I've seen so far about this problem, the performance implications are a non-issue

List<int> s = new();
Console.WriteLine($"reading the elements of the matrix with dimensions({n}, {n})");
Console.WriteLine("type each element of the matrix on a single line, press enter after each one. Do so untill the program doesn't allow you to enter values anymore");
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        a[i, j] = int.Parse(Console.ReadLine());
    }
}
Console.WriteLine("finished reading matrix!");
//because the logic presented below works in most cases but this one, I decided to prepopulate the queue with the first indices, as well as the set with the element situated at coordinates (0, 0)
q.Enqueue((0, 0));
s.Add(a[0, 0]);
while (q.Count > 0)
{
    (int i, int j) = q.Dequeue();
    Console.WriteLine($"what should happen to element {a[i, j]}? \n Press a for adjacent movement, d for diagonal movement.");
    char c = (char)Console.Read();
    switch (c)
    {
        case 'a':
            muta_adiacent(i, j);
            break;
        case 'd':
            muta_diagonal(i, j);
            break;
        default:
            Console.WriteLine("invalid character, try again");
            continue;
    }
    Console.WriteLine("operation complete!");
}

Console.WriteLine("no more items, the matrix has been fully processed. Displaying result set now, press enter to continue");
Console.ReadKey();
foreach (var item in s)
{
    Console.Write($"{item} ");
}

//functions
void muta_adiacent(int i, int j)
{
    throw new NotImplementedException();
}
void muta_diagonal(int i, int j)
{
    throw new NotImplementedException();
}
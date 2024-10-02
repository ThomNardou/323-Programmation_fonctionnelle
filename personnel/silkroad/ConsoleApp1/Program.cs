bool[,] silkyWay = new bool[8, 8];

silkyWay[0, 0] = true; // A1
silkyWay[7, 7] = true; // H8

// Place de la soie aléatoirement
Random randomColumn = new Random();
Random randomRow = new Random();

for (int i = 0; i<silkyWay.Length/2-2; i++)
{
    // Logique pour placer de la soie à un endroit aléatoirement
    int column = randomColumn.Next(8);
    int row = randomRow.Next(8);

    while (silkyWay[column, row]
        )
    {
        column = randomColumn.Next(8);
        row = randomRow.Next(8);
    }

    silkyWay[column, row] = true;
}

void DrawBoard(bool[,] board)
{
    Console.WriteLine("  12345678");
    Console.WriteLine(" ┌────────┐");
    for (char row = 'A'; row <= 'H'; row++)
    {
        Console.Write(row + "│");
        for (int col = 1; col <= 8; col++)
        {
            if (board[row - 'A', col - 1])
            {
                Console.Write("█");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine("│");
    }
    Console.WriteLine(" └────────┘");
}

// TODO Put silk on 30 more squares

DrawBoard(silkyWay);

// TODO Create a data structure that allow us to remember which square has already been tested
bool[,] testedSquares = new bool[8, 8];

bool SquareHasBeenTested(int column, int row, bool[,] array)
{
    return array[column, row];
}

// TODO Create a data structure that allow us to remember the successful steps

// TODO Write the recursive function
// Recursive function that tells if we can reach H8 from the given position
// The algorithm is in fact simple to spell out (even in french ;)):
//
//      Je peux sortir depuis cette case si:
//          1. Je suis sur H8
//
//              ou
//
//          2. Je peux sortir depuis une des cases où je peux aller (et où je ne suis pas encore allé)

bool[,] way = new bool[8, 8];

bool HaveAnyWay(int x, int y)
{
    if (x == 7 && y == 7) return true;
    
    if (x < 0 || x > 7 || y < 0 || y > 7 || !silkyWay[x,y] || SquareHasBeenTested(x,y,testedSquares) ) return false;
    testedSquares[x, y] = true;

    if (
        HaveAnyWay(x+1,y) || 
        HaveAnyWay(x-1,y) || 
        HaveAnyWay(x,y+1) || 
        HaveAnyWay(x,y-1) || 
        HaveAnyWay(x+1,y+1) || 
        HaveAnyWay(x-1,y-1) ||
        HaveAnyWay(x+1,y-1) ||
        HaveAnyWay(x-1,y+1)
     )
    {
        way[x,y] = true;
        return true;
    };

    return false;
}

// TODO Call the function and show the results
Console.WriteLine("\n\n**********************************************************************************");
Console.WriteLine(HaveAnyWay(0,0));
Console.WriteLine("**********************************************************************************\n\n");

DrawBoard(way);

Console.ReadLine();
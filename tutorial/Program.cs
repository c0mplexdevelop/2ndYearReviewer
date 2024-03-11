// See https://aka.ms/new-console-template for more information
string[,] board =
{
    {" ", " ", string.Empty},
    {string.Empty, string.Empty, string.Empty},
    {string.Empty, string.Empty, string.Empty}
};

string currentTurn = "X";
int playerInputIntPosition()
{
    while(true)
    {
        var playerInput = Console.ReadLine();
        if (int.TryParse(playerInput, out int playerNumericPosition))
        {
            if(playerNumericPosition <= 0)
            {
                Console.WriteLine("The input position must be higher than zero!");
            } else if(playerNumericPosition > board.Length)
            {
                Console.WriteLine("The input position must be lower than the amount of elements!");
            }

            return playerNumericPosition;
        }

        Console.WriteLine("Input must be numeric!");
        continue;
    }
}

Tuple<int, int> turnPositionToRowAndColumn(int position)
{
    int indexedPosition = position - 1;
    int row = indexedPosition / 3;
    int column = indexedPosition % 3; 
    return Tuple.Create(row, column);
}

bool checkIfPositionIsEmpty(int row, int col)
{
    return string.IsNullOrEmpty(board[row, col]);
}

void placePlayerTurnToBoard(int row, int col)
{
    board[row, col] = currentTurn;
}

void printBoard()
{
    for (int row = 0; row <= board.GetUpperBound(0); row++)
    {
        for(int col = 0; col <= board.GetUpperBound(1); col++)
        {
            Console.Write($"{board[row, col]}");
            if(col != board.GetUpperBound(1))
            {
                Console.Write(" | ");
            }
        }

        Console.WriteLine();
        if(row != board.GetUpperBound(0))
        {
            Console.WriteLine("======");
        }
    }
}

int turns = 0;
int maxTurns = board.Length;
while(turns < maxTurns)
{
    printBoard();
    var position = playerInputIntPosition();
    var (rowIndex, columnIndex) = turnPositionToRowAndColumn(position);
    if(!checkIfPositionIsEmpty(rowIndex, columnIndex))
    {
        Console.WriteLine($"Position is taken by {board[rowIndex,columnIndex]}");
        continue;
    }

    placePlayerTurnToBoard(rowIndex, columnIndex);
    turns++;
    currentTurn = currentTurn == "X" ? "O" : "X";
}


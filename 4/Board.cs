using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Cell = _4.Option<uint>;

namespace _4
{
    public class Board
    {
        public Cell[] board { get; protected set; }

        public Board()
        {
            /*
             * You are gonna see this a lot.
             * Maybe I do not know enough
             * Maybe im the smartest man alive
             * whatever I am this isn't my cup of tea.
             * 
             * When using `new Option<int>[4, 4];`
             * you would guess it would call a default constructor
             * or at least the constructor that has no parameters
             * but you would be wrong.
             * 
             * You might think then
             * that it will respect the default parameters
             * defined within the struct decleration itself
             * but you would be wrong.
             * 
             * The default value for any "value-type" is 0
             * The same way a default value for any "reference-type" is null
             * that means I have an array of undefined values.
             * 
             * Isn't C# amazing?
             */
            board = new Cell[16];
            board.Initialize();
            setupBoard();
        }

        private uint getRandomCooridinates()
        {
            // If this reaches a recursion error
            // me aka the programmer is to blame
            var x = randomizeCoordinates();
            if (checkCoordinatesBound(x))
                return x;
            return getRandomCooridinates();
        }

        private uint randomizeCoordinates()
        {
            Random rnd = new();
            return ((uint)rnd.Next(0, 4) + (uint)rnd.Next(0, 4) * 3);
        }

        private bool checkCoordinatesBound(uint inx)
        {
            return inx < 16;
        }

        private bool isCellFree(uint row, uint col)
        {
            return board[row + col * 3].isNone();
        }

        private uint randomCellValue()
        {
            Random rnd = new();
            return (uint)rnd.Next(1, 3) * 2;
        }

        private bool isBoardFull()
        {
            foreach (var cell in board)
            {
                if (cell.isNone())
                    return false;
            }
            return true;
        }
        public void setupBoard()
        {
            uint c1 = getRandomCooridinates();
            uint c2 = getRandomCooridinates();
            board[c1].set(randomCellValue());
            board[c2].set(randomCellValue());
        }

        private Cell[][] OrderCells(Direction d)
        {
            bool rev = d == Direction.Up || d == Direction.Left;
            return d == Direction.Up || d == Direction.Down
                ? groupColumns(rev)
                : groupRows(rev);
        }

        private static Option<T[]> Slice<T>(T[] array, uint start, uint end, uint step)
            where T : struct
        {
            if (start < 0 || start >= end || end >= array.Length)
            {
                return new();
            }
            T[] slice = new T[4];
            for (uint i = start, j = 0; i <= end; i += step, j++)
            {
                slice[j] = array[i];
            }
            return new(slice);
        }

        private static (T, T)[] Pairwise<T>(IEnumerable<T> array)
            => array.Zip(array.Skip(1)).ToArray();
        private Cell[][] groupColumns(bool shouldReverse)
        {
            uint[] starts = { 0, 1, 2, 3 };
            uint[] ends = { 12, 13, 14, 15 };
            Cell[][] result = new Cell[4][];
            uint step = 4;
            foreach (var ((start, end), inx) in starts.Zip(ends).Zip(starts))
            {
                var slice = Slice(board, start, end, step).unwrap();
                if (shouldReverse)
                    result[inx] = slice.Reverse().ToArray();
                else result[inx] = slice;
            }
            return result;
        }

        private Cell[][] groupRows(bool shouldReverse)
        {
            uint[] indices = { 0, 1, 2, 3 };
            uint[] starts = { 0, 4, 8, 12 };
            uint[] ends = { 3, 7, 11, 15 }; ;
            uint step = 1;
            Cell[][] result = new Cell[4][];
            foreach (var ((start, end), inx) in starts.Zip(ends).Zip(indices))
            {
                var slice = Slice(board, start, end, step).unwrap();
                if (shouldReverse)
                    result[inx] = slice.Reverse().ToArray();
                else result[inx] = slice;
            }
            return result;
        }

        public uint Move(Direction direction)
        {
            Cell[][] groupedCellsByDirection = OrderCells(direction);

            foreach (var x in groupedCellsByDirection)
            {
                foreach (var c in x)
                {
                    Console.Write($"{c}, ");
                }
                Console.WriteLine();
            }
            foreach (var x in groupedCellsByDirection)
            {
                for (int i = 1; i < 4; i++)
                {
                    if (x[i].isNone()) continue;
                    int lastNone = i;
                    while (lastNone > 0 && x[lastNone--].isSome());
                    x[lastNone] = x[i];
                    x[i] = new Cell();
                    i = lastNone;
                }
            }
            foreach (var x in groupedCellsByDirection)
            {
                foreach (var c in x)
                {
                    Console.Write($"{c}, ");
                }
                Console.WriteLine(  );
            }
            return 0;
        }

        public override string ToString()
        {
            int i = 0;
            var sb = new StringBuilder();
            foreach (var x in board)
            {
                if (i++ % 4 == 0)
                {
                    sb.AppendLine();
                }
                sb.Append($"{x}, ");
            }
            return sb.ToString();
        }
    }
}

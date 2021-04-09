using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace EdistynytTentti02
{
    class ConsoleControl
    {
        //ominaisuudet
        public List<string> Items { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ConsoleColor BackColor { get; set; }
        public ConsoleColor TextColor { get; set; }
        //konstruktori
        public ConsoleControl(int col, int row, int width, int height)
        {
            Column = col;
            Row = row;
            Width = width;
            Height = height;
            BackColor = BackgroundColor;
            TextColor = ForegroundColor;
            Items = null;
        }

        //ominaisuudet

        public void Clear()
        {
            var CursorPos = (CursorLeft, CursorTop);

            for (int i = 0; i < Column; i++)
            {
                SetCursorPosition(Column, Row);
                for (int j = 0; j < Row; j++)
                {
                    Write(" ");
                }
            }

            //for (int i = 0; i < Height; i++)
            //{

            //}
            SetCursorPosition(CursorPos.CursorLeft, CursorPos.CursorTop);
        }
        public void Draw()
        {
            var CursorPos = (CursorLeft, CursorTop);
            var Colors = (Console.ForegroundColor, Console.BackgroundColor);

            for (int i = 0; i < Column; i++)
            {
                WriteLine();
                for (int j = 0; j < Items.Count; j++)
                {
                    string str = Items[j];
                    char pad = ' ';


                    ForegroundColor = TextColor;
                    BackgroundColor = BackColor;
                    //WriteLine(Items[j]);
                    WriteLine(str.PadRight((Width), pad)); //  - Items[j].Length
                }

                //string str = Items[i];
                //char pad = ' ';
                //WriteLine(str.PadRight((Width - Items[i].Length), pad));
                
            }

            SetCursorPosition(CursorPos.CursorLeft, CursorPos.CursorTop);
            ForegroundColor = Colors.ForegroundColor;
            BackgroundColor = Colors.BackgroundColor;
        }
    }
}

using AzemitologaUzdevums.Engine.General.Draw;
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AzemitologaUzdevums.Engine.Core
{
    public class Renderer
    {
        public int Width { get => DrawingArea.Right; }
        public int Height { get => DrawingArea.Bottom; }
        private CharInfo[] Buffer { get; set; }
        private SafeFileHandle Handle { get; set; }
        private SmallRect DrawingArea { get; set; }
        
        public Renderer(short width, short height)
        {
            Handle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            if (Handle.IsInvalid)
            {
                throw new Exception("Handle is invalid!");
            }

            Buffer = new CharInfo[width * height];
            DrawingArea = new SmallRect() { Left = 0, Top = 0, Right = width, Bottom = height };
            Clear();
        }

        public void Clear()
        {
            for(int i = 0; i < Width * Height; i++)
            {
                Buffer[i] = new CharInfo 
                {
                    Attributes = 0,
                    Char = new CharUnion
                    {
                        AsciiChar = 32,
                        UnicodeChar = ' '
                    }
                };
            }
        }

        public void SetChar(Coord coord, short? fg = null, short? bg = null, ushort? c = null)
        {
            
            if (coord.X < 0 || coord.Y < 0 || coord.X >= Width || coord.Y >= Height)
            {
                return;
            }

            var pixel = Buffer[DrawingArea.SequenceOf(coord)];

            // TODO: Debug variables. Remove later
            var currFg = pixel.Attributes % 16;
            var currBg = pixel.Attributes >> 4;

            pixel.Char.UnicodeChar = c ?? pixel.Char.UnicodeChar;
            pixel.Attributes = (short)((bg ?? currBg) * 16 + (fg ?? currFg));

            Buffer[DrawingArea.SequenceOf(coord)] = pixel;
        }

        public void DrawLineFree(Coord start, Coord end, short? fg = null, short? bg = null, ushort? c = null)
        {
            DrawLine(start, end - start, fg, bg, c);
        }

        public void DrawLine(Coord start, Coord mag, short? fg = null, short? bg = null, ushort? c = null)
        {
            //if (mag.Y < 0) { start.Y = (short)(start.Y + mag.Y); mag.Y = (short)-mag.Y; }
            //if (mag.X < 0) { start.X = (short)(start.X + mag.X); mag.X = (short)-mag.X; }
            var dx = mag.X > 0 ? 1 : -1;
            var dy = mag.Y > 0 ? 1 : -1;
            //mag.Y <<= 1;                                                  // dy is now 2*dy
            //mag.X <<= 1;                                                  // dx is now 2*dx

            if (mag.X * dx > mag.Y * dy)
            {
                for (int x = start.X; x != start.X + mag.X + dx; x += dx)
                {
                    var y = (short)Math.Round((x - start.X) / (double)mag.X * mag.Y) + start.Y;
                    SetChar(new Coord(x, y), fg, bg, c);
                }
            }
            else
            {
                for (int y = start.Y; y != start.Y + mag.Y + dy; y += dy)
                {
                    var x = (short)Math.Round((y - start.Y) / (double)mag.Y * mag.X) + start.X;
                    SetChar(new Coord(x, y), fg, bg, c);
                }
            }
        }

        public void DrawRectangle(Coord start, Coord dimensions, short? fg = null, short? bg = null, ushort? c = null)
        {
            for (int x = start.X; x < dimensions.X + start.X; x++)
            {
                for (int y = start.Y; y < dimensions.Y + start.Y; y++)
                {
                    SetChar(new Coord(x, y), fg, bg, c);
                }
            }
        }

        public void Render()
        {
            SmallRect rect = DrawingArea;

            WriteConsoleOutputW(Handle, Buffer,
                new Coord() { X = rect.Right, Y = rect.Bottom },
                new Coord() { X = 0, Y = 0 },
                ref rect);
        }

        // Here are functions that are being imported via external dlls. They will work only on windows platforms
        #region DLL_IMPORTS
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutputW(
            SafeFileHandle hConsoleOutput,
            CharInfo[] lpBuffer,
            Coord dwBufferSize,
            Coord dwBufferCoord,
            ref SmallRect lpWriteRegion);
        #endregion
    }
}

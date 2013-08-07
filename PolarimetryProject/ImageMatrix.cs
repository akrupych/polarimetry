using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using BitMiracle.LibTiff.Classic;
using System.Runtime.InteropServices;

namespace PolarimetryProject
{
    /// <summary>
    /// Contains pattern raw data in an effective matrix.
    /// Can be read from file and converted to a Bitmap.
    /// </summary>
    class ImageMatrix
    {
        /// <summary>
        /// Matrix itsels
        /// </summary>
        private byte[] Data { get; set; }
        /// <summary>
        /// Rows number
        /// </summary>
        public int Rows { get; private set; }
        /// <summary>
        /// Columns number
        /// </summary>
        public int Columns { get; private set; }

        /// <summary>
        /// Creates empty matrix
        /// </summary>
        /// <param name="rows">Rows number</param>
        /// <param name="columns">Columns number</param>
        public ImageMatrix(int rows, int columns)
        {
            Data = new byte[rows * columns];
            Rows = rows;
            Columns = columns;
        }

        /// <summary>
        /// Creates matrix from 600x500 .TIF image
        /// </summary>
        /// <param name="fileName">Image path</param>
        public ImageMatrix(String fileName)
        {
            // prepare for reading
            Tiff input = Tiff.Open(fileName, "r");
            Columns = input.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
            Rows = input.GetField(TiffTag.IMAGELENGTH)[0].ToInt();

            // read data
            Data = new byte[Rows * Columns];
            for (int row = 0; row < Rows; row++)
                input.ReadScanline(Data, row * Columns, row, 0);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="that">Matrix to copy</param>
        public ImageMatrix(ImageMatrix that) : this(that.Rows, that.Columns)
        {
            this.Data = (byte[]) that.Data.Clone();
        }

        /// <summary>
        /// Gets or sets matrix element
        /// </summary>
        /// <param name="row">Row index</param>
        /// <param name="column">Column index</param>
        /// <returns>Element value</returns>
        public byte this [int row, int column]
        {
            get { return Data[row * Columns + column]; }
            set { Data[row * Columns + column] = value; }
        }

        /// <summary>
        /// Converts matrix to grayscale bitmap
        /// </summary>
        /// <returns>Created bitmap</returns>
        public Bitmap ToBitmap()
        {
            // prepare bitmap
            Bitmap bmp = new Bitmap(Columns, Rows, PixelFormat.Format8bppIndexed);
            ColorPalette ncp = bmp.Palette;
            for (int i = 0; i < 256; i++)
                ncp.Entries[i] = Color.FromArgb(255, i, i, i);
            bmp.Palette = ncp;

            // copy data
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, Columns, Rows),
                ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            IntPtr ptr = data.Scan0;
            byte[] aligned = GetBitmapArray(data.Stride);
            Marshal.Copy(aligned, 0, ptr, aligned.Length);
            bmp.UnlockBits(data);
            return bmp;
        }

        /// <summary>
        /// Converts matrix to fit the bitmap stride
        /// </summary>
        /// <param name="stride">Number of bytes per bitmap line
        /// (it's aligned to 4 bytes for effectiveness)</param>
        /// <returns>Array to be set as BitmapData</returns>
        private byte[] GetBitmapArray(int stride)
        {
            byte[] result = new byte[stride * Rows];
            for (int row = 0; row < Rows; row++)
                Array.Copy(Data, row * Columns, result, row * stride, Columns);
            return result;
        }

        /// <summary>
        /// Returns column profile
        /// </summary>
        /// <param name="column">Column index</param>
        /// <returns>New array with column bytes</returns>
        public byte[] GetColumn(int column)
        {
            byte[] result = new byte[Rows];
            for (int i = 0; i < Rows; i++)
                result[i] = this[i, column];
            return result;
        }

        /// <summary>
        /// Returns row profile
        /// </summary>
        /// <param name="column">Row index</param>
        /// <returns>New array with row bytes</returns>
        public byte[] GetRow(int row)
        {
            byte[] result = new byte[Columns];
            // array implementation allows increasing effectiveness
            Array.Copy(Data, row * Columns, result, 0, Columns);
            return result;
        }

        /// <summary>
        /// Returns range of row profile
        /// </summary>
        /// <param name="row">Row index</param>
        /// <param name="from">Start column index</param>
        /// <param name="to">End column index</param>
        /// <returns>New array with row range bytes</returns>
        public byte[] GetRow(int row, int from, int to)
        {
            byte[] result = new byte[to - from];
            Array.Copy(Data, row * Columns + from, result, 0, to - from);
            return result;
        }

        /// <summary>
        /// Returns range of column profile
        /// </summary>
        /// <param name="row">Column index</param>
        /// <param name="from">Start row index</param>
        /// <param name="to">End row index</param>
        /// <returns>New array with column range bytes</returns>
        public byte[] GetColumn(int column, int from, int to)
        {
            byte[] result = new byte[to - from];
            for (int i = 0; i < result.Length; i++)
                result[i] = this[i, column];
            return result;
        }
    }
}

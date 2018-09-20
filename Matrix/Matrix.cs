using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Matrix
    {
        #region FILEDS
        private int[,] DArray;
        private int LineSizeX;
        private int LineSizeY;
        #endregion


        #region CTORS
        /// <summary>
        /// create 2-Dimensional Array 5x5
        /// </summary>
        public Matrix() : this(5) { }
        /// <summary>
        /// Create 2-Dimensional Array SizeX x 5
        /// </summary>
        /// <param name="SizeX">Axis X size / Размер оси X</param>
        public Matrix(int SizeX) : this(SizeX, 5) { }
        /// <summary>
        /// Create 2-Dimensional Array SizeX x SizeY
        /// </summary>
        /// <param name="SizeX">Axis X size / Размер оси X</param>
        /// <param name="SizeY">Axis Y size / Размер оси Y</param>
        public Matrix(int SizeX, int SizeY)
        {
            DArray = new int[SizeX, SizeY];
            LineSizeX = SizeX;
            LineSizeY = SizeY;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Init array 0 value
        /// </summary>
        /// <returns>bool</returns>
        public bool InitDefault()
        {
            if (LineSizeX <= 0)
                return false;

            for (int i = 0; i < LineSizeX; i++)
            {
                for (int j = 0; j < LineSizeY; j++)
                {
                    DArray[i, j] = 0;
                }
            }
            return true;
        }

        /// <summary>
        /// Init array random value in 1..100
        /// </summary>
        /// <returns>bool</returns>
        public bool InitRandom()
        {
            if (LineSizeX <= 0)
                return false;

            Random Rand = new Random();
            for (int i = 0; i < LineSizeX; i++)
            {
                for (int j = 0; j < LineSizeY; j++)
                {
                    DArray[i, j] = Rand.Next(1, 10);
                }
            }
            return true;
        }

        /// <summary>
        /// Init array by user values
        /// </summary>
        /// <param name="UserArray">User's 2-Dimensional array</param>
        /// <param name="SizeX">Size of X axis</param>
        /// <returns>bool</returns>
        public bool InitUser(int[,] UserArray, int SizeX)
        {
            if (LineSizeX <= 0 || UserArray.Length <= 0) return false;
            int MinX, MinY;

            if (SizeX < LineSizeX) MinX = SizeX;
            else MinX = LineSizeX;

            if (Math.Sqrt(UserArray.Length) / SizeX < LineSizeY) MinY = (int)Math.Sqrt(UserArray.Length) / SizeX;
            else MinY = LineSizeY;

            for (int i = 0; i < MinX; i++)
            {
                for (int j = 0; j < MinY; j++)
                {
                    DArray[i, j] = UserArray[i, j];
                }
            }
            return true;
        }

        /// <summary>
        /// Print Array
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < LineSizeX; i++)
            {
                for (int j = 0; j < LineSizeY; j++)
                {
                    Console.Write("{0}   ", DArray[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Change the Main Diagonal to Opposit Diagonal
        /// </summary>
        public void ChangeDiagonal()
        {
            int[,] tempArray = null;
            GetArray(ref tempArray);

            for (int i = 0; i < LineSizeX; i++)
            {
                tempArray[i, i] = DArray[i, LineSizeX - 1 - i];
                tempArray[i, LineSizeX - 1 - i] = DArray[i, i];
            }

            for (int i = 0; i < LineSizeX; i++)
            {
                for (int j = 0; j < LineSizeY; j++)
                {
                    DArray[i, j] = tempArray[i, j];
                }
            }
        }

        /// <summary>
        /// Mutiplicate arrays
        /// </summary>
        /// <param name="Obj">Object type "Matrix"</param>
        /// <returns>int[,]</returns>
        public int[,] Multi(Matrix Obj)
        {
            int MinX, MinY;
            if (Obj.GetColumnSize() < LineSizeX) MinX = Obj.GetColumnSize();
            else MinX = LineSizeX;
            if (Obj.GetLineSize() < LineSizeX) MinY = Obj.GetLineSize();
            else MinY = LineSizeY;

            int[,] tempArray = new int[MinX, MinY];

            for (int i = 0; i < MinX; i++)
            {
                for (int j = 0; j < MinY; j++)
                {
                    tempArray[i, j] = Obj.DArray[i, j] * DArray[i, j];
                }
            }
            return tempArray;
        }

        /// <summary>
        /// Sort 2-Dimensional Array
        /// </summary>
        public void Sort()
        {
            int[] tempArray = new int[LineSizeX * LineSizeY];
            int a = 0;
            for (int i = 0; i < LineSizeX; i++)
            {
                for (int j = 0; j < LineSizeY; j++)
                {
                    tempArray[a++] = DArray[i, j];
                }
            }

            Array.Sort(tempArray);
            a = 0;
            for (int i = 0; i < LineSizeX; i++)
            {
                for (int j = 0; j < LineSizeY; j++)
                {
                    DArray[i, j] = tempArray[a++];
                }
            }
        }

        /// <summary>
        /// Interpret the horizontal line to vertical and conversely
        /// </summary>
        public void Transpose()
        {
            int[,] tempDArray = new int[LineSizeY, LineSizeX];
            for (int i = 0; i < LineSizeY; i++)
            {
                for (int j = 0; j < LineSizeX; j++)
                {
                    tempDArray[i, j] = DArray[j, i];
                }
            }

            DArray = new int[LineSizeY, LineSizeX];
            int Temp = LineSizeX;
            LineSizeX = LineSizeY;
            LineSizeY = Temp;
            for (int i = 0; i < LineSizeX; i++)
            {
                for (int j = 0; j < LineSizeY; j++)
                {
                    DArray[i, j] = tempDArray[i, j];
                }
            }
        }
        #endregion

        #region STATICMETHODS
        /// <summary>
        /// Sort 2-Dimensional array
        /// </summary>
        /// <param name="Obj">Object type "Matrix"</param>
        public static void Sort(Matrix Obj)
        {
            int XPosition, YPosition, CheckY = 0, CheckX = 0;
            bool High;

            while (CheckX != Obj.LineSizeX || CheckY != Obj.LineSizeY)
            {
                High = false;
                if (CheckY >= Obj.LineSizeY)
                {
                    CheckY = 0;
                    CheckX++;
                }
                XPosition = CheckX;
                YPosition = CheckY;

                for (int i = CheckX; i < Obj.LineSizeX; i++)
                {
                    for (int j = 0; j < Obj.LineSizeY; j++)
                    {
                        if (Obj.DArray[XPosition, YPosition] > Obj.DArray[i, j] && (XPosition < i || YPosition < j))
                        {
                            int Temp = Obj.DArray[XPosition, YPosition];
                            Obj.DArray[XPosition, YPosition] = Obj.DArray[i, j];
                            Obj.DArray[i, j] = Temp;
                            XPosition = i;
                            YPosition = j;
                            High = true;
                        }
                    }
                }
                if (!High)
                    CheckY++;
            }
            return;
        }

        /// <summary>
        /// Interpret the horizontal line to vertical and conversely
        /// </summary>
        /// <param name="Obj">Object type "Matrix"</param>
        public static void Traspose(Matrix Obj)
        {
            int[,] tempDArray = new int[Obj.LineSizeY, Obj.LineSizeX];
            for (int i = 0; i < Obj.LineSizeY; i++)
            {
                for (int j = 0; j < Obj.LineSizeX; j++)
                {
                    tempDArray[i, j] = Obj.DArray[j, i];
                }
            }

            Obj.DArray = new int[Obj.LineSizeY, Obj.LineSizeX];
            int Temp = Obj.LineSizeX;
            Obj.LineSizeX = Obj.LineSizeY;
            Obj.LineSizeY = Temp;
            for (int i = 0; i < Obj.LineSizeX; i++)
            {
                for (int j = 0; j < Obj.LineSizeY; j++)
                {
                    Obj.DArray[i, j] = tempDArray[i, j];
                }
            }
        }

        /// <summary>
        /// Change the Main Diagonal to Opposit Diagonal
        /// </summary>
        /// <param name="Obj">Object type "Matrix"</param>
        public static void ChangeDiagonal(Matrix Obj)
        {
            int[,] tempArray = null;
            Obj.GetArray(ref tempArray);

            for (int i = 0; i < Obj.LineSizeX; i++)
            {
                tempArray[i, i] = Obj.DArray[i, Obj.LineSizeX - 1 - i];
                tempArray[i, Obj.LineSizeX - 1 - i] = Obj.DArray[i, i];
            }

            for (int i = 0; i < Obj.LineSizeX; i++)
            {
                for (int j = 0; j < Obj.LineSizeY; j++)
                {
                    Obj.DArray[i, j] = tempArray[i, j];
                }
            }
        }
        #endregion

        #region PRTIES
        /// <summary>
        /// Returns count of columns
        /// </summary>
        /// <returns>int</returns>
        public int GetColumnSize()
        {
            return LineSizeX;
        }

        /// <summary>
        /// Returns count of lines
        /// </summary>
        /// <returns>int</returns>
        public int GetLineSize()
        {
            return LineSizeY;
        }

        /// <summary>
        /// Find max element in array
        /// </summary>
        /// <returns>int</returns>
        public int Max()
        {
            int Max = 0;
            for (int i = 0; i < LineSizeX; i++)
            {
                for (int j = 0; j < LineSizeY; j++)
                {
                    if (Max < DArray[i, j]) Max = DArray[i, j];
                }
            }
            return Max;
        }

        /// <summary>
        /// Find min element in array
        /// </summary>
        /// <returns>int</returns>
        public int Min()
        {
            int Min = DArray[0, 0];
            for (int i = 0; i < LineSizeX; i++)
            {
                for (int j = 0; j < LineSizeY; j++)
                {
                    if (Min > DArray[i, j]) Min = DArray[i, j];
                }
            }
            return Min;
        }

        /// <summary>
        /// Copy Matrix array to User's array
        /// </summary>
        /// <param name="UserArray">link to UsersArray</param>
        public void GetArray(ref int[,] UserArray)
        {
            if (UserArray != null)
                UserArray = null;
            UserArray = new int[LineSizeX, LineSizeY];

            for (int i = 0; i < LineSizeX; i++)
            {
                for (int j = 0; j < LineSizeY; j++)
                {
                    UserArray[i, j] = DArray[i, j];
                }
            }
            return;
        }


        #endregion
    }
}

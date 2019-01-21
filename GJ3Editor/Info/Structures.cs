/*   Project Name: GJ3D Editor
 *   File Name: Structures.cs
 *   Author: Ilya Fedin
 *   Date Created: Fri, Jan 18, 2018
 *   Date Modeified: Sun, Jan 10, 2018
 *   File Description: File containing multiple structs that are used in a program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJ3Editor
{
    /// <summary>
    /// Matrix elemest, containing a 2D array of floats
    /// </summary>
    public struct Matrix
    {
        public float[,] m { get; set; }
        public Matrix(int x, int y)
        {
            m = new float[x, y];
        }
    }

    /// <summary>
    /// Vector3 element, containg 3 floats X, Y, Z
    /// </summary>
    public struct Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        //Allowng to perform mathematical operations on verctors
        public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }
        public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }
        public static Vector3 operator *(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X * vec2.X, vec1.Y * vec2.Y, vec1.Z * vec2.Z);
        }
        public static Vector3 operator /(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X / vec2.X, vec1.Y / vec2.Y, vec1.Z / vec2.Z);
        }
    }

    /// <summary>
    /// Vector3 element, containg 3 ints X, Y, Z
    /// </summary>
    public struct Vector3i
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Vector3i(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJ3Editor
{
    /// <summary>
    /// Class for manipulating the coordinates of the oridinal model and calculating rotated, scales, trandlated and projected coordinates 
    /// </summary>
    class Manipulator
    {
        private Mesh mesh;
        private Mesh backupMesh;

        // Matrices
        private Matrix OrthographicProjectionMatrix;
        private Matrix TranslationMatrix;
        private Matrix ScalingMatrix;
        private Matrix RotationMatrix_X;
        private Matrix RotationMatrix_Y;
        private Matrix RotationMatrix_Z;

        // Projection related variables
        private float Far = -1;
        private float Near = 1;
        private float Right = 1;
        private float Left = -1;
        private float Top = 1;
        private float Bottom = -1;

        private Manipulator(int displayWidth, int displayHeight)
        {
            //Initialize all of th matrices here
            //Use width and height for projection matrix intialization

            OrthographicProjectionMatrix = new Matrix(4, 4);
            OrthographicProjectionMatrix.m[0, 0] = 2 / (Right - Left);
            OrthographicProjectionMatrix.m[1, 1] = 2 / (Top - Bottom);
            OrthographicProjectionMatrix.m[2, 2] = -2 / (Far - Near);
            OrthographicProjectionMatrix.m[0, 3] = -(Right + Left) / (Right - Left);
            OrthographicProjectionMatrix.m[1, 3] = -(Top + Bottom) / (Top - Bottom);
            OrthographicProjectionMatrix.m[2, 3] = -(Far + Near) / (Far - Near);
            OrthographicProjectionMatrix.m[3, 3] = 1;
        }

        /// <summary>
        /// Multiplies the vertex by 4x4 or 3x3 matrix
        /// </summary>
        /// <param name="originalVector">Original vertex</param>
        /// <param name="matrix">4x4 or 3x3 Matrix</param>
        /// <returns>A new multiplied vector</returns>
        private Vector3 MultiplyMatrix(Vector3 originalVector, Matrix matrix)
        {
            Vector3 resultVector = originalVector;

            // Multiply 3 by 3 matrix 
            resultVector.X = originalVector.X * matrix.m[0, 0] + originalVector.Y * matrix.m[1, 0] + originalVector.Z * matrix.m[2, 0];
            resultVector.Y = originalVector.X * matrix.m[0, 1] + originalVector.Y * matrix.m[1, 1] + originalVector.Z * matrix.m[2, 1];
            resultVector.Z = originalVector.X * matrix.m[0, 2] + originalVector.Y * matrix.m[1, 2] + originalVector.Z * matrix.m[2, 2];

            // Check if the passed matrix is 4 by 4
            if (matrix.m.GetLength(0) > 3 && matrix.m.GetLength(1) > 3)
            {
                float W = originalVector.X * matrix.m[0, 3] + originalVector.Y * matrix.m[0, 2] + originalVector.Z * matrix.m[0, 2] + matrix.m[0, 2];

                resultVector.X += W * matrix.m[3, 0];
                resultVector.Y += W * matrix.m[3, 1];
                resultVector.Z += W * matrix.m[3, 2];
            }

            return resultVector;
        }
    }
}

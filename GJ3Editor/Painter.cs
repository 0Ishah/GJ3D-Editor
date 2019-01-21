/*   Project Name: GJ3D Editor
 *   File Name: Painter.cs
 *   Author: Ilya Fedin
 *   Date Created: Fri, Jan 18, 2018
 *   Date Modeified: Sun, Jan 10, 2018
 *   File Description: Painter class is responsible for all of the drawing on the screen. Has the ability to project models into orthographic view and rotate them
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJ3Editor
{
    public class Painter
    {
        public Graphics g { get; } //Main grapics element used to draw all of the meshes
        public float time { get; set; } //Time ussed for autorotation

        // Hard coded matrices used for projection and rotation
        private Matrix OrthogrphicProjection;
        private Matrix RotationMatrix_X;
        private Matrix RotationMatrix_Y;
        private Matrix RotationMatrix_Z;

        public int selectedVertex { get; set; } //Maintains the index of the selected vertex

        public Vector3 rotation { get; set; } //Current andgle of XYZ rotation of the shape
        public Vector3i autorotationAxis { get; set; } //Rotating axis value must be 1, while other must be 0

        //Data used for creating a matrix. Separate variables are created to improve readability
        private float Width;
        private float Height;
        private float Near;
        private float Far;
        private float Top;
        private float Bottom;
        private float Right;
        private float Left;

        private Pen pen; //Pen used for drawing all of the graphics


        /// <summary>
        /// Base Painter constructor that is initializing all of the data
        /// </summary>
        public Painter()
        {
            g = frmMain.canvas.CreateGraphics();

            Width = frmMain.canvas.Width;
            Height = frmMain.canvas.Height;

            Far = 1f;
            Near = -1f;
            Top = 1f;
            Bottom = -1f;
            Right = 1f;
            Left = -1f;

            //Setting up all of the matrices
            OrthogrphicProjection = new Matrix(4, 4); 
            OrthogrphicProjection.m[0, 0] = 2f / (Right - Left);
            OrthogrphicProjection.m[1, 1] = 2f / (Top - Bottom);
            OrthogrphicProjection.m[2, 2] = -2f / (Far - Near);
            OrthogrphicProjection.m[0, 3] = -(Right + Left) / (Right - Left);
            OrthogrphicProjection.m[1, 3] = -(Top + Bottom) / (Top - Bottom);
            OrthogrphicProjection.m[2, 3] = -(Far + Near) / (Far - Near);
            OrthogrphicProjection.m[3, 3] = 1f;

            RotationMatrix_X = new Matrix(3, 3);
            RotationMatrix_X.m[0, 0] = 1;
            RotationMatrix_X.m[1, 1] = (float)Math.Cos(0);
            RotationMatrix_X.m[1, 2] = -(float)Math.Sin(0);
            RotationMatrix_X.m[2, 1] = (float)Math.Sin(0);
            RotationMatrix_X.m[2, 2] = (float)Math.Cos(0);

            RotationMatrix_Y = new Matrix(3, 3);
            RotationMatrix_Y.m[0, 0] = (float)Math.Cos(0);
            RotationMatrix_Y.m[0, 2] = -(float)Math.Sin(0);
            RotationMatrix_Y.m[1, 1] = 1;
            RotationMatrix_Y.m[2, 0] = (float)Math.Sin(0); 
            RotationMatrix_Y.m[2, 2] = (float)Math.Cos(0);

            RotationMatrix_Z = new Matrix(3, 3);
            RotationMatrix_Z.m[0, 0] = (float)Math.Cos(0);
            RotationMatrix_Z.m[0, 1] = (float)Math.Sin(0);
            RotationMatrix_Z.m[1, 0] = -(float)Math.Sin(0);
            RotationMatrix_Z.m[1, 1] = (float)Math.Cos(0);
            RotationMatrix_Z.m[2, 2] = 1;


            pen = new Pen(Color.Black, 1);
        }

        /// <summary>
        /// Draws a specifies mesh by drawing each face triangle
        /// </summary>
        /// <param name="mesh">mesh to draw</param>
        public void DrawMesh(Mesh mesh)
        {
            //Loops through all of the faces in the mesh, drawing correspondng triangles
            for (int i = 0; i < mesh.GetFaces().Count; i++)
            {
                DrawTriangle(mesh.GetVertices()[mesh.GetFaces()[i].X], mesh.GetVertices()[mesh.GetFaces()[i].Y], mesh.GetVertices()[mesh.GetFaces()[i].Z]);
            }            
        }
        /// <summary>
        /// Draws a specifies mesh by drawing each face triangle with a specified color
        /// </summary>
        /// <param name="mesh">mesh to draw</param>
        /// <param name="color">clor</param>
        public void DrawMesh(Mesh mesh, Color color)
        {
            pen.Color = color;
            DrawMesh(mesh);
        }

        /// <summary>
        /// Draws a triangle between 3 specified coordinates, projecting it into a 2d screen
        /// </summary>
        /// <param name="inputVert1">Vertex</param>
        /// <param name="inputVert2">Vertex</param>
        /// <param name="inputVert3">Vertex</param>
        public void DrawTriangle(Vector3 inputVert1, Vector3 inputVert2, Vector3 inputVert3)
        {
            //Check if any of the elemets were rotated
            UpdateRotationMatrices();

            //Apply proction function to create an orthographoc view
            Vector3 projectedVector1 = ProjectVector(inputVert1, OrthogrphicProjection, true);
            Vector3 projectedVector2 = ProjectVector(inputVert2, OrthogrphicProjection, true);
            Vector3 projectedVector3 = ProjectVector(inputVert3, OrthogrphicProjection, true);

            //Draw the triangles, inverting the y coordinate.
            //Y is inverted for shifing the origin of the display to the center
            g.DrawLine(pen, projectedVector1.X, -projectedVector1.Y, projectedVector2.X, -projectedVector2.Y);
            g.DrawLine(pen, projectedVector2.X, -projectedVector2.Y, projectedVector3.X, -projectedVector3.Y);
            g.DrawLine(pen, projectedVector3.X, -projectedVector3.Y, projectedVector1.X, -projectedVector1.Y);
        }

        /// <summary>
        /// draws a point on a specified position on a screen
        /// </summary>
        /// <param name="pos">position</param>
        public void DrawPoint(Vector3 pos)
        {
            g.DrawEllipse(pen, pos.X, -pos.Y, 3, 3);
        }

        /// <summary>
        /// draws a point on a specified position on a screen with a speciefic color
        /// </summary>
        /// <param name="pos">Position</param>
        /// <param name="color">color</param>
        public void DrawPoint(Vector3 pos, Color color)
        {
            pen.Color = color;
            DrawPoint(pos);
        }

        /// <summary>
        /// Draws the axis arrows on a specefied vertex
        /// </summary>
        /// <param name="pos"></param>
        public void DrawAxisArrows(Vector3 pos)
        {
            Vector3 tempStart;
            Vector3 tempEnd;

            pen.Width = 2;
            pen.Color = Color.Red;
            tempStart = ProjectVector((pos - new Vector3(20, 0, 0)), OrthogrphicProjection, false);
            tempEnd = ProjectVector(pos + new Vector3(20, 0, 0), OrthogrphicProjection, false);

            g.DrawLine(pen, tempStart.X, -tempStart.Y, tempEnd.X, -tempEnd.Y);

            pen.Color = Color.Green;
            tempStart = ProjectVector(pos - new Vector3(0, 20, 0), OrthogrphicProjection, false);
            tempEnd = ProjectVector(pos + new Vector3(0, 20, 0), OrthogrphicProjection, false);

            g.DrawLine(pen, tempStart.X, -tempStart.Y, tempEnd.X, -tempEnd.Y);

            pen.Color = Color.Blue;
            tempStart = ProjectVector(pos - new Vector3(0, 0, 20), OrthogrphicProjection, false);
            tempEnd = ProjectVector(pos + new Vector3(0, 0, 20), OrthogrphicProjection, false);

            g.DrawLine(pen, tempStart.X, -tempStart.Y, tempEnd.X, -tempEnd.Y);
            pen.Width = 1;
        }

        /// <summary>
        /// Matrix multiplication funtions allowng to multiply verctors by 4x4 and 3x3 matrices
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="mat"></param>
        /// <returns></returns>
        public Vector3 MultiplyMatrix(Vector3 vec, Matrix mat)
        {
            Vector3 result = vec;

            //Mutiply the first 3 rows and colums of the matrix
            result.X = vec.X * mat.m[0, 0] + vec.Y * mat.m[1, 0] + vec.Z * mat.m[2, 0];
            result.Y = vec.X * mat.m[0, 1] + vec.Y * mat.m[1, 1] + vec.Z * mat.m[2, 1];
            result.Z = vec.X * mat.m[0, 2] + vec.Y * mat.m[1, 2] + vec.Z * mat.m[2, 2];

            //If the matrix is 4x4, add the rest
            if (mat.m.GetLength(0) == 4 && mat.m.GetLength(1) == 4)
            {
                result.X += mat.m[3, 0];
                result.Y += mat.m[3, 1];
                result.Z += mat.m[3, 2];

                float w = vec.X * mat.m[0, 3] + vec.Y * mat.m[1, 3] + vec.Z * mat.m[2, 3] + mat.m[3, 3];

                if (w != 0)
                {
                    result.X /= w;
                    result.Y /= w;
                    result.Z /= w;
                }
            }   

            return result;
        }

        /// <summary>
        /// Cleas the display
        /// </summary>
        public void Reset()
        {
            g.Clear(Color.Azure);
        }

        /// <summary>
        /// Updates rotation matrices based on the current shape rotation angle
        /// </summary>
        private void UpdateRotationMatrices()
        {
            RotationMatrix_X.m[0, 0] = 1;
            RotationMatrix_X.m[1, 1] = (float)Math.Cos(rotation.X);
            RotationMatrix_X.m[1, 2] = -(float)Math.Sin(rotation.X);
            RotationMatrix_X.m[2, 1] = (float)Math.Sin(rotation.X);
            RotationMatrix_X.m[2, 2] = (float)Math.Cos(rotation.X);

            RotationMatrix_Y.m[0, 0] = (float)Math.Cos(rotation.Y);
            RotationMatrix_Y.m[0, 2] = -(float)Math.Sin(rotation.Y);
            RotationMatrix_Y.m[1, 1] = 1;
            RotationMatrix_Y.m[2, 0] = (float)Math.Sin(rotation.Y);
            RotationMatrix_Y.m[2, 2] = (float)Math.Cos(rotation.Y);

            RotationMatrix_Z.m[0, 0] = (float)Math.Cos(rotation.Z);
            RotationMatrix_Z.m[0, 1] = (float)Math.Sin(rotation.Z);
            RotationMatrix_Z.m[1, 0] = -(float)Math.Sin(rotation.Z);
            RotationMatrix_Z.m[1, 1] = (float)Math.Cos(rotation.Z);
            RotationMatrix_Z.m[2, 2] = 1;
        }

        /// <summary>
        /// Resets rotation, rturnign the mesh into its original position
        /// </summary>
        public void ResetRotation()
        {
            rotation = new Vector3(0, 0, 0);
        }

        /// <summary>
        /// Changes the current rotation of the current object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void ChangeRotation(float x, float y, float z)
        {
            rotation = new Vector3(rotation.X + x, rotation.Y + y, rotation.Z + z);
        }

        /// <summary>
        /// Projects a coordinate from a 3d space onto a 2d display screen using the specified projection type
        /// </summary>
        /// <param name="original">Original 3d coordinate</param>
        /// <param name="projectionMatrix">Type of projection</param>
        /// <param name="enableRotation">allow projecton roatation</param>
        /// <returns>Returns a new projected coordinate</returns>
        public Vector3 ProjectVector(Vector3 original, Matrix projectionMatrix, bool enableRotation)
        {
            Vector3 projected = original;

            if (enableRotation)
            {
                projected = MultiplyMatrix(projected, RotationMatrix_X);
                projected = MultiplyMatrix(projected, RotationMatrix_Y);
                projected = MultiplyMatrix(projected, RotationMatrix_Z);
            }

            projected = MultiplyMatrix(projected, projectionMatrix);

            return projected;
        }

        /// <summary>
        /// Projects a coordinate from a 3d space onto a 2d display screen using orthographic projection type
        /// </summary>
        /// <param name="original">Original 3d coordinate</param>
        /// <returns>Returns a new projected coordinate</returns>
        public Vector3 ProjectVector(Vector3 original)
        {
            Vector3 projected = original;

            projected = MultiplyMatrix(projected, OrthogrphicProjection);

            projected = MultiplyMatrix(projected, RotationMatrix_X);
            projected = MultiplyMatrix(projected, RotationMatrix_Y);
            projected = MultiplyMatrix(projected, RotationMatrix_Z);

            return projected;
        }
    }
}

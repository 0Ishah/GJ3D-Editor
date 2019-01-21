/*   Project Name: GJ3D Editor
 *   File Name: frmMain.cs
 *   Author: Ilya Fedin
 *   Date Created: Fri, Jan 18, 2018
 *   Date Modeified: Sun, Jan 10, 2018
 *   Description: Its 1:24, and I still have to do my English ISU. Kill me please
 *   Actual Description: GJ3 Editor is a unique lightweight 3D model editor that allow user to easily create, view and edit 3d models
 *   File Description: Main program file holding and running most of the controls
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GJ3Editor
{
    public partial class frmMain : Form
    {
        public static PictureBox canvas; //Picture box is used a display fro drawing all of the elements
        public static Painter painter;
        
        public Mesh CurrentMesh; //Mesh that is currently being displayed

        private bool isAutorotating;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitializeCanvas();
            painter = new Painter();
            //Shifthig the origin of the coordinates to the center of the screen
            painter.g.TranslateTransform(canvas.Width / 2, canvas.Height / 2);
            KeyPreview = true;
            InitializeTimer(RotationTimer);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            painter.Reset();
            CurrentMesh = new Mesh();
            painter.Reset();
            painter.ResetRotation();
            Draw();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            CurrentMesh = Data.Cube;
            painter.Reset();
            painter.ResetRotation();
            Draw();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            CurrentMesh = Data.Pyramid;
            painter.Reset();
            painter.ResetRotation();
            Draw();

        }

        private void btnAutorotate_Click(object sender, EventArgs e)
        {
            if (chbRotationX.Checked && chbRotationY.Checked && chbRotationZ.Checked)
            {
                chbRotationX.Checked = false;
                chbRotationY.Checked = false;
                chbRotationZ.Checked = false;
            }
            if (!isAutorotating && (chbRotationX.Checked || chbRotationY.Checked || chbRotationZ.Checked))
            {
                isAutorotating = true;
                painter.autorotationAxis = new Vector3i(Convert.ToInt32(chbRotationX.Checked), Convert.ToInt32(chbRotationY.Checked), Convert.ToInt32(chbRotationZ.Checked));
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            painter.ResetRotation();
            Draw();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (chbEditMode.Checked)
            {
                if (e.KeyCode == Keys.D && chbEditMode.Checked)
                {
                    CurrentMesh.GetVertices()[painter.selectedVertex] += new Vector3((float)NumEditInterval.Value, 0, 0);
                }
                else if (e.KeyCode == Keys.A && chbEditMode.Checked)
                {
                    CurrentMesh.GetVertices()[painter.selectedVertex] -= new Vector3((float)NumEditInterval.Value, 0, 0);
                }
                else if (e.KeyCode == Keys.W && chbEditMode.Checked)
                {
                    CurrentMesh.GetVertices()[painter.selectedVertex] += new Vector3(0, (float)NumEditInterval.Value, 0);
                }
                else if (e.KeyCode == Keys.S && chbEditMode.Checked)
                {
                    CurrentMesh.GetVertices()[painter.selectedVertex] -= new Vector3(0, (float)NumEditInterval.Value, 0);
                }
                else if (e.KeyCode == Keys.Q && chbEditMode.Checked)
                {
                    CurrentMesh.GetVertices()[painter.selectedVertex] -= new Vector3(0, 0, (float)NumEditInterval.Value);
                }
                else if (e.KeyCode == Keys.E && chbEditMode.Checked)
                {
                    CurrentMesh.GetVertices()[painter.selectedVertex] += new Vector3(0, 0, (float)NumEditInterval.Value);
                }
            }
            else
            {
                if (e.KeyCode == Keys.D)
                {
                    painter.ChangeRotation(0, (float)numRotationInterval.Value, 0);
                }
                else if (e.KeyCode == Keys.A)
                {
                    painter.ChangeRotation(0, -(float)numRotationInterval.Value, 0);
                }
                else if (e.KeyCode == Keys.W)
                {
                    painter.ChangeRotation((float)numRotationInterval.Value, 0, 0);
                }
                else if (e.KeyCode == Keys.S)
                {
                    painter.ChangeRotation(-(float)numRotationInterval.Value, 0, 0);
                }
                else if (e.KeyCode == Keys.Q)
                {
                    painter.ChangeRotation(0, 0, (float)numRotationInterval.Value);
                }
                else if (e.KeyCode == Keys.E)
                {
                    painter.ChangeRotation(0, 0, -(float)numRotationInterval.Value);
                }
            }
            

            if (CurrentMesh != null)
            {
                Draw();
            }
            lblEditInterval.Focus();
            
        }

        private void InitializeCanvas()
        {
            canvas = new PictureBox();
            canvas.Paint += canvas_Paint;
            canvas.Click += canvas_Click;
            Controls.Add(canvas);
            canvas.Location = new Point(0, 40);
            canvas.Size = new Size(1000, 620);
            canvas.BackColor = Color.Azure;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("called paint handler");
        }

        private void canvas_Click(object sender, EventArgs e)
        {
            MouseEventArgs m = (MouseEventArgs)e;
            Vector3 mousePos = NormalizeMouse(new Vector3(m.X, m.Y, 0));

            Console.WriteLine("mouse click at " + mousePos.X + "," + mousePos.Y);

            if (CurrentMesh != null)
            {
                Console.WriteLine(painter.ProjectVector(CurrentMesh.GetVertices()[0]).X);
                Console.WriteLine(painter.ProjectVector(CurrentMesh.GetVertices()[0]).Y);

                for (int i = 0; i < CurrentMesh.GetVertices().Count; i++)
                {
                    Console.WriteLine(i + " at " + painter.ProjectVector(CurrentMesh.GetVertices()[i]).X + "," + painter.ProjectVector(CurrentMesh.GetVertices()[i]).Y);
                    if (mousePos.X + 10 > painter.ProjectVector(CurrentMesh.GetVertices()[i]).X &&
                        mousePos.X - 10 < painter.ProjectVector(CurrentMesh.GetVertices()[i]).X &&
                        mousePos.Y + 10 > painter.ProjectVector(CurrentMesh.GetVertices()[i]).Y &&
                        mousePos.Y - 10 < painter.ProjectVector(CurrentMesh.GetVertices()[i]).Y)
                    {
                        painter.selectedVertex = i;
                        painter.Reset();
                        Draw();
                        painter.DrawAxisArrows(painter.ProjectVector(CurrentMesh.GetVertices()[i]));
                        Console.WriteLine(i + " selected");
                        break;
                    }
                }
            }
        }

        private void RotationTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentMesh != null && isAutorotating)
            {
                Draw();
                painter.time += 0.1f;
            }
        }

        private void Draw()
        {
            painter.Reset();
            if (CurrentMesh != null)
            {
                painter.DrawMesh(CurrentMesh, Color.Red);
                painter.DrawAxisArrows(painter.ProjectVector(CurrentMesh.GetVertices()[painter.selectedVertex]));
            }
        }

        private void InitializeTimer(Timer timer)
        {
            timer.Interval = 100;
            //timer.Enabled = true;
        }

        public Vector3 NormalizeMouse(Vector3 original)
        {
            Vector3 result = original;

            result.X = original.X - canvas.Width / 2;

            if (original.Y < canvas.Height / 2)
            {
                result.Y = canvas.Height / 2 - original.Y;
            }
            else
            {
                result.Y = -(original.Y - canvas.Height / 2);
            }

            return result;
        }
    }
}

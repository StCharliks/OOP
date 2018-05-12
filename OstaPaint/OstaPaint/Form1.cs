using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using OstaPaint.Geometry;
using OstFigures;
using OstaPaint.Controls;
namespace OstaPaint
{
    public partial class Form1 : Form
    {
        private serializerJSON serializer = serializerJSON.getInstance();
        private Bitmap canvas = null;
        private ShapeFactory figuresFactory;
        private List<Shape> figures = new List<Shape>();
        private List<Shape> back = new List<Shape>();
        private enum Items{Line, Square, Rectangle, Ellipce, Circle, Triangle };
        private Items Item = Items.Line;
        private bool editorMode = false;
        private Point offset;
        private PlaginConnection Plagins = new PlaginConnection();

        bool isDraw = false;
        bool isMove = false;

        Shape shape;
        Point[] shapePoints = new Point[2];
        Graphics drawField;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            figuresFactory = null;

            canvas = new Bitmap(pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height);
            pictureBox1.Image = canvas;
            drawField = Graphics.FromImage(canvas);
            drawField.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pen = new Pen(Color.Black, 1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (editorMode && (e.Button == MouseButtons.Left)) {
                shape.First = figures.Last().First;
                figures.Remove(figures.Last());
                RefreshCanvas();
                pictureBox1.Invalidate();
                pictureBox1.Update();
                shapePoints[1] = e.Location;
                isDraw = true;
                return;
            }

            if (editorMode && (e.Button == MouseButtons.Right))
            {
                isMove = true;
                shape.First = figures.Last().First;
                figures.Remove(figures.Last());
                RefreshCanvas();
                pictureBox1.Invalidate();
                pictureBox1.Update();
                offset.X = e.X - shape.First.X;
                offset.Y = e.Y - shape.First.Y;

                shapePoints[0] = new Point(shape.First.X + offset.X, shape.First.Y + offset.Y);
                shapePoints[1] = new Point(shape.Last.X + offset.X, shape.Last.Y + offset.Y);
                isDraw = true;
            }
            else { 
                isDraw = true;
                shapePoints[0] = e.Location;
                if (figuresFactory != null)
                    shape = figuresFactory.Create();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (shape == null)
            {
                return;
            }

            if (isDraw)
            {
                shape.First = shapePoints[0];
                shape.Last = shapePoints[1];
                shape.color = pen.Color;
                shape.Width = (int)pen.Width;
                shape.tempDraw(sender, e);     
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            pen.Color = colorDialog1.Color;

            if (editorMode)
            {
                shape.color = pen.Color;
                figures.Remove(figures.Last());
                figures.Add(shape);
                RefreshCanvas();
                pictureBox1.Invalidate();
                pictureBox1.Update();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (float)numericUpDown1.Value;

            if (editorMode)
            {
                shape.Width = (int)pen.Width;
                figures.Remove(figures.Last());
                figures.Add(shape);
                RefreshCanvas();
                pictureBox1.Invalidate();
                pictureBox1.Update();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = string.Format("X: {0} Y: {1}", e.X, e.Y);
            if (isDraw && !editorMode && (shape != null))
            {
                shapePoints[1] = e.Location;
                pictureBox1.Invalidate();
                pictureBox1.Update();
            }

            if (editorMode && (shape != null))
            {
                if (isMove)
                {
                    offset.X = e.X - shapePoints[0].X;
                    offset.Y = e.Y - shapePoints[0].Y;

                    shapePoints[0] = new Point(shapePoints[0].X + offset.X, shapePoints[0].Y + offset.Y);
                    shapePoints[1] = new Point(shapePoints[1].X + offset.X, shapePoints[1].Y + offset.Y);

                    pictureBox1.Invalidate();
                    pictureBox1.Update();
                    return;
                }

                shapePoints[1] = e.Location;
                pictureBox1.Invalidate();
                pictureBox1.Update();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            drawField.Clear(Color.White);
            pictureBox1.Invalidate();
            back.Clear();
            figures.Clear();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (shape == null)
            {
                return;
            }

            if (isDraw && !editorMode)
            {
                shape.draw(drawField);
                pictureBox1.Image = canvas;
                figures.Add(shape);
                isDraw = false;
                return;
            }

            if (editorMode)
            {
                shape.draw(drawField);
                pictureBox1.Image = canvas;
                figures.Add(shape);
                isDraw = false;
                if (isMove)
                {
                    isMove = false;
                }
                return;
            }
        }

        private void RefreshCanvas()
        {
            drawField = Graphics.FromImage(canvas);
            drawField.Clear(Color.White);

            foreach (Shape fig in figures)
            {
                fig.draw(drawField);
            }
        }

        private void toBack_Click(object sender, EventArgs e)
        {
            if (figures.Count() > 0)
            {
                back.Add(figures.Last());
                figures.Remove(figures.Last());
                pictureBox1.Invalidate();
                RefreshCanvas();
                if (figures.Count() == 0)
                    shape = null;
                else
                {
                    shape = figures.Last();
                    pen.Width = shape.Width;
                    pen.Color = shape.color;
                }
            }
        }

        private void toForward_Click(object sender, EventArgs e)
        {
            if (back.Count() > 0)
            {
                figures.Add(back.Last());
                back.Remove(back.Last());
                pictureBox1.Invalidate();
                RefreshCanvas();
                shape = figures.Last();
                pen.Width = shape.Width;
                pen.Color = shape.color;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Сохранить";
            dialog.DefaultExt = "ost";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                serializer = serializerJSON.getInstance(dialog.FileName);
                serializer.serialise(figures);
            }
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            figuresFactory = new LineFactory();
        }

        private void SquareButton_Click(object sender, EventArgs e)
        {
            figuresFactory = new SquareFactory();
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            figuresFactory = new RectangleFactory();
        }

        private void EllipceButton_Click(object sender, EventArgs e)
        {
            figuresFactory = new EllipseFactory();
        }

        private void triangleButton_Click(object sender, EventArgs e)
        {
            figuresFactory = new TriangleFactory();
        }

        private void CircleButton_Click(object sender, EventArgs e)
        {
            figuresFactory = new CircleFactory();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "OST файлы (*.ost) | *.ost";
            dialog.Title = "Открыть";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                drawField.Clear(Color.White);
                pictureBox1.Invalidate();
                back.Clear();
                figures.Clear();

                serializer = serializerJSON.getInstance(dialog.FileName);
                figures = serializer.deserialize();
            }

            foreach (Shape figure in figures)
            {
                figure.draw(drawField);
            }

            shape = figures.Last();
        }

        private void choseModeButton_Click(object sender, EventArgs e)
        {
            if (shape == null)
            {
                return;
            }
            editorMode = !editorMode;

            if (editorMode)
            {
                choseModeButton.Text = "Рисовать";
            }
            else
            {
                choseModeButton.Text = "Редактировать";
            }
        }

        private void addPlagin_button_Click(object sender, EventArgs e)
        {
            Plagins.getDllPath();
            Plagins.LoadPlugin(Plagins.dllPath);

            foreach (Type t in Plagins.Plagins)
            {
                if (!PluginBox.Items.Contains(t.ToString()))
                {
                    PluginBox.Items.Add(t.ToString());
                    serializer.KnownTypes = t;
                }
            }
        }

        private void PluginBox_Click(object sender, EventArgs e)
        {
            shape = Plagins.CreateInstance(PluginBox.SelectedIndex);
            figuresFactory = null;
        }
    }
}

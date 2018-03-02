using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MathMorphKernelEditor : Form
    {
        private int _width;
        private int _height;

        private int[,] _matrix;

        private Form1 _form;

        private int _formWidth = 0, _formHeight = 0;

        public MathMorphKernelEditor(int w, int h, int[,] k, Form1 form)
        {
            InitializeComponent();
            _width = w;
            _height = h;
            _matrix = k;
            _form = form;
            UpdateGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _width = Int32.Parse(widthTextBox.Text);
            _height = Int32.Parse(heightTextBox.Text);

            _matrix = new int[_width, _height];

            for (int x = 0; x < _width; x++)
            for (int y = 0; y < _height; y++)
                _matrix[x, y] = 1;

            UpdateGridView();
        }

        private void UpdateGridView()
        {
            dataGridView1.ColumnCount = _width;
            dataGridView1.RowCount = _height;

            widthTextBox.Text = _width.ToString();
            heightTextBox.Text = _height.ToString();

            for (int x = 0; x < _width; x++)
            for (int y = 0; y < _height; y++)
                dataGridView1.Rows[y].Cells[x].Value = _matrix[x, y];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _width = Int32.Parse(widthTextBox.Text);
            _height = Int32.Parse(heightTextBox.Text);

            _matrix = new int[_width, _height];

            for (int x = 0; x < _width; x++)
            for (int y = 0; y < _height; y++)
                _matrix[x, y] = Int32.Parse(dataGridView1.Rows[y].Cells[x].Value.ToString());

            _form.UpdateKernel(_width, _height, _matrix);
            this.Close();
        }

        private void MathMorphKernelEditor_Load(object sender, EventArgs e)
        {
            _formWidth = Width;
            _formHeight = Height;
        }

        private void MathMorphKernelEditor_Resize(object sender, EventArgs e)
        {

            if (_formHeight != 0 && _formWidth != 0)
            {
                int deltaX = Width - _formWidth;
                int deltaY = Height - _formHeight;
                dataGridView1.Width += deltaX;
                dataGridView1.Height += deltaY;

                _formWidth = Width;
                _formHeight = Height;
            }

        }
    }
}
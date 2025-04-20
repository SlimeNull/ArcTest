namespace ArcTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            arcRenderer1.Start = 0;
            arcRenderer1.CircleThickness = 10;
            arcRenderer1.EnabledRoundedEndPoint = true;
            //arcRenderer1.Fill = Brushes.Pink;
            //arcRenderer1.Stroke = new Pen(Brushes.Black, 3);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            arcRenderer1.End = trackBar1.Value / -180f * MathF.PI;
        }
    }
}

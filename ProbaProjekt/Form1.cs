namespace VGraphicsX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CanvasPanel canvasPanel = new CanvasPanel();
            canvasPanel.AutoSize = true;
            canvasPanel.Width = 1000;
            canvasPanel.Height = 1000;
            canvasPanel.RajzolKor(10, 10, 10);
            canvasPanel.RajzolKor(40, 20, 10);
            canvasPanel.RajzolKor(60, 30, 20);
            canvasPanel.RajzolKor(100, 80, 20);
            canvasPanel.RajzolKor(100, 80, 1, Color.Azure);


            Controls.Add(canvasPanel);

        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
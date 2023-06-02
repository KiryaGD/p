namespace BoevKirill_Pacman
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        Game f2;
        private void button1_Click(object sender, EventArgs e)
        {
            f2 = new Game();

            Hide();
            f2.ShowDialog();
            
        }
    }
}
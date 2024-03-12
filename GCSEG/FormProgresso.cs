namespace GCSEG
{
    public partial class FormProgresso : Form
    {
        public FormProgresso()
        {
            InitializeComponent();
        }

        private void FormProgresso_Load(object sender, EventArgs e)
        {

        }

        public void StartProgress()
        {
            progressBar1.MarqueeAnimationSpeed = 30;
            Task.Delay(2000).ContinueWith(_ => this.Close(), TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}

namespace GCSEG
{
    public partial class Form2 : Form
    {
        private ParametrosCalculos _parametros;
        public Form2(ParametrosCalculos parametros)
        {
            InitializeComponent();
            _parametros = parametros;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RealizarCalculos();
        }

        private void RealizarCalculos()
        {
            label1.Text = _parametros.ClasseMadeira;

            label2.Text = $"fcok: {_parametros.Fcok / 10:F2} KN/cm²";
            label3.Text = $"ftok: {_parametros.Ftok / 10:F2} KN/cm²";
            label4.Text = $"fvk: {_parametros.Fvk / 10:F2} KN/cm²";
            label5.Text = $"E: {_parametros.E / 10:F2} KN/cm²";
            label6.Text = $"Pa: {_parametros.Pa:F2} KN/cm²";

            label7.Text = $"Kmod1: {_parametros.Kmod1:F2}";

            label8.Text = $"Kmod2:  {_parametros.Kmod2:F2}";

            label9.Text = $"Kmod3:  {_parametros.Kmod3:F2}";
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}

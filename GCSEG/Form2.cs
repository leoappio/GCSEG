using System.Security.Cryptography;

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
            var Kmod = _parametros.Kmod1 * _parametros.Kmod2 * _parametros.Kmod3;
            var gamac = 1.4;
            var gamat = 1.8;
            var gamav = 1.8;


            // Tab 1
            label1.Text = _parametros.ClasseMadeira;

            label2.Text = $"fcok: {_parametros.Fcok / 10:F2} KN/cm²";
            label3.Text = $"ftok: {_parametros.Ftok / 10:F2} KN/cm²";
            label4.Text = $"fvk: {_parametros.Fvk / 10:F2} KN/cm²";
            label5.Text = $"E: {_parametros.E / 10:F2} KN/cm²";
            label6.Text = $"Pa: {_parametros.Pa:F2} KN/cm²";

            label7.Text = $"Kmod1: {_parametros.Kmod1:F2}";

            label8.Text = $"Kmod2:  {_parametros.Kmod2:F2}";

            label9.Text = $"Kmod3:  {_parametros.Kmod3:F2}";


            //Tab 2
            var fcod = ((Kmod * _parametros.Fcok / 10) / gamac);
            var ftod = ((Kmod * _parametros.Ftok / 10) / gamat);
            var fvd = ((Kmod * _parametros.Fvk / 10) / gamav);
            var Eef = ((_parametros.E / 10) * Kmod);

            label10.Text = $"fcod: {fcod:F2} KN/cm²";
            label11.Text = $"ftod: {ftod:F2} KN/cm²";
            label12.Text = $"fvd: {fvd:F2} KN/cm²";
            label13.Text = $"Eef: {Eef:F2} KN/cm²";
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }
    }
}

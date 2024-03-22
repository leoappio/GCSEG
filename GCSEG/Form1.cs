using System.Globalization;

namespace GCSEG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox3.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox4.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox5.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox6.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox7.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox8.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox9.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox10.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox11.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox12.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox13.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox14.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox15.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox16.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox17.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox18.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox19.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<bool> resultadosConversao = new List<bool>();

            string classeMadeira;
            double fcok, ftok, fvk, eparam, pa, kmod1, kmod2, kmod3, l, dn,
                tsb, tsh, tmb, tmh, trb, trh, mb, mh, mfb, mfh, nch, fu, fck, comprimentoTotal;

            classeMadeira = comboBox1.Text;

            var valoresCaracteristicos = GetValoresCaracteristicos(classeMadeira);

            resultadosConversao.Add(double.TryParse(textBox1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out kmod1));
            resultadosConversao.Add(double.TryParse(textBox2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out kmod2));
            resultadosConversao.Add(double.TryParse(textBox3.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out kmod3));
            resultadosConversao.Add(double.TryParse(textBox4.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out l));
            resultadosConversao.Add(double.TryParse(textBox5.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out dn));

            resultadosConversao.Add(double.TryParse(textBox7.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out tsb));
            resultadosConversao.Add(double.TryParse(textBox6.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out tsh));
            resultadosConversao.Add(double.TryParse(textBox9.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out tmb));
            resultadosConversao.Add(double.TryParse(textBox8.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out tmh));
            resultadosConversao.Add(double.TryParse(textBox11.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out trb));
            resultadosConversao.Add(double.TryParse(textBox10.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out trh));
            resultadosConversao.Add(double.TryParse(textBox13.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out mb));
            resultadosConversao.Add(double.TryParse(textBox12.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out mh));
            resultadosConversao.Add(double.TryParse(textBox15.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out mfb));
            resultadosConversao.Add(double.TryParse(textBox14.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out mfh));

            resultadosConversao.Add(double.TryParse(textBox16.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out nch));
            resultadosConversao.Add(double.TryParse(textBox17.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out fu));
            resultadosConversao.Add(double.TryParse(textBox18.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out fck));
            resultadosConversao.Add(double.TryParse(textBox19.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out comprimentoTotal));

            if (resultadosConversao.All(conversaoSucedida => conversaoSucedida))
            {
                var parametros = new ParametrosCalculos
                {
                    ClasseMadeira = classeMadeira,
                    Fcok = valoresCaracteristicos.Fcok,
                    Ftok = valoresCaracteristicos.Ftok,
                    Fvk = valoresCaracteristicos.Fvk,
                    E = valoresCaracteristicos.E,
                    Pa = valoresCaracteristicos.Pa,
                    Kmod1 = kmod1,
                    Kmod2 = kmod2,
                    Kmod3 = kmod3,
                    L = l,
                    Dn = dn,
                    Tsb = tsb,
                    Tsh = tsh,
                    Tmb = tmb,
                    Tmh = tmh,
                    Trb = trb,
                    Trh = trh,
                    Mb = mb,
                    Mh = mh,
                    Mfb = mfb,
                    Mfh = mfh,
                    Nch = nch,
                    Fu = fu,
                    Fck = fck,
                    ComprimentoTotal = comprimentoTotal
                };

                await ShowProgressFormAsync();

                var formCalculos = new Form2(parametros);
                formCalculos.Show();
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
            }
        }

        private ValoresCaracteristicos GetValoresCaracteristicos(string tipoMadeira)
        {
            ValoresCaracteristicos valores = new ValoresCaracteristicos();

            switch (tipoMadeira)
            {
                case "C-20":
                    valores.Fcok = 20;
                    valores.Fvk = 4;
                    valores.E = 3500;
                    valores.Pa = 500;
                    break;
                case "C-25":
                    valores.Fcok = 25;
                    valores.Fvk = 5;
                    valores.E = 8500;
                    valores.Pa = 550;
                    break;
                case "C-30":
                    valores.Fcok = 30;
                    valores.Fvk = 6;
                    valores.E = 14500;
                    valores.Pa = 600;
                    break;
                case "D-20":
                    valores.Fcok = 20;
                    valores.Fvk = 4;
                    valores.E = 9500;
                    valores.Pa = 650;
                    break;
                case "D-30":
                    valores.Fcok = 30;
                    valores.Fvk = 5;
                    valores.E = 14500;
                    valores.Pa = 800;
                    break;
                case "D-40":
                    valores.Fcok = 40;
                    valores.Fvk = 6;
                    valores.E = 19500;
                    valores.Pa = 950;
                    break;
                case "D-60":
                    valores.Fcok = 60;
                    valores.Fvk = 8;
                    valores.E = 24500;
                    valores.Pa = 1000;
                    break;
                default:
                    throw new ArgumentException("Tipo de madeira não reconhecido.");
            }

            valores.Ftok = valores.Fcok / 0.77;

            return valores;
        }

        private Task ShowProgressFormAsync()
        {
            var tcs = new TaskCompletionSource<bool>();
            var progressForm = new FormProgresso();

            progressForm.FormClosed += (sender, args) => tcs.SetResult(true);
            progressForm.Show();
            progressForm.StartProgress();

            return tcs.Task;
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                TextBox textBox = sender as TextBox;
                if (textBox != null && textBox.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
        }

    }
}

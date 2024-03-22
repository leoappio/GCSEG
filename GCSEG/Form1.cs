namespace GCSEG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Rows.Add("C-20", "20", "4", "3500", "400", "500");
            dataGridView1.Rows.Add("C-25", "25", "5", "8500", "450", "550");
            dataGridView1.Rows.Add("C-30", "30", "6", "14500", "500", "600");
            dataGridView1.Rows.Add("D-20", "20", "4", "9500", "500", "650");
            dataGridView1.Rows.Add("D-30", "30", "5", "14500", "650", "800");
            dataGridView1.Rows.Add("D-40", "40", "6", "19500", "750", "950");
            dataGridView1.Rows.Add("D-60", "50", "8", "24500", "800", "1000");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<bool> resultadosConversao = new List<bool>();

            string classeMadeira;
            double fcok, ftok, fvk, eparam, pa, kmod1, kmod2, kmod3, l, dn,
                tsb, tsh, tmb, tmh, trb, trh, mb, mh, mfb, mfh, nch, fu, fck, comprimentoTotal;

            classeMadeira = comboBox1.Text;

            var valoresCaracteristicos = GetValoresCaracteristicos(classeMadeira);

            resultadosConversao.Add(double.TryParse(textBox1.Text, out kmod1));
            resultadosConversao.Add(double.TryParse(textBox2.Text, out kmod2));
            resultadosConversao.Add(double.TryParse(textBox3.Text, out kmod3));
            resultadosConversao.Add(double.TryParse(textBox4.Text, out l));
            resultadosConversao.Add(double.TryParse(textBox5.Text, out dn));

            resultadosConversao.Add(double.TryParse(textBox7.Text, out tsb));
            resultadosConversao.Add(double.TryParse(textBox6.Text, out tsh));
            resultadosConversao.Add(double.TryParse(textBox9.Text, out tmb));
            resultadosConversao.Add(double.TryParse(textBox8.Text, out tmh));
            resultadosConversao.Add(double.TryParse(textBox11.Text, out trb));
            resultadosConversao.Add(double.TryParse(textBox10.Text, out trh));
            resultadosConversao.Add(double.TryParse(textBox13.Text, out mb));
            resultadosConversao.Add(double.TryParse(textBox12.Text, out mh));
            resultadosConversao.Add(double.TryParse(textBox15.Text, out mfb));
            resultadosConversao.Add(double.TryParse(textBox14.Text, out mfh));

            resultadosConversao.Add(double.TryParse(textBox16.Text, out nch));
            resultadosConversao.Add(double.TryParse(textBox17.Text, out fu));
            resultadosConversao.Add(double.TryParse(textBox18.Text, out fck));
            resultadosConversao.Add(double.TryParse(textBox19.Text, out comprimentoTotal));

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
    }
}

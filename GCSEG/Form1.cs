namespace GCSEG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<bool> resultadosConversao = new List<bool>();

            string classeMadeira;
            double fcok, ftok, fvk, eparam, pa, kmod1, kmod2, kmod3;

            classeMadeira = comboBox1.Text;

            var valoresCaracteristicos = GetValoresCaracteristicos(classeMadeira);

            resultadosConversao.Add(double.TryParse(textBox1.Text, out kmod1));
            resultadosConversao.Add(double.TryParse(textBox2.Text, out kmod2));
            resultadosConversao.Add(double.TryParse(textBox3.Text, out kmod3));

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
                    Kmod1= kmod1,
                    Kmod2 = kmod2,
                    Kmod3 = kmod3,
                };

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
                case "C-25 - Pinus Elliotti, Araucária":
                    valores.Fcok = 25;
                    valores.Fvk = 5;
                    valores.E = 8500;
                    valores.Pa = 550;
                    break;
                case "C-30 - Pinus Taeda":
                    valores.Fcok = 30;
                    valores.Fvk = 6;
                    valores.E = 14500;
                    valores.Pa = 600;
                    break;
                case "D-20 - Eucalipto grandis":
                    valores.Fcok = 20;
                    valores.Fvk = 4;
                    valores.E = 9500;
                    valores.Pa = 650;
                    break;
                case "D-30 - Eucalipto saligna, Eucalipto tereticornis":
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
    }
}

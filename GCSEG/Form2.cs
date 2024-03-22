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
            tabControl1.TabPages.Remove(tabPage7);
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

            var Vts = (0.009 * 1 * _parametros.L) / 2;
            var Vtm = (0.0066 * 1 * _parametros.L) / 2;
            var Vr = (0.0022 * 1 * _parametros.L) / 2;

            var Mts = (0.009 * 1 * Math.Pow(_parametros.L, 2)) / 8;
            var Mtm = (0.0066 * 1 * Math.Pow(_parametros.L, 2)) / 8;
            var Mr = (0.0022 * 1 * Math.Pow(_parametros.L, 2)) / 8;

            var Vm = Math.Abs(-(0.93333 * Vr) - (0.44445 * Vtm));
            var Mm = Math.Abs(+(55 * Vr) - (Vm * 62.5));
            var va = Math.Abs((0.0667 * Vr) + (0.55555 * Vtm) + (Vts));

            double constante = (_parametros.Dn / 112.5);

            double tgrad = Math.Atan(constante);

            double An = (tgrad * 57.2958);

            double Ncmf = va / (Math.Sin(tgrad));

            label10.Text = $"fcod: {fcod:F2} KN/cm²";
            label11.Text = $"ftod: {ftod:F2} KN/cm²";
            label12.Text = $"fvd: {fvd:F2} KN/cm²";
            label13.Text = $"Eef: {Eef:F2} KN/cm²";

            label17.Text = $"Distância efetiva dos montantes: {_parametros.L:F2}cm";

            label21.Text = $"Cortante máximo na travessa superior: {Vts:F2}KN";
            label22.Text = $"Momento máximo na travessa superior: {Mts:F2}KN*cm";

            label23.Text = $"Cortante máximo na travessa media: {Vtm:F2}KN";
            label24.Text = $"Momento máximo na travessa media: {Mtm:F2}KN*cm";

            label25.Text = $"Cortante máximo no rodapé: {Vr:F2}KN";
            label26.Text = $"Momento máximo no rodapé: {Mr:F2}KN*cm";


            label27.Text = $"Angulo da mão francesa: {An:F2} graus";
            label28.Text = $"Esforço de tração na mão francesa: {Ncmf:F2}KN";


            label29.Text = $"Cortante máximo no montante: {Vm:F2}KN";
            label30.Text = $"Momento máximo no montante: {Mm:F2}KN*cm";

            //Tab3
            var Wts = _parametros.Tsb * Math.Pow(_parametros.Tsh, 2) / 6;
            var Wtm = (_parametros.Tmb * Math.Pow(_parametros.Tmh, 2)) / 6;
            var Wr = (_parametros.Trb * Math.Pow(_parametros.Trh, 2)) / 6;
            var Wmo = (_parametros.Mb * Math.Pow(_parametros.Mh, 2)) / 6;
            var Wmf = (_parametros.Mfb * Math.Pow(_parametros.Mfh, 2)) / 6;

            var Ats = _parametros.Tsb * _parametros.Tsh;
            var Atm = _parametros.Tmb * _parametros.Tmh;
            var Ar = _parametros.Trb * _parametros.Trh;
            var Amo = _parametros.Mb * _parametros.Mh;
            var Amf = _parametros.Mfb * _parametros.Mfh;

            var Tcts = -(Mts / Wts);
            var Ttts = (Mts / Wts);
            var Tvts = (3 / 2) * (Vts / Ats);
            var Tctm = -(Mtm / Wtm);
            var Tttm = (Mtm / Wtm);
            var Tvtm = (3 / 2) * (Vtm / Atm);
            var Tcr = -(Mr / Wr);
            var Ttr = (Mr / Wr);
            var Tvr = (3 / 2) * (Vr / Ar);
            var Tcmo = -(Mm / Wmo);
            var Ttmo = (Mm / Wmo);
            var Tvmo = (3 / 2) * (Vm / Amo);
            var Ttmf = Ncmf / Amf;


            label31.Text = $"Área travessa superior: {Ats:F2}cm²";
            label32.Text = $"Área travessa média: {Atm:F2}cm²";
            label33.Text = $"Área rodapé: {Ar:F2}cm²";
            label34.Text = $"Área montante: {Amo:F2}cm²";
            label35.Text = $"Área mão francesa: {Amf:F2}cm²";

            label40.Text = $"Modulo elastico travessa superior: {Wts:F2}cm²";
            label39.Text = $"Modulo elastico travessa média: {Wtm:F2}cm²";
            label38.Text = $"Modulo elastico rodapé: {Wr:F2}cm²";
            label37.Text = $"Modulo elastico montante: {Wmo:F2}cm²";
            label36.Text = $"Modulo elastico mão francesa: {Wmf:F2}cm²";

            label50.Text = $"Tsd travessa superior (Compressão): {Tcts:F2}KN/cm²";
            label49.Text = $"Tsd travessa superior (Tração): {Ttts:F2}KN/cm²";
            label48.Text = $"Tsd travessa média (Compressão): {Tctm:F2}KN/cm²";
            label47.Text = $"Tsd travessa média (Tração): {Tttm:F2}KN/cm²";
            label46.Text = $"Tsd rodapé (Compressão): {Tcr:F2}KN/cm²";
            label45.Text = $"Tsd rodapé (Tração): {Ttr:F2}KN/cm²";
            label44.Text = $"Tsd montante (Compressão): {Tcmo:F2}KN/cm²";
            label43.Text = $"Tsd montante (Tração): {Ttmo:F2}KN/cm²";

            label42.Text = $"Nsd mão francesa: {Ttmf:F2}KN/cm²";

            label41.Text = $"Vsd travessa superior: {Tvts:F4}KN/cm²";
            label53.Text = $"Vsd travessa média: {Tvtm:F4}KN/cm²";
            label52.Text = $"Vsd rodapé: {Tvr:F4}KN/cm²";
            label51.Text = $"Vsd montante: {Tvmo:F4}KN/cm²";

            //Tab4

            label54.Text = $"Compressão na travessa superior ";
            var elu1 = (int)(-Tcts / fcod * 100);
            progressBar1.Value = elu1;
            label55.Text = $"Tração na travessa superior";
            var elu2 = (int)((Ttts / ftod) * 100);
            textProgressBar1.Value = elu2;
            label56.Text = $"Cisalhamento na travessa superior";
            var elu3 = (int)((Tvts / fvd) * 100);
            textProgressBar2.Value = elu3;


            label59.Text = $"Compressão na travessa média";
            var elu4 = (int)((-Tctm / fcod) * 100);
            textProgressBar3.Value = elu4;
            label58.Text = $"Tração na travessa média";
            var elu5 = (int)((Tttm / ftod) * 100);
            textProgressBar4.Value = elu5;
            label57.Text = $"Cisalhamento na travessa média";
            var elu6 = (int)((Tvtm / fvd) * 100);
            textProgressBar5.Value = elu6;

            label62.Text = $"Compressão no rodapé";
            var elu7 = (int)((-Tcr / fcod) * 100);
            textProgressBar6.Value = elu7;
            label61.Text = $"Tração no rodapé";
            var elu8 = (int)((Ttr / ftod) * 100);
            textProgressBar7.Value = elu8;
            label60.Text = $"Cisalhamento no rodapé";
            var elu9 = (int)((Tvr / fvd) * 100);
            textProgressBar8.Value = elu9;

            label65.Text = $"Compressão no montante";
            var elu10 = (int)((-Tcmo / fcod) * 100);
            textProgressBar9.Value = elu10;
            label64.Text = $"Tração no montante";
            var elu11 = (int)((Ttmo / ftod) * 100);
            textProgressBar10.Value = elu11;
            label63.Text = $"Cisalhamento no montante";
            var elu12 = (int)((Tvmo / fvd) * 100);
            textProgressBar11.Value = elu12;

            label66.Text = $"Tração na mão francesa";
            var elu13 = (int)((Ttmf / ftod) * 100);
            textProgressBar12.Value = elu13;


            //Tab5
            var U = (5 * 0.009 * Math.Pow(_parametros.L, 4)) / (384 * Eef * ((_parametros.Tsb * Math.Pow(_parametros.Tsh, 3)) / 12));
            label78.Text = $"Deflexão máxima na travessa superior: {U:F3}cm";

            if (elu1 <= 100 &&
                elu2 <= 100 &&
                elu3 <= 100 &&
                elu4 <= 100 &&
                elu5 <= 100 &&
                elu6 <= 100 &&
                elu7 <= 100 &&
                elu8 <= 100 &&
                elu9 <= 100 &&
                elu10 <= 100 &&
                elu11 <= 100 &&
                elu12 <= 100 &&
                elu13 <= 100)
            {
                label72.ForeColor = Color.Green;
                label72.Text = "Dimensionamento bem-sucedido";

                if (U > 7.61)
                {
                    button1.Visible = false;
                }
            }
            else
            {
                label72.ForeColor = Color.Red;
                label72.Text = "Necessário redimensionar";
                button1.Visible = false;
            }

            //Tab6
            var t = Math.Cos(tgrad) * Ncmf;
            var h = Math.Sin(tgrad) * Ncmf;
            var FS = 10.0;

            var tu = t * FS;
            var hu = h * FS;

            var dc = Math.Sqrt((hu) / (0.23 * _parametros.Fu * _parametros.Nch));

            var dt = Math.Sqrt((tu) / (0.44 * _parametros.Fu * _parametros.Nch));

            double Acone = tu / (0.055 * _parametros.Fck);

            double Lc = Math.Sqrt(Acone / 3.14);

            double Dch = 1.5 * Lc;

            label81.Text = $"Fator de segurança aplicado: {FS:F2}";
            label80.Text = $"Força de tração majorada em função do FS: {tu:F2}KN";
            label77.Text = $"Força de cisalhamento majorada em função do FS: {hu:F2}KN";
            label76.Text = $"Limite de resistencia ao escoamento do chumbador: {_parametros.Fu:F2}KN/cm²";
            label75.Text = $"Fck do concreto de ancoragem: {_parametros.Fck:F2}KN/cm²";

            label71.Text = $"Diâmetro do chumbador mínimo pra cisalhamento: {dc:F2}cm";
            label70.Text = $"Diâmetro do chumbador mínimo pra tração: {dt:F2}cm";
            label69.Text = $"Área do cone de ruptura do concreto: {Acone:F2}cm²";
            label68.Text = $"Comprimento de ancoragem mínimo: {Lc:F2}cm";
            label67.Text = $"Espaçamento mínimo entre chumbadores: {Dch:F2}cm";

            //Tab7
            label73.Text = $"Consumo de madeira travessa superior: {(_parametros.ComprimentoTotal):F2} metros de madeira {_parametros.Tsb:F2}X{_parametros.Tsh:F2}";
            label74.Text = $"Consumo de madeira travessa media: {(_parametros.ComprimentoTotal):F2} metros de madeira {_parametros.Tmb:F2}X{_parametros.Tmh:F2}";
            label82.Text = $"Consumo de madeira rodapé: {(_parametros.ComprimentoTotal):F2} metros de madeira {_parametros.Trb:F2}X{_parametros.Trh:F2}";
            label83.Text = $"Consumo de madeira montantes: {((_parametros.ComprimentoTotal / _parametros.L) + 2) * 1.20:F2} metros de madeira {_parametros.Mb:F2}X{_parametros.Mh:F2}";
            label84.Text = $"Consumo de mãos francesas: {((_parametros.ComprimentoTotal / _parametros.L) + 2) * (1.20 / Math.Sin(An)):F2} metros de madeira {_parametros.Mfb:F2} X {_parametros.Mfh:F2}";
            label85.Text = $"Consumo de chumbadores: {Math.Ceiling(((_parametros.ComprimentoTotal / _parametros.L) + 2) * _parametros.Nch):F2} unidades";
            label86.Text = $"Consumo de pregos: {Math.Ceiling(((_parametros.ComprimentoTotal / _parametros.L) + 2) * 13):F2} unidades";

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            tabControl1.TabPages.Insert(6, tabPage7);
            tabControl1.SelectedIndex = 6;
        }
    }
}

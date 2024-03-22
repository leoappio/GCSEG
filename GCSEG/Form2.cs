using System.Globalization;

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

            label2.Text = string.Format(CultureInfo.InvariantCulture, "fcok: {0:F2} KN/cm²", _parametros.Fcok / 10);
            label3.Text = string.Format(CultureInfo.InvariantCulture, "ftok: {0:F2} KN/cm²", _parametros.Ftok / 10);
            label4.Text = string.Format(CultureInfo.InvariantCulture, "fvk: {0:F2} KN/cm²", _parametros.Fvk / 10);
            label5.Text = string.Format(CultureInfo.InvariantCulture, "E: {0:F2} KN/cm²", _parametros.E / 10);
            label6.Text = string.Format(CultureInfo.InvariantCulture, "Pa: {0:F2} KN/cm²", _parametros.Pa);
            label7.Text = string.Format(CultureInfo.InvariantCulture, "Kmod1: {0:F2}", _parametros.Kmod1);
            label8.Text = string.Format(CultureInfo.InvariantCulture, "Kmod2:  {0:F2}", _parametros.Kmod2);
            label9.Text = string.Format(CultureInfo.InvariantCulture, "Kmod3:  {0:F2}", _parametros.Kmod3);


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

            label10.Text = string.Format(CultureInfo.InvariantCulture, "fcod: {0:F2} KN/cm²", fcod);
            label11.Text = string.Format(CultureInfo.InvariantCulture, "ftod: {0:F2} KN/cm²", ftod);
            label12.Text = string.Format(CultureInfo.InvariantCulture, "fvd: {0:F2} KN/cm²", fvd);
            label13.Text = string.Format(CultureInfo.InvariantCulture, "Eef: {0:F2} KN/cm²", Eef);

            label17.Text = string.Format(CultureInfo.InvariantCulture, "Distância efetiva dos montantes: {0:F2}cm", _parametros.L);
            label21.Text = string.Format(CultureInfo.InvariantCulture, "Cortante máximo na travessa superior: {0:F2}KN", Vts);
            label22.Text = string.Format(CultureInfo.InvariantCulture, "Momento máximo na travessa superior: {0:F2}KN*cm", Mts);
            label23.Text = string.Format(CultureInfo.InvariantCulture, "Cortante máximo na travessa media: {0:F2}KN", Vtm);
            label24.Text = string.Format(CultureInfo.InvariantCulture, "Momento máximo na travessa media: {0:F2}KN*cm", Mtm);
            label25.Text = string.Format(CultureInfo.InvariantCulture, "Cortante máximo no rodapé: {0:F2}KN", Vr);
            label26.Text = string.Format(CultureInfo.InvariantCulture, "Momento máximo no rodapé: {0:F2}KN*cm", Mr);
            label27.Text = string.Format(CultureInfo.InvariantCulture, "Angulo da mão francesa: {0:F2} graus", An);
            label28.Text = string.Format(CultureInfo.InvariantCulture, "Esforço de tração na mão francesa: {0:F2}KN", Ncmf);
            label29.Text = string.Format(CultureInfo.InvariantCulture, "Cortante máximo no montante: {0:F2}KN", Vm);
            label30.Text = string.Format(CultureInfo.InvariantCulture, "Momento máximo no montante: {0:F2}KN*cm", Mm);

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


            label31.Text = string.Format(CultureInfo.InvariantCulture, "Área travessa superior: {0:F2}cm²", Ats);
            label32.Text = string.Format(CultureInfo.InvariantCulture, "Área travessa média: {0:F2}cm²", Atm);
            label33.Text = string.Format(CultureInfo.InvariantCulture, "Área rodapé: {0:F2}cm²", Ar);
            label34.Text = string.Format(CultureInfo.InvariantCulture, "Área montante: {0:F2}cm²", Amo);
            label35.Text = string.Format(CultureInfo.InvariantCulture, "Área mão francesa: {0:F2}cm²", Amf);

            label40.Text = string.Format(CultureInfo.InvariantCulture, "Modulo elastico travessa superior: {0:F2}cm³", Wts);
            label39.Text = string.Format(CultureInfo.InvariantCulture, "Modulo elastico travessa média: {0:F2}cm³", Wtm);
            label38.Text = string.Format(CultureInfo.InvariantCulture, "Modulo elastico rodapé: {0:F2}cm³", Wr);
            label37.Text = string.Format(CultureInfo.InvariantCulture, "Modulo elastico montante: {0:F2}cm³", Wmo);
            label36.Text = string.Format(CultureInfo.InvariantCulture, "Modulo elastico mão francesa: {0:F2}cm³", Wmf);

            label50.Text = string.Format(CultureInfo.InvariantCulture, "Tsd travessa superior (Compressão): {0:F2}KN/cm²", Tcts);
            label49.Text = string.Format(CultureInfo.InvariantCulture, "Tsd travessa superior (Tração): {0:F2}KN/cm²", Ttts);
            label48.Text = string.Format(CultureInfo.InvariantCulture, "Tsd travessa média (Compressão): {0:F2}KN/cm²", Tctm);
            label47.Text = string.Format(CultureInfo.InvariantCulture, "Tsd travessa média (Tração): {0:F2}KN/cm²", Tttm);
            label46.Text = string.Format(CultureInfo.InvariantCulture, "Tsd rodapé (Compressão): {0:F2}KN/cm²", Tcr);
            label45.Text = string.Format(CultureInfo.InvariantCulture, "Tsd rodapé (Tração): {0:F2}KN/cm²", Ttr);
            label44.Text = string.Format(CultureInfo.InvariantCulture, "Tsd montante (Compressão): {0:F2}KN/cm²", Tcmo);
            label43.Text = string.Format(CultureInfo.InvariantCulture, "Tsd montante (Tração): {0:F2}KN/cm²", Ttmo);

            label42.Text = string.Format(CultureInfo.InvariantCulture, "Nsd mão francesa: {0:F2}KN/cm²", Ttmf);

            label41.Text = string.Format(CultureInfo.InvariantCulture, "Vsd travessa superior: {0:F4}KN/cm²", Tvts);
            label53.Text = string.Format(CultureInfo.InvariantCulture, "Vsd travessa média: {0:F4}KN/cm²", Tvtm);
            label52.Text = string.Format(CultureInfo.InvariantCulture, "Vsd rodapé: {0:F4}KN/cm²", Tvr);
            label51.Text = string.Format(CultureInfo.InvariantCulture, "Vsd montante: {0:F4}KN/cm²", Tvmo);

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
            label78.Text = string.Format(CultureInfo.InvariantCulture, "Deflexão máxima na travessa superior: {0:F3}cm", U);

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

            label81.Text = string.Format(CultureInfo.InvariantCulture, "Fator de segurança aplicado: {0:F2}", FS);
            label80.Text = string.Format(CultureInfo.InvariantCulture, "Força de tração majorada em função do FS: {0:F2}KN", tu);
            label77.Text = string.Format(CultureInfo.InvariantCulture, "Força de cisalhamento majorada em função do FS: {0:F2}KN", hu);
            label76.Text = string.Format(CultureInfo.InvariantCulture, "Limite de resistencia ao escoamento do chumbador: {0:F2}KN/cm²", _parametros.Fu);
            label75.Text = string.Format(CultureInfo.InvariantCulture, "Fck do concreto de ancoragem: {0:F2}KN/cm²", _parametros.Fck);

            label71.Text = string.Format(CultureInfo.InvariantCulture, "Diâmetro do chumbador mínimo pra cisalhamento: {0:F2}cm", dc);
            label70.Text = string.Format(CultureInfo.InvariantCulture, "Diâmetro do chumbador mínimo pra tração: {0:F2}cm", dt);
            label69.Text = string.Format(CultureInfo.InvariantCulture, "Área do cone de ruptura do concreto: {0:F2}cm²", Acone);
            label68.Text = string.Format(CultureInfo.InvariantCulture, "Comprimento de ancoragem mínimo: {0:F2}cm", Lc);
            label67.Text = string.Format(CultureInfo.InvariantCulture, "Espaçamento mínimo entre chumbadores: {0:F2}cm", Dch);

            // Para Tab7
            label73.Text = string.Format(CultureInfo.InvariantCulture, "Consumo de madeira travessa superior: {0:F2} metros de madeira {1:F2}X{2:F2}", _parametros.ComprimentoTotal, _parametros.Tsb, _parametros.Tsh);
            label74.Text = string.Format(CultureInfo.InvariantCulture, "Consumo de madeira travessa media: {0:F2} metros de madeira {1:F2}X{2:F2}", _parametros.ComprimentoTotal, _parametros.Tmb, _parametros.Tmh);
            label82.Text = string.Format(CultureInfo.InvariantCulture, "Consumo de madeira rodapé: {0:F2} metros de madeira {1:F2}X{2:F2}", _parametros.ComprimentoTotal, _parametros.Trb, _parametros.Trh);
            label83.Text = string.Format(CultureInfo.InvariantCulture, "Consumo de madeira montantes: {0:F2} metros de madeira {1:F2}X{2:F2}", ((_parametros.ComprimentoTotal / _parametros.L) + 2) * 1.20, _parametros.Mb, _parametros.Mh);
            label84.Text = string.Format(CultureInfo.InvariantCulture, "Consumo de mãos francesas: {0:F2} metros de madeira {1:F2} X {2:F2}", ((_parametros.ComprimentoTotal / _parametros.L) + 2) * (1.20 / Math.Sin(An)), _parametros.Mfb, _parametros.Mfh);
            label85.Text = string.Format(CultureInfo.InvariantCulture, "Consumo de chumbadores: {0:F0} unidades", Math.Ceiling(((_parametros.ComprimentoTotal / _parametros.L) + 2) * _parametros.Nch));
            label86.Text = string.Format(CultureInfo.InvariantCulture, "Consumo de pregos: {0:F0} unidades", Math.Ceiling(((_parametros.ComprimentoTotal / _parametros.L) + 2) * 13));
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Visible = false;
            tabControl1.TabPages.Insert(6, tabPage7);
            tabControl1.SelectedIndex = 6;
        }
    }
}

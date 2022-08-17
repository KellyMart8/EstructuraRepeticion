namespace pjControlRegistroParticipantes
{
    public partial class frmParticipates : Form
    {
        int num;
        int cjefe, cOperario, cAdministrativo, cPracticante;
        public frmParticipates()
        {
            InitializeComponent();
            tHora.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Seguro de querer salir?",
                                               "Participantes",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Exclamation);
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void frmParticipates_Load(object sender, EventArgs e)
        {
            num++;
            lblNumero.Text = num.ToString("D4");
            lblFecha.Text = DateTime.Now.ToString("d");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando datos
            DateTime fecha, hora;
            string participante, cargo;
                int numero;
            participante = txtParticipantes.Text;
            numero = int.Parse(lblNumero.Text);
            fecha = DateTime.Parse(lblFecha.Text);
            hora = DateTime.Parse(lblHora.Text);
            cargo = cboCargo.Text;

            //contabili9zar la cantidad segun los cargos

            switch (cargo)
            {
                case "Jefe": cjefe++; break;
                case "Operativo": cOperario++; break;
                case "Administrativo": cAdministrativo++; break;
                case "Practicante": cPracticante++; break;
            }

            //Imprimiendo el registro
            ListViewItem fila = new ListViewItem(numero.ToString());
            fila.SubItems.Add(participante);
            fila.SubItems.Add(cargo);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(hora.ToString("hh:mm:ss"));
            lvParticipantes.Items.Add(fila);

            //imprimiendo estadisticas
            lvEstadisticas.Items.Clear();
            string[] elementosFila = new string[2];
            ListViewItem row;

            //Añadimos 
            elementosFila[0] = "Jefe";
            elementosFila[1] = cjefe.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //Añadimos la swegunda fila al lvEstadisticas

            elementosFila[0] = "Operario";
            elementosFila [1]= cOperario.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //Añadimos la 3ra fila al lvEstadisticas

            elementosFila[0] = "Administrativo";
            elementosFila[1] = cAdministrativo.ToString();  
            row = new ListViewItem (elementosFila);
            lvEstadisticas.Items.Add (row);

            //Añadimos la 4ta fila al lvEstadistuicas

            elementosFila[0] = "Practicante";
            elementosFila[1] = cPracticante.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas .Items.Add(row);

            //Mostrando el numero de registro
            num++;
            lblNumero.Text = num.ToString("D4");
            
            //limpiando los controles 
            txtParticipantes.Clear();
            cboCargo.SelectedIndex = -1;
            cboCargo.Text = ("Seleccione el cargo");
            txtParticipantes.Focus();           //para la rayita parpadeante
        }
    }
}
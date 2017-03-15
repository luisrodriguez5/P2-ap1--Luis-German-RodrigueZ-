using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialTech.Registro
{
    public partial class FormEmpleado : Form
    {
        Empleados Empleado;
        EmpleadosEmails Detalle;
        public FormEmpleado()
        {
            InitializeComponent();
            Limpiar();
        }


        private void Limpiar()
        {
            Empleado = new Empleados();
            Detalle = new EmpleadosEmails();

            empleadoIdMaskedTextBox.Clear();
            nombresTextBox.Clear();
            fechaNacimientoDateTimePicker.Value = DateTime.Today;
            sueldoMaskedTextBox.Clear();
            errorProvider1.Clear();
            RetencionesdataGridView.DataSource = null;
            retencionesComboBox.Text = null;

            TipoIdtextBox.Clear();
            TipotextBox.Clear();
            EmailtextBox.Clear();
            TiposEmailsdataGridView.DataSource = null;

            nombresTextBox.Focus();
        }

        private bool Validar()
        {
            bool interruptor = true;

            if (string.IsNullOrEmpty(nombresTextBox.Text))
            {
                errorProvider1.SetError(nombresTextBox, "Llenar el campo vacio.");
                interruptor = false;
            }
            if (string.IsNullOrEmpty(sueldoMaskedTextBox.Text))
            {
                errorProvider1.SetError(sueldoMaskedTextBox, "Llenar el campo vacio.");
                interruptor = false;
            }
            if (RetencionesdataGridView.DataSource == null)
            {
                errorProvider1.SetError(RetencionesdataGridView, "Llenar el campo vacio.");
                interruptor = false;
            }
            if (TiposEmailsdataGridView.DataSource == null)
            {
                errorProvider1.SetError(TiposEmailsdataGridView, "Llenar el campo vacio.");
                interruptor = false;
            }

            return interruptor;
        }

        private void LlenarCombo()
        {
            List<Entidades.Retenciones> lista = BLL.RetencionesBLL.GetListAll();

            retencionesComboBox.DataSource = lista;
            retencionesComboBox.DisplayMember = "Descripcion";
            retencionesComboBox.ValueMember = "RetencionId";

            if (retencionesComboBox.Items.Count >= 1)
                retencionesComboBox.SelectedIndex = -1;
        }

        private Entidades.Empleados LlenarCampos()
        {
            Empleado.EmpleadoId = Utilidades.TOINT(empleadoIdMaskedTextBox.Text);
            Empleado.Nombres = nombresTextBox.Text;
            Empleado.FechaNacimiento = fechaNacimientoDateTimePicker.Value;
            Empleado.Sueldo = Utilidades.TOINT(sueldoMaskedTextBox.Text);
            Empleado.RetencionId = (int)retencionesComboBox.SelectedValue;

            return Empleado;
        }

        private void LlenarGridRetenciones(Entidades.Empleados empleado)
        {
            RetencionesdataGridView.DataSource = null;
            RetencionesdataGridView.DataSource = empleado.Retenciones;
        }

        private void LlenarGridTiposEmails(Entidades.Empleados empleado)
        {
            TiposEmailsdataGridView.DataSource = null;
            TiposEmailsdataGridView.DataSource = empleado.Relacion.ToList();

            this.TiposEmailsdataGridView.Columns["Id"].Visible = false;
            this.TiposEmailsdataGridView.Columns["EmpleadoId"].Visible = false;
            this.TiposEmailsdataGridView.Columns["TipoEmail"].Visible = false;
        }

        private void TipoIdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int id = Utilidades.TOINT(TipoIdtextBox.Text);

            if (e.KeyChar == (char)Keys.Enter)
            {
                Detalle.TipoEmail = BLL.TiposEmailBLL.Buscar(p => p.TipoId == id);

                if (Detalle.TipoEmail != null)
                {
                    TipotextBox.Text = Detalle.TipoEmail.Descripcion;
                }

                EmailtextBox.Focus();
            }
        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            LlenarCombo();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                MessageBox.Show("Por favor llenar los campos vacios.");
                Limpiar();
            }
            else
            {
                var empleado = new Empleados();

                empleado = LlenarCampos();

                if (empleado != null)
                {
                    if (EmpleadoBLL.Guardar(empleado))
                        MessageBox.Show("El empleado se guardo.");
                    else
                        MessageBox.Show("El empleado no se pudo guardar.");

                }

                Limpiar();
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                MessageBox.Show("No se puede eliminar porque hay campos vacios.");
                Limpiar();
            }
            else
            {
                int id = Utilidades.TOINT(empleadoIdMaskedTextBox.Text);

                if (EmpleadoBLL.Eliminar(EmpleadoBLL.Buscar(p => p.EmpleadoId == id)))
                {
                    Limpiar();
                    MessageBox.Show("El empleado se elimino con exito.");
                }
                else
                {
                    MessageBox.Show("El empleado no se pudo eliminar.");
                }
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(empleadoIdMaskedTextBox.Text))
            {
                MessageBox.Show("No ahi ningun Id para poder evaluar.");
                Limpiar();
            }
            else
            {
                int id = Utilidades.TOINT(empleadoIdMaskedTextBox.Text);
                var empleado = EmpleadoBLL.Buscar(p => p.EmpleadoId == id);

                if (empleado != null)
                {
                    nombresTextBox.Text = empleado.Nombres;
                    fechaNacimientoDateTimePicker.Value = empleado.FechaNacimiento;
                    sueldoMaskedTextBox.Text = empleado.Sueldo.ToString();

                    LlenarGridRetenciones(empleado);
                    LlenarGridTiposEmails(empleado);
                }
                else
                {
                    MessageBox.Show("No existe ningun empleado con ese Id.");
                    Limpiar();
                }
            }
        }

        private void AgregarRetencionesbutton_Click(object sender, EventArgs e)
        {
            Entidades.Retenciones retencion = new Retenciones();

            retencion = (Entidades.Retenciones)retencionesComboBox.SelectedItem;
            Empleado.Retenciones.Add(retencion);

            LlenarGridRetenciones(Empleado);
        }

        private void AgragarEmailsbutton_Click(object sender, EventArgs e)
        {
            Empleado.AgregarDetalle(Detalle.TipoEmail, EmailtextBox.Text);

            LlenarGridTiposEmails(Empleado);
        }
    }
}

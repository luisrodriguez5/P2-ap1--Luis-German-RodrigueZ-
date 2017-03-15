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
    public partial class FormRetenciones : Form
    {
        public int RetencionId { get; private set; }

        public FormRetenciones()
        {
            InitializeComponent();
        }


        private void Limpiar()
        {
            retencionIdMaskedTextBox.Clear();
            descripcionTextBox.Clear();
            valorMaskedTextBox.Clear();
            errorProvider1.Clear();

            descripcionTextBox.Focus();
        }

        private bool Validar()
        {
            bool interruptor = true;

            if (string.IsNullOrEmpty(descripcionTextBox.Text))
            {
                errorProvider1.SetError(descripcionTextBox, "Llenar el campo vacio.");
                interruptor = false;
            }
            if (string.IsNullOrEmpty(valorMaskedTextBox.Text))
            {
                errorProvider1.SetError(valorMaskedTextBox, "Llenar el campo vacio.");
                interruptor = false;
            }

            return interruptor;
        }


        private void Retenciones_Load(object sender, EventArgs e)
        {

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
                var retencion = new Retenciones();

                retencion.RetencionId = Utilidades.TOINT(retencionIdMaskedTextBox.Text);
                retencion.Descripcion = descripcionTextBox.Text;
                retencion.Valor = Utilidades.TOINT(valorMaskedTextBox.Text);

                if (retencion != null)
                {

                    if (BLL.RetencionesBLL.Guardar(retencion))
                        MessageBox.Show("La retencion se guardo con exito.");
                    else
                        MessageBox.Show("No se pudo guardar la retencion.");
                }

                Limpiar();
            }

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(retencionIdMaskedTextBox.Text))
            {
                MessageBox.Show("No ahi ningun Id para poder evaluar.");
                Limpiar();
            }
            else
            {
                int id = Utilidades.TOINT(retencionIdMaskedTextBox.Text);
                var retencion = new Retenciones();

                retencion = BLL.RetencionesBLL.Buscar(p => p.RetencionId == id);

                if (retencion != null)
                {
                    descripcionTextBox.Text = retencion.Descripcion;
                    valorMaskedTextBox.Text = retencion.Valor.ToString();
                }
                else
                {
                    MessageBox.Show("No existe ninguna retencion con ese Id.");
                    Limpiar();
                }
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(retencionIdMaskedTextBox.Text))
            {
                MessageBox.Show("No se puede eliminar porque hay campos vacios.");
                Limpiar();
            }
            else
            {
                int id = Utilidades.TOINT(retencionIdMaskedTextBox.Text);

                if (BLL.RetencionesBLL.Eliminar(BLL.RetencionesBLL.Buscar(p => p.RetencionId == id)))
                {
                    Limpiar();
                    MessageBox.Show("La retencion se elimino con exito.");
                }
                else
                {
                    MessageBox.Show("La retencion no se pudo eliminar.");
                }
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

    }
}

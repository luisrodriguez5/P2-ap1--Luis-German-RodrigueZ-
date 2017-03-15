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
    public partial class FrmTipoEmails : Form
    {
        public FrmTipoEmails()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            TipoIdmaskedTextBox.Clear();
            descripcionTextBox.Clear();
            errorProvider1.Clear();

            descripcionTextBox.Focus();
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(descripcionTextBox.Text))
            {
                errorProvider1.SetError(descripcionTextBox, "El campo esta vacio.");
                return false;
            }

            return true;
        }


        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            TiposEmails tipo = new TiposEmails();

            if (!Validar())
            {
                MessageBox.Show("Por favor llenar los campos vacio.");
                Limpiar();
            }
            else
            {
                tipo.Descripcion = descripcionTextBox.Text;

                if (TiposEmailBLL.Guardar(tipo))
                    MessageBox.Show("El tipo email se guardo con exito.");
                else
                    MessageBox.Show("El tipo email no se pudo guardar.");
            }

            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TipoIdmaskedTextBox.Text))
            {
                MessageBox.Show("Hay campos vacios.");
                Limpiar();
            }
            else
            {
                int id = Utilidades.TOINT(TipoIdmaskedTextBox.Text);

                if (BLL.TiposEmailBLL.Eliminar(BLL.TiposEmailBLL.Buscar(p => p.TipoId == id)))
                {
                    Limpiar();
                    MessageBox.Show("Tipo de email eliminado con exito.");
                }
                else
                    MessageBox.Show("No se pudo eliminar tipo de email.");
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TipoIdmaskedTextBox.Text))
            {
                MessageBox.Show("El id a evaluar esta vacio.");
                Limpiar();
            }
            else
            {
                int id = Utilidades.TOINT(TipoIdmaskedTextBox.Text);
                var tipo = TiposEmailBLL.Buscar(p => p.TipoId == id);

                if (tipo != null)
                {
                    descripcionTextBox.Text = tipo.Descripcion;
                }
                else
                {
                    MessageBox.Show("No existe ningun tipo con ese id.");
                    Limpiar();
                }
            }
        }
    }
}

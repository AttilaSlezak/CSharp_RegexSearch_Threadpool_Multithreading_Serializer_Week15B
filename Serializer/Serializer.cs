using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;

namespace Serializer
{
    public partial class Serializer : Form
    {
        private Person person = new Person();
        //public int currentSerialNumber = 1;
        //public int nextSavingSerialNumber = 1;

        public Serializer()
        {
            InitializeComponent();
        }

        private bool checkDataFormat()
        {
            if (!Regex.IsMatch(txtName.Text, @"^([A-ZÄÁÉÍÓÖŐUÚÜŰ]([A-Za-zäÄÁÉÍÓÖŐUÚÜŰáéíóöőüű]*([ ]|[.][ ]|[A-Za-zäáéíóöőüű]$))){2,}$"))
            {
                MessageBox.Show("The name is invalid!\n\n"
                    + "At least two names and titles are allowed in only alphabetical characters and in right case format!\n"
                    + "\nFor example:\n\tJohn Smith\n\tDr. John Smith\n\tJohn S. Smith", "Invalid Name");
                return false;
            }
            else if (!Regex.IsMatch(txtAddress.Text, @"^[A-Za-zÄÁÉÍÓÖŐUÚÜŰäáéíóöőüű0-9()&. /,-]{6,}$"))
            {
                MessageBox.Show("The address is invalid!", "Invalid Address");
                return false;
            }
            else if (!Regex.IsMatch(txtPhone.Text, @"^[0-9()/ -]{7,}$"))
            {
                MessageBox.Show("The phone number is invalid!", "Invalid Phone number");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkDataFormat())
            {                
                
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}

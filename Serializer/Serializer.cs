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
        private Person _person = new Person();
        private string _personDataFolder = @"C:\testfiles\PersonData\";
        //public int _currentSerialNumber = 1;
        //public int _nextSavingSerialNumber = 1;

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
        
        private void repairFileNameSequence(List<int> holes)
        {
            int actualHoleIndex = 0;
            for (int i = holes[0]+1; i < 100; i++)
            {
                string currentPath = _personDataFolder + "person" + i.ToString("D2") + ".dat";

                if (File.Exists(currentPath))
                {
                    string destPath = _personDataFolder + "person" + (i - actualHoleIndex - 1).ToString("D2") + ".dat";
                    File.Move(currentPath, destPath);
                }
                else
                {
                    actualHoleIndex = holes.IndexOf(i);
                    if (actualHoleIndex == -1)
                        break;
                }
            }
        }

        private void checkFileNameSequence()
        {
            List<int> holes = new List<int>();
            bool isThereProblem = false;
            for (int i = 1; i < 100; i++)
            {
                if (!File.Exists(_personDataFolder + "person" + i.ToString("D2") + ".dat"))
                {
                    holes.Add(i);
                }
                else if (holes.Count > 0 && File.Exists(_personDataFolder + "person" + i.ToString("D2") + ".dat"))
                {
                    isThereProblem = true;
                }
            }
            if (isThereProblem)
            {
                for (int i = 99; i > holes[0]; i--)
                {
                    if (holes.IndexOf(i) != -1)
                        holes.Remove(holes.IndexOf(i));
                    else
                        break;
                }
                repairFileNameSequence(holes);
            }
        }

        private void setSerialNumber()
        {
            for (int i = 0; i < 100; i++)
            {
                if (!File.Exists(_personDataFolder + "person" + i.ToString("D2") + ".dat"))
                {
                    _person.SerialNumber = i;
                    break;
                }
            }
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

        private void Serializer_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(_personDataFolder))
            {
                new DirectoryInfo(_personDataFolder).Create();
            }
        }
    }
}

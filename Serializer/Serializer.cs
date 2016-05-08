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
        private int _nextSavingSerialNumber = 1;
        

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

                    if (_person.SerialNumber == i)
                        _person.SerialNumber = i - actualHoleIndex - 1;
                }
                else
                {
                    actualHoleIndex = holes.IndexOf(i) != -1 ? holes.IndexOf(i) : actualHoleIndex;
                    if (holes.IndexOf(i) == -1)
                        if (_person.SerialNumber >= i)
                            _person.SerialNumber = i - actualHoleIndex - 1;
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

        private void setNextSerialNumber()
        {
            for (int i = 1; i < 100; i++)
            {
                if (!File.Exists(_personDataFolder + "person" + i.ToString("D2") + ".dat"))
                {
                    _nextSavingSerialNumber = i;
                    break;
                }
            }
        }

        private void setSerialNumber(int direction)
        {
            checkFileNameSequence();
            setNextSerialNumber();

            if (direction == 0)
            {
                _person.SerialNumber = 1;
                deserialize();
                return;
            }

            _person.SerialNumber += direction;

            if (_person.SerialNumber == 0)
            {
                _person.SerialNumber = _nextSavingSerialNumber;
                createNewForm();
            }
            else if (_person.SerialNumber == _nextSavingSerialNumber)
            {
                createNewForm();
            }
            else if (_person.SerialNumber == _nextSavingSerialNumber + 1)
            {
                _person.SerialNumber = 1;
                deserialize();
            }
            else
            {
                deserialize();
            }
        }

        private void setPersonData()
        {
            _person.Name = txtName.Text;
            _person.Address = txtAddress.Text;
            _person.Phone = txtPhone.Text;
            _person.DateOfRecording = DateTime.Now;
        }

        private void displayPersonData()
        {
            txtName.Text = _person.Name;
            txtAddress.Text = _person.Address;
            txtPhone.Text = _person.Phone;
            lblCounter.Text = _person.SerialNumber.ToString("D2") + "/" + (_nextSavingSerialNumber-1).ToString("D2");
        }

        private void createNewForm()
        {
            _person.SerialNumber = _nextSavingSerialNumber;
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            lblCounter.Text = "New Person";
        }

        private void deserialize()
        {
            string path = _personDataFolder + "person" + _person.SerialNumber.ToString("D2") + ".dat";
            int currentSerialNumber = _person.SerialNumber;
            IFormatter formatter = new BinaryFormatter();
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);
                _person = (Person)formatter.Deserialize(fileStream);
                fileStream.Close();
                _person.SerialNumber = currentSerialNumber;
                displayPersonData();
            }
            catch
            {
                MessageBox.Show("Something is went wrong. Program is restarting...", "Error");
                Serializer_Load("deserialize", EventArgs.Empty);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkDataFormat())
            {
                checkFileNameSequence();
                setNextSerialNumber();
                setPersonData();

                string question = "Are you sure you really would like to overwrite this person's (" + _person.Name + ") data form?";
                if (_person.SerialNumber != _nextSavingSerialNumber 
                    && MessageBox.Show(question, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                string path = _personDataFolder + "person" + _person.SerialNumber.ToString("D2") + ".dat";

                IFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
                formatter.Serialize(fileStream, _person);
                fileStream.Close();
                if (lblCounter.Text == "New Person")
                {
                    lblCounter.Text = _person.SerialNumber.ToString("D2") + "/" + (_nextSavingSerialNumber).ToString("D2");
                    _nextSavingSerialNumber++;
                }
                MessageBox.Show(_person.Name + "'s data has been successfully saved\ninto " + path + ".", "Successful Saving");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            setSerialNumber(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            setSerialNumber(1);
        }

        private void Serializer_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(_personDataFolder))
            {
                new DirectoryInfo(_personDataFolder).Create();
            }
            setSerialNumber(0);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            createNewForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string question = "Are you sure you really would like to delete this person's (" + _person.Name + ") data form?";
            if (_person.SerialNumber == _nextSavingSerialNumber
                || MessageBox.Show(question, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            try
            {
                string path = _personDataFolder + "person" + _person.SerialNumber.ToString("D2") + ".dat";
                File.Delete(path);
                MessageBox.Show(_person.Name + " has been successfully deleted from the database with the corresponding file:\n" + path, 
                    "Confirmation");
                setSerialNumber(-1);
                displayPersonData();
            }
            catch
            {
                MessageBox.Show("Something is went wrong. Program is restarting...", "Error");
                Serializer_Load("deserialize", EventArgs.Empty);
            }
        }
    }
}

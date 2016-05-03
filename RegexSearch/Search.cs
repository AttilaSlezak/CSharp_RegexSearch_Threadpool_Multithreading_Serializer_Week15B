using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RegexSearch
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstMatched.Items.Clear();

            MatchCollection matches = Regex.Matches(rtxtText.Text, txtPattern.Text);

            foreach (Match oneMatch in matches)
            {
                lstMatched.Items.Add(oneMatch.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeSort_algorithm
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }
        string UserArrayLength;
        int num;
        string UserArrayNo;
        int ArrayValue;
      
        private void btnExecute_Click(object sender, EventArgs e)
        {
         //user sets length of the array.   
            UserArrayLength = Microsoft.VisualBasic.Interaction.InputBox("Enter a number to determine the length of the array", "Enter Number");
            try
            {
                // checks to see if user tried to pass a string, if true will fail.
                while (!(int.TryParse(UserArrayLength, out num)))
                {
                    //user tries again.
                    MessageBox.Show("Not a valid number, try again.");
                    UserArrayLength = Microsoft.VisualBasic.Interaction.InputBox("Enter a number a to determine the length of the array", "Enter Number");
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Value entered is not in a valid format");
            }

            int intlength = Int32.Parse(UserArrayLength);
            string[] stringsArray = new string[intlength];

            // For display 
            int ArrayPOS = 0; // set position of start of the array.
            int POSvalue = 1; // set start value of the array.
            txtOutput.Text += "Unsorted array: \r\n";
            foreach (string s in stringsArray)
            {
                //user inputs the values to be placed inside the Array. values get placed one by one into position to be sorted after,displays it to user as its been entered.
                string ArrayValue = Microsoft.VisualBasic.Interaction.InputBox("Enter a number for array value" + POSvalue, "Enter Number");
                string arrayvalues = ArrayValue;
                stringsArray[ArrayPOS] = arrayvalues;//.ToString();

                txtOutput.Text += arrayvalues + "\t";
                ArrayPOS++;
                POSvalue++;
            }
            
            mergeSort(stringsArray, 0, stringsArray.Length - 1);

            txtOutput.Text += "\r\nSorted array: \r\n";
            foreach (string i in stringsArray) // displays each values after its been sorted.
            {
                txtOutput.Text += i + "\t";
            }
            foreach(string s in stringsArray) // displays each step of the process
            {
                txtOutput.Text += ("\r\n Value at position" + " " + Array.IndexOf(stringsArray, s) + " " + "is " + " " + s + "\r\n");
            }

        }

        public void mergeSort(string[] sortArray, int lower, int upper) // this mergeSort was modified to pass a string instead of an Int.
        {
            int middle;
            if (upper == lower)
                return;
            else
            {
                middle = (lower + upper) / 2;
                mergeSort(sortArray, lower, middle);
                mergeSort(sortArray, middle + 1, upper);
                Merge(sortArray, lower, middle + 1, upper);
            }
        }
        public void Merge(string[] sortArray, int lower, int middle, int upper)// this Merge method was modified to work with a string instead of Int.
        {
            string[] temp = new string[sortArray.Length];
            int lowEnd = middle - 1;
            int low = lower;
            int n = upper - lower + 1;
            while ((lower <= lowEnd) && (middle <= upper))
            {
                if (sortArray[lower].CompareTo(sortArray[middle])<1)
                {
                    temp[low] = sortArray[lower];
                    low++;
                    lower++;
                }
                else
                {
                    temp[low] = sortArray[middle];
                    low++;
                    middle++;
                }
            }
            while (lower <= lowEnd)
            {
                temp[low] = sortArray[lower];
                low++;
                lower++;
            }
            while (middle <= upper)
            {
                temp[low] = sortArray[middle];
                low++;
                middle++;
            }
            for (int i = 0; i < n; i++)
            {
                sortArray[upper] = temp[upper];
                upper--;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

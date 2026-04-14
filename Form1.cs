using System;
using System.Drawing;
using System.Windows.Forms;

namespace HealthMateBMIAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Activity options
            cmbActivity.Items.Add("Sedentary");
            cmbActivity.Items.Add("Lightly Active");
            cmbActivity.Items.Add("Active");

            this.Text = "HealthMate BMI Analyzer";
            this.BackColor = Color.Honeydew;

            lblBMIValue.Font = new Font("Segoe UI", 16, FontStyle.Bold);

            // Logo
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // ---------------- VALIDATION ----------------
            if (txtName.Text == "")
            {
                MessageBox.Show("Enter Name");
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 10 || age > 100)
            {
                MessageBox.Show("Enter valid Age (10-100)");
                return;
            }

            if (!double.TryParse(txtWeight.Text, out double weight) || weight < 20 || weight > 250)
            {
                MessageBox.Show("Enter valid Weight (20-250 kg)");
                return;
            }

            if (!double.TryParse(txtHeight.Text, out double height) || height < 100 || height > 220)
            {
                MessageBox.Show("Enter valid Height (100-220 cm)");
                return;
            }

            if (!rdoMale.Checked && !rdoFemale.Checked)
            {
                MessageBox.Show("Select Gender");
                return;
            }

            if (cmbActivity.SelectedItem == null)
            {
                MessageBox.Show("Select Activity Level");
                return;
            }

            // ---------------- GET VALUES ----------------
            string gender = rdoMale.Checked ? "Male" : "Female";
            if (cmbActivity.SelectedItem == null)
            {
                MessageBox.Show("Select Activity Level");
                return;
            }

            string activity = cmbActivity.Text;
            // ---------------- BMI CALCULATION ----------------
            double heightM = height / 100;
            double bmi = weight / (heightM * heightM);

            string category = "";
            string risk = "";
            string advice = "";

            // ---------------- BMI LOGIC ----------------
            if (bmi < 18.5)
            {
                category = "Underweight";
                risk = "Low Risk";
                lblCategory.ForeColor = Color.Orange;

                advice =
                "• Eat calorie-rich foods\n" +
                "• Increase protein intake\n" +
                "• Eat frequently\n" +
                "• Avoid skipping meals\n" +
                "• Stay hydrated";
            }
            else if (bmi < 24.9)
            {
                category = "Normal";
                risk = "Healthy";
                lblCategory.ForeColor = Color.Green;

                advice =
                "• Maintain balanced diet\n" +
                "• Exercise daily\n" +
                "• Eat fruits & vegetables\n" +
                "• Sleep well\n" +
                "• Drink water";
            }
            else if (bmi < 29.9)
            {
                category = "Overweight";
                risk = "Moderate Risk";
                lblCategory.ForeColor = Color.DarkOrange;

                advice =
                "• Reduce sugar & oil\n" +
                "• Avoid junk food\n" +
                "• Start walking daily\n" +
                "• Control portions\n" +
                "• Drink warm water";
            }
            else
            {
                category = "Obese";
                risk = "High Risk";
                lblCategory.ForeColor = Color.Red;

                advice =
                "• Follow strict diet\n" +
                "• Avoid fried foods\n" +
                "• Exercise regularly\n" +
                "• Consult doctor\n" +
                "• Reduce stress";
            }

            // ---------------- GENDER-BASED ADVICE ----------------
            if (gender == "Female")
            {
                advice += "\n\n• Maintain iron-rich diet (spinach, dates)";
            }
            else
            {
                advice += "\n\n• Maintain protein intake for muscle health";
            }

            // ---------------- ACTIVITY ADVICE ----------------
            if (activity == "Sedentary")
            {
                advice += "\n\n⚠ Move more. Avoid long sitting.";
            }
            else if (activity == "Lightly Active")
            {
                advice += "\n\n✔ Good. Stay consistent.";
            }
            else
            {
                advice += "\n\n Great activity level!";
            }

            // ---------------- OUTPUT ----------------
            lblBMIValue.Text = "BMI: " + bmi.ToString("0.0");
            lblCategory.Text = "Category: " + category;
            lblRisk.Text = "Risk: " + risk;

            rtbReport.Text =
                "HEALTHMATE BMI REPORT\n" +
                "----------------------------\n" +
                "Name: " + txtName.Text + "\n" +
                "Age: " + age + "\n" +
                "Gender: " + gender + "\n\n" +
                "Weight: " + weight + " kg\n" +
                "Height: " + height + " cm\n\n" +
                "BMI: " + bmi.ToString("0.0") + "\n" +
                "Category: " + category + "\n" +
                "Risk: " + risk + "\n\n" +
                "Advice:\n" + advice +
                "\n\nActivity: " + activity;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAge.Clear();
            txtWeight.Clear();
            txtHeight.Clear();

            cmbActivity.SelectedIndex = -1;

            rdoMale.Checked = false;
            rdoFemale.Checked = false;

            lblBMIValue.Text = "";
            lblCategory.Text = "";
            lblRisk.Text = "";

            rtbReport.Clear();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Data;
using System.Globalization;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Project01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isCheck = false;

        private bool isRad = false;

        private double saveA = 0;

        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            foreach (UIElement el in Buttons.Children)
            {
                if (el is Button)
                    ((Button)el).Click += ButtonClick;
            }
        }

        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            try
            {
                string contentButton = ((Button)e.OriginalSource).Content.ToString();

                switch (contentButton)
                {
                    default:
                        Output.Text += contentButton;
                        break;

                    case "2nd":
                        Replace2nd();
                        break;

                    case "%":
                        if (Output.Text != "")
                            Output.Text = (Convert.ToDouble(Output.Text) / 100).ToString();
                        break;

                    case "÷":
                        Output.Text += "/";
                        break;

                    case "AC":
                        Output.Text = "";
                        break;

                    case "×":
                        Output.Text += "*";
                        break;

                    case "±":
                        break;

                    case "=":
                        Result();
                        break;

                    case "x²":
                        Output.Text = Math.Pow((Convert.ToDouble(Output.Text)), 2).ToString();
                        break;
                    case "x³":
                        Output.Text = Math.Pow(Convert.ToDouble(Output.Text), 3).ToString();
                        break;

                    case "xᵞ":
                        saveA = Convert.ToDouble(Output.Text);
                        Output.Text = "";

                        //Output.Text = VariableDegree(saveA, Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "eᵡ":
                        Output.Text = VariableDegree(Math.E, Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "10ᵡ":
                        Output.Text = VariableDegree(10, Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "1/x":
                        Output.Text = Convert.ToDouble(Output.Text).ToString();
                        break;

                    case "²√x":
                        Output.Text = Math.Sqrt(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "³√x":
                        Output.Text = Math.Pow(Convert.ToDouble(Output.Text), 1.0 / 3.0).ToString();
                        break;

                    case "ln":
                        Output.Text = Math.Log(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "log₁₀":
                        Output.Text = Math.Log10(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "x!":
                        Output.Text = Factorial(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "sin":
                        Output.Text = Math.Sin(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "cos":
                        Output.Text = Math.Cos(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "tan":
                        Output.Text = Math.Tan(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "sinh":
                        Output.Text = Math.Sinh(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "cosh":
                        Output.Text = Math.Cosh(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "tanh":
                        Output.Text = Math.Tanh(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "e":
                        Output.Text += Math.E.ToString();
                        break;

                    case "EE":
                        string a = Output.Text.Replace('.', ',');
                        Output.Text = MathEE(a);
                        break;

                    case "π":
                        Output.Text += Math.PI.ToString();
                        break;

                    case "Rand":
                        Output.Text += Rnd().ToString().Replace(',', '.');
                        break;

                    case "Rad":
                        isRad = true;
                        Rad.Text = "Rad";
                        btnRad.Content = "Deg";
                        break;


                    case "Deg":
                        Rad.Text = "";
                        btnRad.Content = "Rad";
                        isRad = false;
                        break;

                    case "sin⁻¹":
                        Output.Text = (Math.Asin(Convert.ToDouble(Output.Text.Replace('.', ','))) * 180 / Math.PI).ToString().Replace(',', '.'); 
                        break;

                    case "cos⁻¹":
                        Output.Text = (Math.Acos(Convert.ToDouble(Output.Text.Replace('.', ','))) * 180 / Math.PI).ToString().Replace(',', '.');
                        break;

                    case "tan⁻¹":
                        Output.Text = (Math.Atan(Convert.ToDouble(Output.Text.Replace('.', ','))) * 180 / Math.PI).ToString().Replace(',', '.');
                        break;

                    case "2ᵡ":
                        Output.Text = Math.Pow(2, Convert.ToDouble(Output.Text)).ToString();
                        break;

                    //case "logᵧ":
                    //    Output.Text = Math.Log10(Convert.ToDouble(Output.Text)).ToString();
                    //    break;

                    case "sinh⁻¹":
                        Output.Text = Math.Log(Convert.ToDouble(Output.Text) + Math.Sqrt(Math.Pow(Convert.ToDouble(Output.Text), 2) + 1)).ToString();
                        break;

                    case "cosh⁻¹":
                        Output.Text = Math.Log(Convert.ToDouble(Output.Text) + Math.Sqrt(Math.Pow(Convert.ToDouble(Output.Text), 2) - 1)).ToString();
                        break;

                    case "tanh⁻¹":
                        Output.Text = (Math.Log(Convert.ToDouble(Output.Text) + Math.Sqrt(Math.Pow(Convert.ToDouble(Output.Text), 2) + 1)) * (Convert.ToDouble(Output.Text) / Math.Sqrt(1 - Math.Pow(Convert.ToDouble(Output.Text), 2)))).ToString();
                        break;

                    case "log₂":
                        Output.Text = Math.Log(Convert.ToDouble(Output.Text), 2).ToString();
                        break;

                }
            }
            catch (Exception)
            {
                Output.Text = "Ошибка";
            }
        }

        private void Result()
        {
            string answer = new DataTable().Compute(Output.Text, null).ToString().Replace(',', '.');
            Output.Text = answer;
        }

        private void Replace2nd()
        {
            if (!isCheck)
            {
                isCheck = true;

                button2nd.Background = Brushes.Gray;
                button2nd.Foreground = Brushes.Black;

                tenX.Content = "2ᵡ";
                eX.Content = "yᵡ";
                log10.Content = "log₂";
                ln.Content = "logᵧ";
                tan.Content = "tan⁻¹";
                cos.Content = "cos⁻¹";
                sin.Content = "sin⁻¹";
                tanh.Content = "tanh⁻¹";
                cosh.Content = "cosh⁻¹";
                sinh.Content = "sinh⁻¹";
            }
            else
            {
                isCheck = false;

                var bc = new BrushConverter();
                button2nd.Background = (Brush)bc.ConvertFrom("#212121");
                button2nd.Foreground = Brushes.White;

                tenX.Content = "10ᵡ";
                eX.Content = "eᵡ";
                log10.Content = "log₁₀";
                ln.Content = "ln";
                tan.Content = "tan";
                cos.Content = "cos";
                sin.Content = "sin";
                tanh.Content = "tanh";
                cosh.Content = "cosh";
                sinh.Content = "sinh";
            }
        }

        //TODO
        private void CorrectNumber()
        {
            if (Output.Text.IndexOf("∞") != -1)
                Output.Text = Output.Text.Substring(0, Output.Text.Length - 1);

            if (Output.Text[0] == '0' && (Output.Text.IndexOf(",") != 1))
                Output.Text = Output.Text.Remove(0, 1);

            if (Output.Text[0] == '-')
                if (Output.Text[1] == '0' && (Output.Text.IndexOf(",") != 2))
                    Output.Text = Output.Text.Remove(1, 1);
        }

        private double VariableDegree(double x, double y)
        {
            return Math.Pow(x, y);
        }

        public BigInteger Factorial(double n)
        {
            var factorial = new BigInteger(1);
            for (int i = 1; i <= n; i++)
                factorial *= i;

            return factorial;
        }

        public string MathEE(string valueString)
        {
            double a = Convert.ToDouble(valueString);
            string[] str = a.ToString(new NumberFormatInfo() { NumberDecimalSeparator = "." }).Split('.');
            int comma = (str.Length == 2 ? str[1].Length : 0) - 3;

            for (int i = 0; i < comma; i++)
            {
                valueString = valueString.Remove(valueString.Length - 1);
            }

            return valueString.Replace(',', '.') + " " + "*" + " " + "10^" + comma;
        }

        public double Rnd()
        {
            Random rnd = new Random();
            double d = Math.Round(0.1 + rnd.NextDouble() * 0.89, 13);

            return d;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private long number1 = 0;
        private long number2 = 0;
        private long tmpNumber = 0;
        private string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void onNumberClick(object sender, RoutedEventArgs e) {
            tmpNumber = (tmpNumber * 10) + Int32.Parse(((Button) sender).Content.ToString());
            
            if (tmpNumber.ToString().Length >= 20) {
                textBlock.Text = "Exception";
                if (operation.Length == 0) {
                    number1 = 0;
                } 
                else {
                    number2 = 0;
                }                     
            }

            else {
                if (operation.Length == 0) {
                    number1 = tmpNumber;
                } 
                else {
                    
                    number2 = tmpNumber;
                }
                textBlock.Text = tmpNumber.ToString();
            }
        }

        private void onOperationClick(object sender, RoutedEventArgs e)
        {  
            if (((Button) sender).Content.ToString() == "=") {
                calculate();    
                return;
            }

            operation = ((Button) sender).Content.ToString();
            textBlock.Text = "";
            tmpNumber = 0;
        }

        private void onClearClick(object sender, RoutedEventArgs e) {
            switch(((Button) sender).Content.ToString()) {
                case "C":
                     if (operation == "") {
                        number1 = 0;
                        tmpNumber = number1;
                        textBlock.Text = number1.ToString();
                    } else {
                        number2 = 0;
                        tmpNumber = number1;
                        textBlock.Text = number2.ToString();
                    }
                    textBlock.Text = "";
                    break;
                case "CE":                 
                    if (operation == "") {
                        number1 = (int)(number1 / 10);
                        tmpNumber = number1;
                        textBlock.Text = number1.ToString();
                    } else {
                        number2 = (int)(number2 / 10);
                        tmpNumber = number1;
                        textBlock.Text = number2.ToString();
                    }
                    break;                      
            }
        }

        private void calculate() {
          
            if (operation == "+") {
                textBlock.Text = (number1 + number2).ToString();
            }

            else if (operation == "-") {
                 textBlock.Text = (number1 - number2).ToString();
            }

            else if (operation == "/") {
                 textBlock.Text = (number1 / number2).ToString();
            }

            else if (operation == "*") {
                 textBlock.Text = (number1 * number2).ToString();
            }

            textProtocol.Text += number1.ToString() + operation + number2.ToString() + " = " + textBlock.Text + '\n';
            number1 = 0;
            number2 = 0;
            tmpNumber = 0;
            operation = "";
        }
    }
}

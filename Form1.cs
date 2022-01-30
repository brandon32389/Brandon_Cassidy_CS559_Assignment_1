using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brandon_Cassidy_CS559_Assignment_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Decimal squareArea, triangleArea, x, y;
            long factorialResult = 0;
            int factorial;
           
            // Length or base
            x = 10m;

            // Width or Height
            y = 10m;

            // Factorial to evaluate.
            factorial = 200;

            //squareArea = CalculateArea(Shape.Square, x, y);
            //MessageBox.Show($"The area of a square with a length of {x} and a width of {y} is: {squareArea}ft\u00B2"); // u00B2 is a superscript 2.

            //triangleArea = CalculateArea(Shape.Triangle, x, y);
            //MessageBox.Show($"The area of a triangle with a base of {x} and a height of {y} is: {triangleArea}ft\u00B2");

            factorialResult = CalculateFactorial(factorial);
            MessageBox.Show($"The result of {factorial}! is: {factorialResult.ToString("N0")}");

        }

        private enum Shape : byte
        { 
            Square = 1,
            Triangle = 2
        }
        #region CalculateArea
        /*********************************************
         * Method Name: CalculateArea
         * Parameters:
         *      shape - Enum of the type of shape you want to calulate the area of.
         *      x     - The length of the shape.
         *      y     - The width of the shape
         * Returns: Decimal value of the calculated area in ft squared.
         * Purpose: Takes the users passed in shape, x, and y of said shape in feet. In the case of a Square, x and y are the length and width respectively.
         *          In the case of a triangle, x is the base, and y is the height.
         *          Then based on what shape is provided, we calculate the area of the shape and pass that value 
         *          back to the variable that calls this method.
         * Notes: 
         *      1. Square formula = Length x Width.
         *      2. Triangle formula = 1/2BH - B = base and H = height.
        *********************************************/
        private Decimal CalculateArea(Shape shape, Decimal x, Decimal y)
        {
            // Declare the return value parameter.
            decimal area = 0;

            try
            {
                // Raise an exception if the value of x or y is less than or equal to 0. An object can not have a dimension value of 0 or negative values.
                if (x <= 0 || y <= 0)
                {
                    throw new Exception("The values of x and y must be greater than 0.");
                }

                // Switch statement that will allow for easy expansion of additional shapes in the future if needed.
                switch (shape)
                {
                    case Shape.Square:
                        area = x * y;
                        break;
                    case Shape.Triangle:
                        area = .5m * (x * y);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception Ex)
            {

                MessageBox.Show(String.Format("StackTrace = {0}", Ex.StackTrace), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            return area;
        }
        #endregion

        #region CalculateFactorial
        /*********************************************
        * Method Name: CalculateFactorial
        * Parameters:
        *      num - The max number of the factorial
        * Returns: Returns integer with the result of the factorial
        * Purpose: Take the an int, and calculate the factorial.
        * Notes: A factorial is the selected number multiplied by all whole numbers down until 1, e.g., 5! would be 5x4x3x2x1 = 120.
       *********************************************/
        private long CalculateFactorial(int num)
        {
            long answer = 0;
            
            // initialize the counter for the loop to the max value of num.
            int i = num;

            try
            {
                // Check if num is between 1 and 100. If it isn't, throw an error.
                if (num < 1 || num > 100)
                {
                    throw new Exception("The integer value must be between 1 and 100.");
                }

                // Muliply's answer times the next value in the line and re-stores the new value in answer. Decrements i until it reaches 0
                while (i > 0)
                {
                    // Anything multiplied by 0 is 0. If the value of i equals num, which it does on the first iteration, then set the value of answer to the value of i.
                    if(i == num)
                    {
                        answer = i;
                    }
                    else
                    {
                       answer *= i;     
                    }

                    i--;
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(String.Format("StackTrace = {0}", Ex.StackTrace), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            return answer;
        }
        #endregion
    }
}

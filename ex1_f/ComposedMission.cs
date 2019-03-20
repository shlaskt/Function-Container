// Tomer Shlasky
// ID - 204300602
// username - shlaskt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * composed mission class
 * can has many funcs and one name
 * calculate - activate all the funcs on a given value
 */
namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private string mission_name;
        public event EventHandler<double> OnCalculate; // event of when a mission is activated
        private List<calcFunc> funcsList; // list of delegates from double to double
        
        /**
        * Ctor
        * initialize the calcfunc
         * give the mission name.
        */
        public ComposedMission(string name)
        {
            this.mission_name = name;
            this.funcsList = new List<calcFunc>();
        }
        /**
         * Add - add a function and return yourself
         * return this to be able to do this over and over again
         * like A.Add("Double").Add("square").Add(...
         */
        public ComposedMission Add(calcFunc func)
        {
            this.funcsList.Add(func); // add the function to the list
            return this;
        }

        /**
        * return the name (of the mission) and the type (single/composed)
        */
        public String Name
        {
            get
            {
                return this.mission_name; // mission name
            }
        }
        public String Type
        {
            get
            {
                return "Composed"; // mission type
            }
        }

        /**
         * calculate
         * return the value of all the funcs in the list
         * let the event handler know
         */
        public double Calculate(double value)
        {
            double result = value;
            // calculate all the funcs value
            foreach (var f in funcsList)
            {
                result = f(result);
            }
            this.OnCalculate?.Invoke(this,result);
            return result;
        }

    }
}

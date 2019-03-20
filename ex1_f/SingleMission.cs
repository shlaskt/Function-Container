// username - shlaskt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * single mission class
 * has one func and name
 * calculate - activate the func on a given value
 */
namespace Excercise_1
{

    public class SingleMission : IMission
    {
        private calcFunc func; // delegate
        private string mission_name;
        private string mission_type;

        public event EventHandler<double> OnCalculate; // event of when a mission is activated

        /**
         * Ctor
         * initialize the calcfunc and mission name.
         */
        public SingleMission(calcFunc func, string mission_name)
        {
            this.func = func;
            this.mission_name = mission_name;
            this.mission_type = "Single";
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
                return this.mission_type ; // mission type
            }
        }

        /**
         * calculate
         * return the value of the func
         * let the event handler know
         */
        public double Calculate(double value)
        {
            double result = this.func(value); // run the func and return the calculate value
            this.OnCalculate?.Invoke(this,result);
            return result;
        }
    }
}

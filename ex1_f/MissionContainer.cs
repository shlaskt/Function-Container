// Tomer Shlasky
// ID - 204300602
// username - shlaskt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * the functions container class
 * store a dictionary from string (function name) to calcFunc
 * (delegate from double to double)
 */
namespace Excercise_1
{
    public delegate double calcFunc(double x); // delegate from double to double

    public class FunctionsContainer
    {
        private Dictionary<string, calcFunc> dict;
        private List<string> keysList; // list of the keys (strings - function names)
        /**
         * Ctor
         * initialize the dict and list above
         */
        public FunctionsContainer()
        {
            this.dict=new Dictionary<string,calcFunc>();
            this.keysList = new List<string>();
        }
        /**
         * Indexer
         */
        public calcFunc this[string keyWord]
        {
            /**
             * getter
             * if its new func - (like the "stam" func in the example)
             * add it to the dict like the id func (doing nothing -> f(x)=x )
             * else - return the func
             */
            get
            {
                if (!this.dict.ContainsKey(keyWord)) // if key is not exist
                {
                    // func that doing nothing
                    this.dict[keyWord] = val => val;
                    this.keysList.Add(keyWord);
                }
                return this.dict[keyWord];
            }
            /**
             * setter
             * if new - insert to the dict and list
             * else- update dict only
             */
            set
            {
                this.dict[keyWord] = value; // insert new or update
                if (!keysList.Contains(keyWord)) // if this is new func
                {
                    this.keysList.Add(keyWord);
                }
            }
        }
        /**
         * returns list of all the keys - funcs name
         */
        public List<string> getAllMissions(){
            return this.keysList;
        }
       

    }
}

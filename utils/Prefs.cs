using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SD_Scope.utils
{
    public class Prefs


    {
        //Hold file name
        string filename;


        /// <summary>
        /// File structure
        /// 
        /// key1=value1
        /// key2=value2
        /// </summary>


        //Hold params in items list
        List<item> items = new List<item>();

        //Default constructer
        public Prefs(string filename)
        {
            this.filename = filename;
            string text;
            string[] array;
            try
            {
                //Read content of file to text var
                text = System.IO.File.ReadAllText("./" + filename + ".txt");

                //Split it by \n delimiter
                array = text.Split('\n');
            }
            catch (Exception e)
            {
                return;
            }

            //Clear items list for initial use
            items.Clear();
            for (int i = 0; i < array.Length; i++)
            {

                //seprate key and value by = delimiter and put it to items list

                if (!array[i].Contains("="))
                    continue;

                item it = new item(array[i]);
                items.Add(it);

            }
        }
        public string Find(string key)
        {
            //Search for item with key in items list. So iterate the items list
            for (int i = 0; i < items.Count; i++)
            {
                //if current key is the search key
                if (items.ElementAt<item>(i).key == key)
                {
                    return items.ElementAt<item>(i).value;
                }
            }
            return "";
        }



        public void Add(string key, string value)
        {
            //Add or update item

            //Iterate items list
            for (int i = 0; i < items.Count; i++)
            {
                if (items.ElementAt<item>(i).key == key)
                {
                    //if item exist, update the value and exist method

                    items.ElementAt<item>(i).value = value;
                    return;
                }
            }

            //If item does't exist in items list, add as new item
            items.Add(new item(key + "=" + value));
        }

        public void Save()
        {
            //Convert items list to string with '\n' and '=' seperator

            string output = "";
            for (int i = 0; i < items.Count; i++)
            {
                output += items.ElementAt<item>(i).key + "=" + items.ElementAt<item>(i).value + "\n";
            }


            //Write converted string to file
            System.IO.File.WriteAllText("./" + filename + ".txt", output);
        }


    }

    public class item
    {
        //A class to store key value items
        public string key, value;

        //Decault constructor and accept string, e.g. key=value
        public item(string text)
        {
            //split string by '=' and store to current object
            string[] sa = text.Split('=');
            key = sa[0];
            value = sa[1];
        }
    }
}

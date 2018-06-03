using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mission_Calculator.Classes
{
    public static class IO
    {
        //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Pacman";
        //saveDirectoryPath + "\\highScores.json";

        #region "Private Properties"
        private static string _saveDirectoryPath;
        private static string _saveFilePath;
        #endregion

        #region "Public Properties"

        public static List<object> objectList { get; set; }
        public static string fileName { get; set; }
        public static string errorFilePath { get; set; }

        public static string saveDirectoryPath
        {
            get
            {
                return _saveDirectoryPath;
            }
            set
            {
                _saveDirectoryPath = value;
                _saveFilePath = value + fileName;
            }
        } 

        public static string saveFilePath
        {
            get
            {
                return _saveFilePath;
            }
        }

        /// <summary>
        /// Private Property that returns the datetime now to string in a custom format
        /// </summary>
        private static string getTimeStamp
        {
            get
            {
                return "[ " + DateTime.Now.ToString() + " ] --->  ";
            }
        }

        #endregion

        #region "Public Methods"
        
        public static bool writeToFile(string saveFile, string contentToWrite)
        {
            string subStamp = "{Error from IO.writeToFile}    ";
            try
            {
                using (StreamWriter w = File.AppendText(saveFile))
                {
                    w.WriteLine(contentToWrite);
                }
                return true;
            }
            catch (Exception exc)
            {
                string errorMessage = subStamp + exc.Message +  Environment.NewLine;
                System.Diagnostics.Debug.WriteLine(errorMessage);
                IO.writeToFile(errorFilePath, getTimeStamp + errorMessage);
                return false;
            }
        }
        
        public static bool createFile(string saveFilePath, string contentToWrite)
        {
            string subStamp = "{Error from IO.createFile}    ";
            try
            {
                using (System.IO.FileStream fs = System.IO.File.Create(saveFilePath))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }

                System.IO.File.WriteAllText(saveFilePath, contentToWrite);
                return true;
            }
            catch (Exception exc)
            {
                string errorMessage = subStamp + exc.Message + Environment.NewLine;
                System.Diagnostics.Debug.WriteLine(errorMessage);
                IO.writeToFile(errorFilePath, getTimeStamp + errorMessage);
                return false;
            }
        }
        
        public static void loadFileToList(string savePath, string saveFilePath)
        {
            string subStamp = "{Error from IO.loadFileToList}    ";
            Directory.CreateDirectory(savePath);
            try
            {
                if (System.IO.File.Exists(saveFilePath))
                {
                    objectList.Clear();
                    objectList = JsonConvert.DeserializeObject<List<object>>(System.IO.File.ReadAllText(saveFilePath));
                    //objectList = objectList.OrderByDescending(p => p.score).ToList();
                }
                else
                {
                    IO.createFile(saveFilePath, "[ ]");
                    loadFileToList(savePath, saveFilePath);
                }
            }
            catch (Exception exc)
            {
                string errorMessage = subStamp + exc.Message + Environment.NewLine;
                System.Diagnostics.Debug.WriteLine(errorMessage);
                IO.writeToFile(errorFilePath, getTimeStamp + errorMessage);
            }
        }

        public static void saveListToFile(string saveFile)
        {
            string subStamp = "{Error from IO.saveListToFile}    ";
            try
            {
                string contentsToWriteToFile = JsonConvert.SerializeObject(objectList.ToArray(), Formatting.Indented);

                System.IO.File.WriteAllText(saveFile, contentsToWriteToFile);

            }
            catch (Exception exc)
            {
                string errorMessage = subStamp + exc.Message + Environment.NewLine;
                System.Diagnostics.Debug.WriteLine(errorMessage);
                IO.writeToFile(errorFilePath, getTimeStamp + errorMessage);

            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            string subStamp = "{Error from IO.oDataTable}    ";
            DataTable dataTable = new DataTable(typeof(T).Name);
            try
            {
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Defining type of data column gives proper data table 
                    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name, type);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
            catch (Exception exc)
            {
                string errorMessage = subStamp + exc.Message + Environment.NewLine;
                System.Diagnostics.Debug.WriteLine(errorMessage);
                IO.writeToFile(errorFilePath, getTimeStamp + errorMessage);
                return null;
            }
        }

        #endregion
    }
}


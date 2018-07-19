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
        #region "Public Properties"
        public static List<SelestialObject> objList { get; set; }
        public static MainWindow ParetWindow { get; set; }
        #endregion

        #region "Private Properties"

        static string saveDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Interplanetary Mission Calulator";
        static string planeDataDirectoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\PlanetsData";
        static string StockPlanetsPath = planeDataDirectoryPath + "\\StockPlanets.json";
        static string OuterPlanetsPath = planeDataDirectoryPath + "\\OuterPlanets.json";
        static string RSSPlanetsPath = planeDataDirectoryPath + "\\RSSPlanets.json";

        /// <summary>
        /// Private Property that returns the datetime now to string in a custom format
        /// </summary>
        private static string TimeStamp
        {
            get
            {
                return "[ " + DateTime.Now.ToString() + " ] --->  ";
            }
        }

        #endregion

        #region "Public Properties"

        public static string errorFilePath { get; set; }

        #endregion

        #region "Private Methods"
        
        public static List<SelestialObject> planetFilesInit(int mode)
        {
            if (objList != null) objList.Clear();
            switch (mode)
            {
                case 0:
                    objList = IO.LoadListFromFile(StockPlanetsPath);
                    break;
                case 1:
                    objList = IO.LoadListFromFile(OuterPlanetsPath);
                    break;
                case 2:
                    objList = IO.LoadListFromFile(RSSPlanetsPath);
                    break;
                default:
                    objList = IO.LoadListFromFile(StockPlanetsPath);
                    break;
            }
            return objList;
        }

        public static void errorFileInit()
        {
            string errorFilePath = saveDirectoryPath + "\\errorLog.txt";
            IO.errorFilePath = errorFilePath;
            IO.createFile(errorFilePath, "");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void saveFilesInit()
        {
            List<SelestialObject> objList = new List<SelestialObject>();
            for (int i = 0; i <= 17; i++)
            {
                objList.Add(new SelestialObject());
            }
            IO.saveListToFile(StockPlanetsPath, objList);
            objList.Clear();
            for (int i = 0; i <= 31; i++)
            {
                objList.Add(new SelestialObject());
            }
            IO.saveListToFile(OuterPlanetsPath, objList);
            objList.Clear();
            for (int i = 0; i <= 16; i++)
            {
                objList.Add(new SelestialObject());
            }
            IO.saveListToFile(RSSPlanetsPath, objList);
            objList.Clear();
        }
        private static void printError(string subStamp, Exception exc)
        {
            try
            {
                string errorMessage = subStamp + exc.Message + Environment.NewLine;
                System.Diagnostics.Debug.WriteLine(errorMessage);
                IO.writeToFile(errorFilePath, TimeStamp + errorMessage);
            }
            catch (Exception e)
            {
                string subStampLocal = "{Error from IO.printError}    ";
                printError(subStampLocal, e);
            }
        }

        #endregion

        #region "Public Methods"

        public static bool writeToFile(string saveFile, string contentToWrite)
        {
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
                string subStamp = "{Error from IO.writeToFile}    ";
                printError(subStamp, exc);
                return false;
            }
        }
        
        public static bool createFile(string saveFilePath, string contentToWrite)
        {
            try
            {
                System.IO.FileInfo file = new System.IO.FileInfo(saveFilePath);
                file.Directory.Create();
                using (System.IO.FileStream fs = System.IO.File.Create(file.FullName))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }

                System.IO.File.WriteAllText(file.FullName, contentToWrite);
                return true;
            }
            catch (Exception exc)
            {
                string subStamp = "{Error from IO.createFile}    ";
                printError(subStamp, exc);
                return false;
            }
        }
        
        public static List<SelestialObject> LoadListFromFile(string FilePath)
        {
            List<SelestialObject> objectList = new List<SelestialObject>();
            try
            {
                if (System.IO.File.Exists(FilePath))
                {
                    objectList.Clear();
                    objectList = JsonConvert.DeserializeObject<List<SelestialObject>>(System.IO.File.ReadAllText(FilePath));
                }
                else
                {
                    IO.createFile(FilePath, "[ ]");
                    LoadListFromFile(FilePath);
                }
                return objectList;
            }
            catch (Exception exc)
            {
                string subStamp = "{Error from IO.loadFileToList}    ";
                printError(subStamp, exc);
                return objectList;
            }
        }

        public static void saveListToFile(string saveFilePath, List<SelestialObject> objectList)
        {
            try
            {
                string contentsToWriteToFile = JsonConvert.SerializeObject(objectList.ToArray(), Formatting.Indented);
                createFile(saveFilePath, contentsToWriteToFile);

            }
            catch (Exception exc)
            {
                string subStamp = "{Error from IO.saveListToFile}    ";
                printError(subStamp, exc);
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
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
                string subStamp = "{Error from IO.oDataTable}    ";
                printError(subStamp, exc);
                return null;
            }
        }

        #endregion
    }
}


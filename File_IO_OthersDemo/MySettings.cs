using System;
using System.IO;
using System.Text;
/*
whenever working with IO in dot net framework,always remember three classes... 1.Path 2. Directory and 3.File
when working with file we have stream class but that stream class is works with bytes[] which is very low so in order to read and write Files we should
use StreamReader and StreamWriter which works on top of Stream class....
Stream class uses the resources which needs to be closed,so always close the stream or it is a good practise to use Stream inside a USING statement so we
dont have to worry about closing the stream...
*/
namespace File_IO_OthersDemo
{
    public class MySettings
    {
        public int MyNumber { get; set; }
        public string MyString { get; set; }

        private static MySettings DefaultSettings  //Default Settings of My App
        {
            get
            {
                return new MySettings
                {
                    MyNumber = 0,
                    MyString = ""
                };
            }

        }


        private static string SettingsFolder  //creating settings folder 
        {
            get
            {
                // Under AppData folder we want a folder which looks something like My App/My AppSettings 
                // and My AppSettings folder contain a settings file

                var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                folder = Path.Combine(folder, "My App");
                folder = Path.Combine(folder, "My AppSettings");

                if (!Directory.Exists(folder))  //if the folder doesnt exists
                {
                    Directory.CreateDirectory(folder);
                }
                return folder;
            }
        }

        private static string SettingsFile  //Returned a settings file named 'settings.txt' in a SettingsFolder
        {
            get
            {
                return Path.Combine(SettingsFolder, "settings.txt");
            }
        }

        public void Save()
        {

            using (Stream stream = File.Create(SettingsFile))   //creating a file named 'settings.txt'
            //since stream works on byte[] and we dont want to work at that low level so we can use StreamWriter on top of stream
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {

                writer.WriteLine(MyNumber);
                writer.WriteLine(MyString);

                //writer.Close();   //since we are using the USING statement so we dont need to close the stream explicitly
                //stream.Close();
            }
        }

        public static MySettings Load()
        {
            if (!File.Exists(SettingsFile)) //if there is no settings file then return the default settings
            {
                return DefaultSettings;
            }
            using (Stream stream = File.OpenRead(SettingsFile))
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                try
                {
                    string firstLine = reader.ReadLine();  //reads the first line
                    string secondLine = reader.ReadLine();  //reads the second line

                    //reader.Close();
                    //stream.Close();

                    return new MySettings
                    {
                        MyNumber = int.Parse(firstLine), //we are parsing here and if the first line of file isnt int then this line will throw an exception that's why trycatch is used
                        MyString = secondLine

                    };
                }
                catch (FormatException)  //if file format is corrupt or the file is corrupt
                {
                    stream.Close();
                    File.Delete(SettingsFile);  //delete the corrupt file

                    return DefaultSettings;
                }

            }

        }




    }
}

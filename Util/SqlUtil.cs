using DishSysManager.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite.EF6;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DishSysManager.Util
{
    public class SqlUtil:DbContext
    {
        public static SqlUtil Inst
        {
            get
            {
                string conStr = "Data Source=" + DbFile;
                DbConnection sqliteCon = SQLiteProviderFactory.Instance.CreateConnection();
                sqliteCon.ConnectionString = conStr;
                return new SqlUtil(sqliteCon);
            }
        }
        static string DbFile
        {
            get
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"JayDishSysManager");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string file = Path.Combine(path, "dish");
                if (!File.Exists(file))
                {
                    CopyDbFileToPath(file);
                }

                return file;
            }
        }

        private static void CopyDbFileToPath(string file)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            //获取指定的资源

            using (Stream stream = assembly.GetManifestResourceStream("DishSysManager.dish"))
            {
                if (stream != null)  //没有找到，GetManifestResourceStream会返回null
                {
                    StreamToFile(stream, file);
                }
            }
        }
        static void StreamToFile(Stream stream, string fileName)

        {

            // 把 Stream 转换成 byte[]

            byte[] bytes = new byte[stream.Length];

            stream.Read(bytes, 0, bytes.Length);

            // 设置当前流的位置为流的开始

            stream.Seek(0, SeekOrigin.Begin);

            // 把 byte[] 写入文件

            FileStream fs = new FileStream(fileName, FileMode.Create);

            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(bytes);

            bw.Close();

            fs.Close();

        }

        public SqlUtil(DbConnection con):base(con,true)
        {

        }

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}

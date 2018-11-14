using System;
using System.Collections.Generic;
using System.Text;

namespace Combine.Services
{
    public class CombineInfo
    {
        public static void SaveCombine(Combine combine)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Combine>();
                conn.Insert(combine);
            }
        }

        public static List<Combine> GetCombine()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Combine>();


                var combineList = conn.Table<Combine>().ToList();

                return combineList;
            }
        }
    }
}

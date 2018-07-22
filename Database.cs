using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Talent
{
    public static class Database
    {
        /// <summary>
        /// Add our TalentScoresheet to the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Add<T>(T data)
        {
            using (var db = new LiteDatabase(Settings.DatabaseLocation + Settings.DatabaseFile))
            {
                db.GetCollection<T>().Insert(data);
                return true;
            }
        }

        /// <summary>
        /// Return the TalentScoresheet based on the player's name.
        /// </summary>
        /// <param name="PlayerName"></param>
        /// <returns></returns>
        public static TalentScoresheet Get(string PlayerName)
        {
            using (var db = new LiteDatabase(Settings.DatabaseLocation + Settings.DatabaseFile))
            {
                return db.GetCollection<TalentScoresheet>().FindOne(Query.EQ("PlayerName", PlayerName));
            }
        } 
    }
}

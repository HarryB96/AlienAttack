using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace AlienAttack
{
    public class HighScore
    {
        public HighScore()
        {

        }
        public HighScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
    public class ScoreDbContext : DbContext
    {
        public DbSet<HighScore> HighScores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(@"Data Source = C:\Users\Harry Barnett\Engineering45\SQL\SQLite\GameDatabase.db");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlienAttack
{
    public enum EnemyType
    {
        basic, medium
    }
    class Enemy
    {
        public EnemyType enemyType { get; set; }
        public PictureBox pictureBox { get; set; }

        private string direction;
        public string Direction { get => direction; set => direction = value; }

        private int health;
        public int Health { get => health; set => health = value; }
    }
}

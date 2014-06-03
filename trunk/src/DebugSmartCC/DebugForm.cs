﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HREngine.Bots;
using SmartCompiler;
using System.Diagnostics;
using System.Reflection;

namespace DebugSmartCC
{
    public partial class DebugForm : Form
    {
        Simulation s = null;
        Board root = null;

        public DebugForm()
        {
            InitializeComponent();
            CardTemplate.DatabasePath = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "/";
            CardTemplate.LoadAll();

            StreamReader str = new StreamReader(CardTemplate.DatabasePath + "Bots/SmartCC/Config/useProfiles");
            string useDefaut = str.ReadLine();

            str.Close();

            if (useDefaut == "true")
            {
                Application.EnableVisualStyles();
                Application.Run(new ProfileSelector(CardTemplate.DatabasePath));
            }
            else
            {

                using (CodeCompiler compiler = new CodeCompiler(CardTemplate.DatabasePath + "\\Bots\\SmartCC\\Profiles\\Defaut\\", CardTemplate.DatabasePath))
                {
                    if (compiler.Compile())
                    {
                    }
                }
                String path = CardTemplate.DatabasePath + "\\Bots\\SmartCC\\Profile.current";
                using (var stream = new FileStream(path, FileMode.Truncate))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.WriteLine("Defaut");
                        writer.Close();

                    }
                }

            }

            s = new Simulation();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "/";
            openFileDialog1.Filter = "seed files (*.seed)|*.seed";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    Assembly.LoadFile(CardTemplate.DatabasePath + "Bots/SmartCC/Profile.dll");
                    root = HREngine.Bots.Debugger.BinaryDeSerialize(File.ReadAllBytes(openFileDialog1.FileName)) as Board;
                    Console.WriteLine("Loaded : " + openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s.CreateLogFolder();
            s.SeedSimulation(root);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ValuesInterface.LoadValuesFromFile();
            ProfileInterface.LoadBehavior();
            s.Simulate(false);

            stopWatch.Stop();
            Console.WriteLine("Simulation stopped after :" + (stopWatch.ElapsedMilliseconds / 1000.0f).ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            s.CreateLogFolder();
            s.SeedSimulation(root);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            ValuesInterface.LoadValuesFromFile();
            ProfileInterface.LoadBehavior();
            s.Simulate(true);

            stopWatch.Stop();
            Console.WriteLine("Simulation stopped after :" + (stopWatch.ElapsedMilliseconds / 1000.0f).ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Board rootb = new Board();

            rootb.HeroEnemy = Card.Create("HERO_04", true, 0);
            rootb.HeroFriend = Card.Create("HERO_05", false, 1);

            rootb.HeroFriend.CurrentHealth = 30;
            rootb.HeroFriend.MaxHealth = 30;

            rootb.HeroEnemy.CurrentHealth = 20;
            rootb.HeroEnemy.MaxHealth = 30;

            rootb.ManaAvailable = 10;

            rootb.Ability = Card.Create("CS2_056", true, 45);

            rootb.Hand.Add(Card.Create("EX1_166", true, 2));

            /*Card ene = Card.Create("EX1_165", false, 3);
            ene.CurrentHealth = 4;
            rootb.MinionEnemy.Add(ene);*/
           // rootb.Hand.Add(Card.Create("EX1_004", true, 3));
           // rootb.Hand.Add(Card.Create("GAME_005", true, 4));


            root = rootb;
        }
    }
}

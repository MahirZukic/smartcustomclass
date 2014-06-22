using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Threading;
using System.Diagnostics;

namespace HREngine.Bots
{
    public class Simulation
    {
        public int VERSION = 220;
        public bool NeedCalculation { get; set; }

        public List<Action> ActionStack { get; set; }
        public Board root { get; set; }
        public Board BestBoardFinal { get; set; }

        public int TurnCount { get; set; }

        public int SimuCount { get; set; }

        public Card ChoiceTarget { get; set; }

        public bool IsCombo { get; set; }

        public bool EnemyHasSecret { get; set; }
        private string CurrentFolder { get; set; }

        public Action GetNextAction()
        {
            if (ActionStack.Count == 0 && !NeedCalculation)
            {
                NeedCalculation = true;
                IsCombo = false;
                return new Action(Action.ActionType.END_TURN, null);
            }

            Action ActionToDo = ActionStack[0];
            ActionStack.Remove(ActionToDo);

            return ActionToDo;
        }

        public void InsertChoiceAction(int choice)
        {
            ActionStack.Insert(0, new Action(Action.ActionType.CHOICE, null, null, 0, choice));
        }
        public void InsertTargetAction(Card target)
        {
            ActionStack.Insert(0, new Action(Action.ActionType.TARGET, null, target));
        }

        //             List<Thread> BgThreads = new List<Thread>();
        // int nbThread = 0;

        public Simulation()
        {
            root = null;
            ActionStack = new List<Action>();
            NeedCalculation = true;
            SimuCount = 0;
            ChoiceTarget = null;
            EnemyHasSecret = false;
            /*for (int i = 0; i < nbThread; i++)
            {
                SimulationThread thread = new SimulationThread();
                Thread threadl = new Thread(new ParameterizedThreadStart(thread.Calculate));
                BgThreads.Add(threadl);
            }*/
        }

        public bool SeedSimulation(Board b)
        {
            if (root != null)
                return false;
            root = b;
            return true;
        }

        public void CreateLogFolder()
        {
            DateTime time = DateTime.Now;
            string format = "dd-MM-yy HH-mm-ss";
            string nameFolder = time.ToString(format);
            System.IO.Directory.CreateDirectory(CardTemplate.DatabasePath + "" + Path.DirectorySeparatorChar + "Bots" + Path.DirectorySeparatorChar + "SmartCC" + Path.DirectorySeparatorChar + "Logs" + Path.DirectorySeparatorChar + "" + nameFolder);
            CurrentFolder = CardTemplate.DatabasePath + "" + Path.DirectorySeparatorChar + "Bots" + Path.DirectorySeparatorChar + "SmartCC" + Path.DirectorySeparatorChar + "Logs" + Path.DirectorySeparatorChar + "" + nameFolder;
        }

        public void SerializeRoot()
        {
            if (TurnCount > 40)
                return;
            Stream stream = new FileStream(CurrentFolder + "" + Path.DirectorySeparatorChar + "Turn" + TurnCount.ToString() + "_" + SimuCount.ToString() + ".seed", FileMode.Create, FileAccess.Write, FileShare.None);
            byte[] mem = Debugger.Serialize(root);
            stream.Write(mem, 0, mem.GetLength(0));
            stream.Close();
        }

        public void Log(string msg)
        {
            if (TurnCount > 40)
                return;
            StreamWriter sw = new StreamWriter(CurrentFolder + "" + Path.DirectorySeparatorChar + "Turn" + TurnCount.ToString() + ".log", true);
            sw.WriteLine(msg);
            sw.Close();
        }

        public void WriteWinFile()
        {
            StreamWriter sw = new StreamWriter(CurrentFolder + "" + Path.DirectorySeparatorChar + "zWIN", true);
            sw.Close();
        }

        public void Simulate(bool threaded)
        {
            SerializeRoot();
            Console.WriteLine();
            NeedCalculation = false;
            List<Board> boards = new List<Board>();
            boards.Add(root);
            int wide = 0;
            int depth = 0;
            int maxDepth = 15;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            StreamReader str = new StreamReader(CardTemplate.DatabasePath + "" + Path.DirectorySeparatorChar + "Bots" + Path.DirectorySeparatorChar + "SmartCC" + Path.DirectorySeparatorChar + "Config" + Path.DirectorySeparatorChar + "searchLevel");
            string SearchLevel = str.ReadLine();
            int maxWide = 3000;
            int maxBoards = 2000;
            int maxEnemySimu = 100;
            int maxSkip = 150000;
            float rootValue = root.GetValue() - 30;
            switch (SearchLevel)
            {
                case "low":
                    maxWide = 3000;
                    maxBoards = 5;
                    break;
                case "medium":
                    maxWide = 10000;
                    maxBoards = 1000;
                    maxEnemySimu = 30;
                    maxSkip = 50000;
                    break;
                case "high":
                    maxWide = 8000;
                    maxBoards = 30;
                    break;
                default:
                    maxWide = 3000;
                    maxBoards = 2000;
                    break;
            }



            int maxWideT = 5000;
            int maxBoardsT = 3000;

            int skipped = 0;
            root.Update();
            bool tryToSkipEqualBoards = true;
            bool tryToSkipEqualBoardsSecondPass = true;

            Board bestBoard = root;
            Log("VERSION : " + VERSION.ToString());
            Log("ROOTBOARD : ");
            Log(root.ToString());
            Log("");
            Console.WriteLine(root.ToString());
            bool foundearly = false;

            List<Board> AllBoards = new List<Board>();
            List<Board> Roots = new List<Board>();
            List<Board> Childs = new List<Board>();
            while (boards.Count != 0)
            {
                if (depth >= maxDepth)
                    break;

                wide = 0;
                skipped = 0;
                List<Board> childs = new List<Board>();

                //foreach (Board b in boards.ToArray())
                for (int i = 0; i < boards.Count; i++)
                {
                    Board b = boards[i];
                    List<Action> actions = b.CalculateAvailableActions();
                    //foreach (Action a in actions.ToArray())
                    for (int u = 0; u < actions.Count; u++)
                    {
                        Action a = actions[u];
                        if (wide > maxWide)
                            break;
                        if (skipped > maxSkip)
                            break;
                        Board bb = b.ExecuteAction(a);
                        /*
                          Console.WriteLine(a.ToString());
                          Console.WriteLine("**************************************");
                          Console.WriteLine(bb.ToString());
                          */
                        if (bb != null)
                        {
                            float bbValue = bb.GetValue();
                            if (bbValue > 10000)
                            {
                                bestBoard = bb;
                                foundearly = true;
                                break;
                            }
                            if (foundearly)
                                break;
                            if (tryToSkipEqualBoards)
                            {
                                bool found = false;
                                if (bbValue <= rootValue)
                                {
                                    found = true;
                                }
                                else
                                {
                                    //foreach (Board lol in childs.ToArray())
                                    for (int y = 0; y < childs.Count; y++)
                                    {
                                        Board lol = childs[y];
                                        if (bb.Equals(lol))
                                        {
                                            found = true;
                                            break;
                                        }
                                    }
                                }


                                if (!found)
                                {
                                    wide++;
                                    childs.Add(bb);
                                    AllBoards.Add(bb);
                                }
                                else
                                {
                                    skipped++;
                                }
                            }
                            else
                            {
                                wide++;
                                childs.Add(bb);
                                AllBoards.Add(bb);

                            }
                        }
                    }
                    if (foundearly)
                        break;
                    if (wide > maxWide)
                        break;
                    if (skipped > maxSkip)
                        break;
                }
                if (foundearly)
                {
                    Log("Found early at : " + depth.ToString() + " | " + wide.ToString());
                    Console.WriteLine("Found Early");
                    break;
                }


                Log("Simulation :" + depth.ToString() + " | " + wide.ToString() + " | " + skipped.ToString());
                Console.WriteLine("Simulation :" + depth.ToString() + " | " + wide.ToString() + " | " + skipped.ToString());
                boards.Clear();

                int limit = maxBoards;
                if (childs.Count < maxBoards)
                    limit = childs.Count;
                
                childs.Sort((x, y) => y.GetValue().CompareTo(x.GetValue()));
                childs = new List<Board>(childs.GetRange(0, limit));

                boards = childs;
                depth++;
            }




            if (!foundearly)
            {
                int limit = maxEnemySimu;
                if (AllBoards.Count < maxEnemySimu)
                    limit = AllBoards.Count;

                AllBoards.Sort((x, y) => y.GetValue().CompareTo(x.GetValue()));
                AllBoards = new List<Board>(AllBoards.GetRange(0, limit));

                //foreach (Board baa in AllBoards)
                for (int i = 0; i < AllBoards.Count; i++)
                {
                    Board baa = AllBoards[i];
                    Board endBoard = Board.Clone(baa);
                    endBoard.EndTurn();

                    bestBoard.CalculateEnemyTurn();
                    if (bestBoard.EnemyTurnWorseBoard != null)
                    {
                        endBoard.CalculateEnemyTurn();
                        Board worstBoard = endBoard.EnemyTurnWorseBoard;

                        if (worstBoard != null)
                        {
                            if (worstBoard.GetValue() > bestBoard.EnemyTurnWorseBoard.GetValue())
                            {
                                bestBoard = endBoard;
                            }
                            else if (worstBoard.GetValue() == bestBoard.EnemyTurnWorseBoard.GetValue())
                            {
                                if (endBoard.GetValue() > bestBoard.GetValue())
                                {
                                    bestBoard = endBoard;
                                }
                                else if (endBoard.GetValue() == bestBoard.GetValue())
                                {
                                    if (endBoard.HeroEnemy.CurrentHealth < bestBoard.HeroEnemy.CurrentHealth)
                                        bestBoard = endBoard;
                                }
                            }
                        }
                        else
                        {
                            if (endBoard.GetValue() > bestBoard.GetValue())
                            {
                                bestBoard = endBoard;
                            }
                            else if (endBoard.GetValue() == bestBoard.GetValue())
                            {
                                if (endBoard.HeroEnemy.CurrentHealth < bestBoard.HeroEnemy.CurrentHealth)
                                    bestBoard = endBoard;
                            }
                        }
                    }
                    else
                    {
                        if (endBoard.GetValue() > bestBoard.GetValue())
                        {
                            bestBoard = endBoard;
                        }
                        else if (endBoard.GetValue() == bestBoard.GetValue())
                        {
                            if (endBoard.HeroEnemy.CurrentHealth < bestBoard.HeroEnemy.CurrentHealth)
                                bestBoard = endBoard;
                        }
                    }
                }
            }

            Action actionPrior = null;

            //foreach (Action acc in bestBoard.ActionsStack)
            for (int i = 0; i < bestBoard.ActionsStack.Count; i++)
            {

                Action acc = bestBoard.ActionsStack[i];
                if (acc.Actor != null)
                {
                    if (acc.Actor.template.Id == "GAME_005")
                    {
                        actionPrior = null;
                        break;
                    }
                }

                if (actionPrior == null && acc.Actor != null)
                {
                    if (acc.Actor.Behavior.GetPriorityPlay(bestBoard) > 1 && acc.Type != Action.ActionType.MINION_ATTACK && acc.Type != Action.ActionType.HERO_ATTACK)
                    {
                        Console.WriteLine("Action priori found");
                        if (acc.Type == Action.ActionType.CAST_MINION && acc.Actor.Behavior.ShouldBePlayed(root))
                        {
                            if (root.MinionFriend.Count < 7)
                                actionPrior = acc;

                        }
                        else if (acc.Actor.Behavior.ShouldBePlayed(root))
                        {
                            actionPrior = acc;

                        }
                    }
                }
            }


            List<Action> finalStack = new List<Action>();
            if (actionPrior != null && !root.SecretEnemy)
            {
                finalStack.Add(actionPrior);
                if (bestBoard.ActionsStack.IndexOf(actionPrior) + 2 <= bestBoard.ActionsStack.Count)
                {
                    if (bestBoard.ActionsStack[bestBoard.ActionsStack.IndexOf(actionPrior) + 1] != null)
                    {
                        if (bestBoard.ActionsStack[bestBoard.ActionsStack.IndexOf(actionPrior) + 1].Type == Action.ActionType.RESIMULATE)
                        {
                            finalStack.Add(new Action(Action.ActionType.RESIMULATE, null));
                        }

                    }

                }

                foreach (Action a in bestBoard.ActionsStack)
                {
                    if (a != actionPrior || a.Type == Action.ActionType.RESIMULATE)
                    {
                        if (a.Type == Action.ActionType.RESIMULATE && finalStack[finalStack.Count - 1].Type == Action.ActionType.RESIMULATE)
                            continue;

                        finalStack.Add(a);
                    }
                }
            }
            else
            {
                finalStack = bestBoard.ActionsStack;
            }




            ActionStack = finalStack;
            Log("");
            Log("");
            Log("");

            Log("");
            Log("BEST BOARD FOUND");
            Log(bestBoard.ToString());
            Console.WriteLine("---------------------------------");
            Console.WriteLine(bestBoard.ToString());
            Console.WriteLine("---------------------------------");

            foreach (HREngine.Bots.Action a in ActionStack)
            {
                Log(a.ToString());

                Console.WriteLine(a.ToString());
            }
            stopWatch.Stop();

            Log("Simulation stopped after :" + (stopWatch.ElapsedMilliseconds / 1000.0f).ToString());
            BestBoardFinal = bestBoard;
            if (bestBoard.GetValue() > 9000)
                WriteWinFile();
        }
    }
    class SimulationThreadStart
    {
        public Board root = null;
        public List<Board> output = null;
        public ManualResetEvent doneEvent;
        public float maxWidePerTree = 0;

        public SimulationThreadStart(Board root, ref List<Board> output, ManualResetEvent doneEvent, float maxWidePerTree)
        {
            this.root = root;
            this.output = output;
            this.doneEvent = doneEvent;
            this.maxWidePerTree = maxWidePerTree;

        }
    }

    class SimulationThread
    {
        Board root = null;
        List<Board> output = null;
        public ManualResetEvent doneEvent;
        public float maxWidePerTree = 0;
        public static volatile bool FoundLethal = false;
        public SimulationThread()
        {
        }

        public void Calculate(object start)
        {

            SimulationThreadStart st = (SimulationThreadStart)start;
            root = st.root;
            output = st.output;
            doneEvent = st.doneEvent;
            maxWidePerTree = st.maxWidePerTree;
            if (FoundLethal)
            {
                doneEvent.Set();
                return;
            }


            int wide = 0;
            int skipped = 0;

            List<Board> boards = new List<Board>();

            boards.Add(root);
            root.Update();


            bool tryToSkipEqualBoards = false;
            Board bestBoard = null;

            wide = 0;
            skipped = 0;
            List<Board> childs = new List<Board>();

            foreach (Board b in boards)
            {
                if (FoundLethal)
                {
                    doneEvent.Set();
                    return;
                }
                if (wide > maxWidePerTree)
                    break;
                List<Action> actions = b.CalculateAvailableActions();
                foreach (Action a in actions)
                {
                    if (FoundLethal)
                    {
                        doneEvent.Set();
                        return;
                    }
                    if (wide > maxWidePerTree)
                        break;

                    Board bb = b.ExecuteAction(a);

                    if (bb != null)
                    {
                        if (bb.GetValue() > 10000)
                        {
                            FoundLethal = true;
                            bestBoard = bb;
                            if (bestBoard != null)
                            {
                                output.Add(bestBoard);
                            }
                            doneEvent.Set();
                            return;
                        }
                        if (tryToSkipEqualBoards)
                        {
                            bool found = false;
                            foreach (Board lol in output.ToArray())
                            {

                                if (bb.Equals(lol))
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                wide++;
                                childs.Add(bb);
                            }
                            else
                            {
                                skipped++;
                            }
                        }
                        else
                        {
                            wide++;
                            childs.Add(bb);
                        }
                    }
                }
            }

            foreach (Board b in childs)
            {
                if (b != null)
                    output.Add(b);
            }
            doneEvent.Set();

        }
    }

    class FilterThreadStart
    {

        public FilterThreadStart()
        {

        }
    }

    class FilterThread
    {

        public FilterThread()
        {
        }

        public void Calculate(object start)
        {
            FilterThreadStart starter = (FilterThreadStart)start;



        }
    }
}

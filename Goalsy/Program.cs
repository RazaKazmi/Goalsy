using System;
using Goalsy.Objectives;
using Goalsy.Components;

namespace Goalsy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Goalsy!");
            //CreateGoal("Get whiter teeth",0,0,0);
            //CreateGoal("Learn to whistle");
            IObjective mygoal = new TestGoal("Get whiter teeth");
            ITimer timerComp = new CountdownTimer(0, 0, 10);
            mygoal.AttachComponent(timerComp);
            Console.WriteLine(mygoal.Description);
            timerComp.Start();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}

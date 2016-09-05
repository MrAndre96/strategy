using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategy
{

    public interface IBehaviour
    {
        int moveCommand();
    }
    public class AgressiveBehaviour : IBehaviour
    {

        public int moveCommand()
        {
            Console.WriteLine("\tAgressive Behaviour: if find another robot attack it");
            return 1;
        }
    }
    public class DefensiveBehaviour : IBehaviour
    {

        public int moveCommand()
        {
            Console.WriteLine("\tDefensive Behaviour: if find another robot run from it");
            return -1;
        }
    }

    public class NormalBehaviour : IBehaviour
    {

        public int moveCommand()
        {
            Console.WriteLine("\tNormal Behaviour: if find another robot ignore it");
            return 0;
        }
    }
    public class Robot
    {
        IBehaviour behaviour;
        String name;

        public Robot(String name)
        {
            this.name = name;
        }

        public void setBehaviour(IBehaviour behaviour)
        {
            this.behaviour = behaviour;
        }

        public IBehaviour getBehaviour()
        {
            return behaviour;
        }

        public void move()
        {
            Console.WriteLine(this.name + ": Based on current position" +
                         "the behaviour object decide the next move:");
            int command = behaviour.moveCommand();
            // ... send the command to mechanisms
            Console.WriteLine("\tThe result returned by behaviour object " +
                        "is sent to the movement mechanisms " +
                        " for the robot '" + this.name + "'");
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Robot r1 = new Robot("Big Robot");
            Robot r2 = new Robot("Small Robot");
            Robot r3 = new Robot("Medium Robot");

            r1.setBehaviour(new AgressiveBehaviour());
            r2.setBehaviour(new DefensiveBehaviour());
            r3.setBehaviour(new NormalBehaviour());

            r1.move();
            r2.move();
            r3.move();

            //Console.WriteLine("\r\nNew behaviours: " +
            //        "\r\n\t'Big Robot' gets really scared" +
            //        "\r\n\t, 'George v.2.1' becomes really mad because" +
            //        "it's always attacked by other robots" +
            //        "\r\n\t and R2 keeps its calm\r\n");

            r1.setBehaviour(new DefensiveBehaviour());
            r2.setBehaviour(new AgressiveBehaviour());

            r1.move();
            r2.move();
            r3.move();
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly
{
    public class DoublesQueue
    {
        public DoublesQueue(Queue<bool> queue)
        {
            this.Queue = queue;
            this.LastRollWasDouble = false;

            //initialize queue with three false values
            for (int i = 1; i <= 3; i++)
            {
                this.Queue.Enqueue(false);
            }//for
        }//DoublesQueue

        private Queue<bool> Queue { get; set; }
        public bool LastRollWasDouble { get; set; }

        public void NextDouble(bool rolledDouble)
        {
            this.Queue.Enqueue(rolledDouble);
            this.Queue.Dequeue();
            Debug.WriteLine("Enqueued: {0}, ", rolledDouble);
            this.LastRollWasDouble = rolledDouble;
        }//NextDouble

        public bool LastThreeWereDoubles()
        {
            bool result = true;
            
            foreach (bool b in this.Queue)
            {
                if (!b){ result = false; }
            }//foreach
            
            return result;
        }//void

        public override string ToString()
        {
            String result = "";

            foreach (bool b in this.Queue)
            {
                result += (b + ", ");
            }//foreach

            return result;
        }//ToString()
    }//DoublesQueue
}

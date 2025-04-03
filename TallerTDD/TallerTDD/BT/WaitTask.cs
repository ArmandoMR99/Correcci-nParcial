using System;

namespace TallerBT.BT
{
    public class WaitTask : TaskNode
    {
        private float waitTime;
        private bool completed = false;

        public WaitTask(float time) => waitTime = time;

        public override bool Execute()
        {
            if (completed) return true;

            Thread.Sleep((int)(waitTime * 1000));
            completed = true;
            return true;
        }

        public override void Reset()
        {
            completed = false;
        }

    }
}
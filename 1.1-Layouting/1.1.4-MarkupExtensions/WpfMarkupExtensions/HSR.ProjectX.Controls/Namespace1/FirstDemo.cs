using System;

namespace HSR.ProjectX.Controls.Namespace1
{
    public class FirstDemo
    {
        private readonly Guid instanceId;

        public FirstDemo()
        {
            this.instanceId = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"FirstDemo {instanceId:B}";
        }
    }
}
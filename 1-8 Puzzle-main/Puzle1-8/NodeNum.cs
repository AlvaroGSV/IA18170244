using System;
using System.Collections.Generic;
using System.Text;

namespace Puzle1_8
{
    public class NodeNum
    {
        string nodeNum;
        
        public NodeNum(string nodeNum)
        {
            this.nodeNum = nodeNum;
        }
        public string num
        {
            get
            {
                return nodeNum;
            }
            set
            {
                nodeNum = value;
            }
        }
    }
}

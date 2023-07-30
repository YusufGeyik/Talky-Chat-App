using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Locks
    {
        private static Dictionary<string, object> fileLocks = new Dictionary<string, object>();
        
      
        public static object senderlock = new object();
        public static object listenerlock = new object();

        private static object lockObject = new object();

        public static object GetFileLock(string filePath)
        {
            lock (lockObject)
            {

                if (!fileLocks.ContainsKey(filePath))
                {
                    fileLocks[filePath] = new object();
                }

                return fileLocks[filePath];
            }
        }




      

        
    }
}
 
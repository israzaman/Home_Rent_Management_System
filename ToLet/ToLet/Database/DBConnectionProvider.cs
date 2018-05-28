using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLet.Database
{
    public class DBConnectionProvider
    {
        private static DataClasses1DataContext cntx;

        public static DataClasses1DataContext getDBConnection()
        {
            if (cntx == null)
            {
                try
                {
                    cntx = new DataClasses1DataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\isra\7th semester\OP-2\ToLet\ToLet\HomeRentMSDB.mdf;Integrated Security=True;Connect Timeout=30");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Connection Time out", ex.Message);
                }

                return cntx;
            }
            else
                return cntx;
        }
    
    }
}

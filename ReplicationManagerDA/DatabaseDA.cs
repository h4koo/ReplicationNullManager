using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosCD.Entities;

namespace ReplicationManagerDA
{
    interface DatabaseDA
    {
        
        List<Insert>  GetCurrentRows(Table table);
        Boolean ExecuteMultipleInsert(List<Insert> listInsert);
        Boolean ExecuteInsert(Insert insert);
        Boolean createTable(Table table);
        Table getTableStructure(string strNombreBase, string pNombreTabla);
        List<Table> GetAllTables(string Database);
        List<Database> GetAllDatabases();
       
    }
}

using FBDTemp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
   public interface IDatabaseAccessService
    {
       void DeleteSelectableBlock(int blockId);
       void DeleteConnection(int connectionId);

       int SaveDiagram(DiagramItem item);
       int SaveSelectableBlock(SimpleBaseViewModel block);
       int SaveConnection(Connection connectionToSave);

       IEnumerable<DiagramItem> FetchAllDiagram();
       DiagramItem FetchDiagram(int diagramId);

       SimpleBaseViewModel FetchSelectableBlock(int id);
       Connection FetchConnection(int connectionId);
    }
}

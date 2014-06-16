using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using analyticsdata.Data;

namespace analyticsdata._DBML
{
    public partial class PageEventDefinition
    {
        public static IQueryable<PageEventDefinition> GetAllForDmsGoals()
        {
            var db = Connectivity.GetMainDataContext();

            var resultQuery = from s in db.PageEventDefinitions
                              where s.IsGoal && s.Value != 0
                              orderby s.Name
                              select s;

            return resultQuery;

        }
    }
}

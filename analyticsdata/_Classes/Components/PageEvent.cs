using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using analyticsdata.Data;

namespace analyticsdata._DBML
{
    public partial class PageEvent
    {
        public static IQueryable<PageEvent> GetAllForDmsGoals(string filterVistorId, string filterVisitId, string userProfileId, 
            string pageEventDefinitionId, string filterData, DateTime? filterFromDate, DateTime? filterToDate, string orderByStr)
        {
            var db = Connectivity.GetMainDataContext();

            var resultQuery = from s in db.PageEvents
                              where s.PageEventDefinition.IsGoal && s.PageEventDefinition.Value != 0
                              select s;

            if (!string.IsNullOrEmpty(filterVistorId))
                resultQuery = from s in resultQuery
                              where s.VisitorId.ToString() == filterVistorId
                              select s;

            if (!string.IsNullOrEmpty(filterVisitId))
                resultQuery = from s in resultQuery
                              where s.VisitId.ToString() == filterVisitId
                              select s;

            if (!string.IsNullOrEmpty(userProfileId))
                resultQuery = from s in resultQuery
                              where s.Visitor.ExternalUser.Contains(userProfileId)
                              select s;

            if (!string.IsNullOrEmpty(pageEventDefinitionId))
                resultQuery = from s in resultQuery
                              where s.PageEventDefinitionId.ToString() == pageEventDefinitionId
                              select s;

            if (!string.IsNullOrEmpty(filterData))
                resultQuery = from s in resultQuery
                              where s.Data.ToString().Contains(filterData) || s.DataKey.ToString().Contains(filterData)
                              select s;

            if (filterFromDate.HasValue)
                resultQuery = from s in resultQuery 
                              where s.CreateDate >= filterFromDate.Value 
                              select s;

            if (filterToDate.HasValue)
                resultQuery = from s in resultQuery
                              where s.CreateDate <= filterToDate.Value
                              select s;

            return resultQuery.OrderBy(orderByStr);
        }
    }

    
}

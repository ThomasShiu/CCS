﻿using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Dashboard.Controllers
{
   
    public class DAS01Controller : Controller
    {
        [SupportFilter(ActionName = "Index")]
        // GET: Dashboard/DAS01
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult GetOptionByBarChart(GridPager pager, string queryStr)
        //{
        //    List<Spl_ProductModel> list = m_BLL.GetList(ref pager, queryStr);
        //    List<decimal?> costPrice = new List<decimal?>();
        //    list.ForEach(a => costPrice.Add(a.CostPrice));
        //    List<decimal?> price = new List<decimal?>();
        //    list.ForEach(a => price.Add(a.Price));
        //    List<string> names = new List<string>();
        //    list.ForEach(a => names.Add(a.Name));
        //    List<ChartSeriesModel> seriesList = new List<ChartSeriesModel>();
        //    ChartSeriesModel series1 = new ChartSeriesModel()
        //    {
        //        name = "成本价",
        //        type = "bar",
        //        data = costPrice
        //    };
        //    ChartSeriesModel series2 = new ChartSeriesModel()
        //    {
        //        name = "零售价",
        //        type = "bar",
        //        data = price
        //    };
        //    seriesList.Add(series1);
        //    seriesList.Add(series2);
        //    var option = new
        //    {
        //        title = new { text = "成本价零售价对照表" },
        //        tooltip = new { },
        //        legend = new { data = "成本价零售价对照表" },
        //        xAxis = new { data = names },
        //        yAxis = new { },
        //        series = seriesList
        //    };
        //    return Json(option);
        //}


    }
}
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using AutoMapper;
using MangoEasy.Library.Models;
using MangoEasy.Library.Services;
using MangoEasy.Web.Models;

namespace MangoEasy.Web.Controllers.API
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public object Get()
        {
            var dowloadPath = ConfigurationManager.AppSettings["DowloadUrl"];
            Mapper.Reset();
            Mapper.CreateMap<Order, OrderModel>()
                .ForMember(n => n.Url, opt => opt.MapFrom(src => dowloadPath + src.FileId));
            var model = _orderService.GetOrders().Select(Mapper.Map<Order, OrderModel>).ToArray();
            return model;
        }

        public object Post(OrderModel model)
        {
            try
            {
                var fileId = Guid.NewGuid();
                _orderService.Insert(new Order
                {
                    Id = Guid.NewGuid(),
                    MediaId = model.MediaId,
                    FileId = fileId
                });
                var url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", model.Token, model.MediaId);
                var myWebClient = new WebClient { Credentials = CredentialCache.DefaultCredentials };
                var pageData = myWebClient.DownloadData(url); //从指定网站下载数据 
                var reportFilePath = ConfigurationManager.AppSettings["FilePath"];
                var fs = new FileStream(reportFilePath + fileId, FileMode.OpenOrCreate);
                fs.Write(pageData, 0, pageData.Length);
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                return Failed(ex.Message);
            }
            return Success();
        }
    }
}
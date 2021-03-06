﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using MangoEasy.Library.Models;
using MangoEasy.Service;
using MangoEasy.Web.Models;
using MongoDBApi.Web.Infrastructure;

namespace MangoEasy.Web.Infrastructure
{
    public static class Extensions
    {
        public static UserModel GetUser(this IIdentity identity)
        {

            try
            {
                var customIdentity = identity as CustomIdentity;
                Account user = null;
                if (customIdentity == null)
                {
                    var _identity = identity as ClaimsIdentity;

                    if (_identity != null)
                    {
                        var userId = _identity.Claims.Where(n => n.Type == "Id").Select(n => n.Value).FirstOrDefault();
                        if (userId != null)
                        {
                            user = new AccountService(new MangoEasyDataContext()).GetAccount(new Guid(userId));
                        }
                    }
                }
                else
                {
                    user = customIdentity.User;
                }

                Mapper.Reset();
                Mapper.CreateMap<Account, UserModel>();
                return Mapper.Map<Account, UserModel>(user);
            }
            catch (Exception ex)
            {
                //this.GetLogger().Error(ex.Message);
            }
            return null;
        }

        public static string Shorten(this String title)
        {
            if (title.Length > 12)
            {
                return title.Substring(0, 10) + "...";
            }
            else
            {
                return title;
            }
        }
    }
}

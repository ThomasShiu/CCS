﻿using CCS.BLL.Core;
using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.SYS;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace CCS.BLL
{
    public class cs_sysuserBLL : BaseBLL, Ics_sysuserBLL, IDisposable
    {
        [Dependency]
        public Ics_sysrightRepository cs_sysrightRepository { get; set; }
        public List<permModel> GetPermission(string accountid, string controller)
        {
            return cs_sysrightRepository.GetPermission(accountid, controller);
        }

        [Dependency]
        public Ics_sysuserRepository m_Rep { get; set; }


        public List<cs_sysuserModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_SYSUSER> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.TrueName.Contains(queryStr) || a.UserName.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_sysuserModel> CreateModelList(ref IQueryable<CS_SYSUSER> queryData)
        {
            List<cs_sysuserModel> modelList = (from r in queryData
                                               select new cs_sysuserModel
                                               {
                                                   Id = r.Id,
                                                   UserName = r.UserName,
                                                   Password = r.Password,
                                                   TrueName = r.TrueName,
                                                   Card = r.Card,
                                                   MobileNumber = r.MobileNumber,
                                                   PhoneNumber = r.PhoneNumber,
                                                   QQ = r.QQ,
                                                   EmailAddress = r.EmailAddress,
                                                   OtherContact = r.OtherContact,
                                                   Province = r.Province,
                                                   City = r.City,
                                                   Village = r.Village,
                                                   Address = r.Address,
                                                   State = (r.State).Value,
                                                   CreateTime = (r.CreateTime).Value, 
                                                   CreatePerson = r.CreatePerson,
                                                   Sex = r.Sex,
                                                   Birthday = (r.Birthday).Value,
                                                   JoinDate = (r.JoinDate).Value,
                                                   Marital = r.Marital,
                                                   Political = r.Political,
                                                   Nationality = r.Nationality,
                                                   Native = r.Native,
                                                   School = r.School,
                                                   Professional = r.Professional,
                                                   Degree = r.Degree,
                                                   DepId = r.DepId,
                                                   PosId = r.PosId,
                                                   Expertise = r.Expertise,
                                                   JobState = r.JobState,
                                                   Photo = r.Photo,
                                                   Attach = r.Attach
                                               }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, cs_sysuserModel model)
        {
            try
            {
                CS_SYSUSER entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_SYSUSER();
                entity.Id = model.Id;
                entity.UserName = model.UserName;
                entity.Password = model.Password;
                entity.TrueName = model.TrueName;
                entity.Card = model.Card;
                entity.MobileNumber = model.MobileNumber;
                entity.PhoneNumber = model.PhoneNumber;
                entity.QQ = model.QQ;
                entity.EmailAddress = model.EmailAddress;
                entity.OtherContact = model.OtherContact;
                entity.Province = model.Province;
                entity.City = model.City;
                entity.Village = model.Village;
                entity.Address = model.Address;
                entity.State = model.State;
                entity.CreateTime = model.CreateTime;
                entity.CreatePerson = model.CreatePerson;
                entity.Sex = model.Sex;
                entity.Birthday = model.Birthday;
                entity.JoinDate = model.JoinDate;
                entity.Marital = model.Marital;
                entity.Political = model.Political;
                entity.Nationality = model.Nationality;
                entity.Native = model.Native;
                entity.School = model.School;
                entity.Professional = model.Professional;
                entity.Degree = model.Degree;
                entity.DepId = model.DepId;
                entity.PosId = model.PosId;
                entity.Expertise = model.Expertise;
                entity.JobState = model.JobState;
                entity.Photo = model.Photo;
                entity.Attach = model.Attach;
                if (m_Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        m_Rep.Delete(db, deleteCollection);
                        if (db.SaveChanges() == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }
        public bool Edit(ref ValidationErrors errors, cs_sysuserModel model)
        {
            try
            {
                CS_SYSUSER entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.UserName = model.UserName;
                entity.Password = model.Password;
                entity.TrueName = model.TrueName;
                entity.Card = model.Card;
                entity.MobileNumber = model.MobileNumber;
                entity.PhoneNumber = model.PhoneNumber;
                entity.QQ = model.QQ;
                entity.EmailAddress = model.EmailAddress;
                entity.OtherContact = model.OtherContact;
                entity.Province = model.Province;
                entity.City = model.City;
                entity.Village = model.Village;
                entity.Address = model.Address;
                entity.State = model.State;
                entity.CreateTime = model.CreateTime;
                entity.CreatePerson = model.CreatePerson;
                entity.Sex = model.Sex;
                entity.Birthday = model.Birthday;
                entity.JoinDate = model.JoinDate;
                entity.Marital = model.Marital;
                entity.Political = model.Political;
                entity.Nationality = model.Nationality;
                entity.Native = model.Native;
                entity.School = model.School;
                entity.Professional = model.Professional;
                entity.Degree = model.Degree;
                entity.DepId = model.DepId;
                entity.PosId = model.PosId;
                entity.Expertise = model.Expertise;
                entity.JobState = model.JobState;
                entity.Photo = model.Photo;
                entity.Attach = model.Attach;

                if (m_Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.EditFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool IsExists(string id)
        {
            if (db.CS_SYSUSER.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_sysuserModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_SYSUSER entity = m_Rep.GetById(id);
                cs_sysuserModel model = new cs_sysuserModel();
                model.Id = entity.Id;
                model.UserName = entity.UserName;
                model.Password = entity.Password;
                model.TrueName = entity.TrueName;
                model.Card = entity.Card;
                model.MobileNumber = entity.MobileNumber;
                model.PhoneNumber = entity.PhoneNumber;
                model.QQ = entity.QQ;
                model.EmailAddress = entity.EmailAddress;
                model.OtherContact = entity.OtherContact;
                model.Province = entity.Province;
                model.City = entity.City;
                model.Village = entity.Village;
                model.Address = entity.Address;
                model.State = (entity.State).Value;
                model.CreateTime = DateTime.Parse(entity.CreateTime.Value.ToShortDateString());
                model.CreatePerson = entity.CreatePerson;
                model.Sex = entity.Sex;
                model.Birthday = entity.Birthday.Value;
                model.JoinDate = entity.JoinDate.Value;
                model.Marital = entity.Marital;
                model.Political = entity.Political;
                model.Nationality = entity.Nationality;
                model.Native = entity.Native;
                model.School = entity.School;
                model.Professional = entity.Professional;
                model.Degree = entity.Degree;
                model.DepId = entity.DepId;
                model.PosId = entity.PosId;
                model.Expertise = entity.Expertise;
                model.JobState = entity.JobState;
                model.Photo = entity.Photo;
                model.Attach = entity.Attach;
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }

        public void Dispose()
        {

        }
    }
}

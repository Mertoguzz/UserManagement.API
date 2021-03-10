using System;
using System.Linq;
using UserManagementAPI.DBContext;
using UserManagementAPI.Helpers;
using UserManagementAPI.Models;
using UserManagementAPI.Service;

namespace UserManagementAPI.Services
{

    public class UserService : IUserService
    {
        private DatabaseContext _ctx;
        private UserHelpers _helpers;
        private Response _response;
        public UserService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _helpers = new UserHelpers();


        }
        public Response Delete(int ID)
        {
            _response = new Response();
            if (Helper.IsEmptyString(Convert.ToString(ID)))
            {
                _response.IsSuccess = false;
                _response.Data = new Error("ID cannot be empty"); ;
                return _response;
            }
            if (!Helper.IsNumeric(ID.ToString()))
            {
                _response.IsSuccess = false;
                _response.Data = new Error("ID must be numerical"); ;
                return _response;
            }
            try
            {
                var user = _ctx.Users.Select(x => new User() { ID = x.ID }).FirstOrDefault();
                _ctx.Users.Remove(user);
                int result = _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.ToString();
                return _response;
            }
            _response.IsSuccess = true;
            return _response;
        }

        public Response GetByTCKN(string TCKN)
        {
            _response = new Response();
            if (Helper.IsEmptyString(TCKN))
            {
                _response.IsSuccess = false;
                _response.Data = new Error("TCKN cannot be empty"); ;
                return _response;
            }
            if (!Helper.IsNumeric(TCKN))
            {
                _response.IsSuccess = false;
                _response.Data = new Error("TCKN must be numerical"); ;
                return _response;
            }
            try
            {
                var user = _ctx.Users.Where(r => r.TCKN == TCKN).FirstOrDefault();

                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.Data = new Error("user not found");
                    return _response;
                }
                _response.IsSuccess = true;
                _response.Data = user;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.ToString();
                return _response;
            }

            return _response;
        }

        public Response GetByID(string ID)
        {
            _response = new Response();
            if (Helper.IsEmptyString(ID))
            {
                _response.IsSuccess = false;
                _response.Data = new Error("ID cannot be empty"); ;
                return _response;
            }
            if (!Helper.IsNumeric(ID))
            {
                _response.IsSuccess = false;
                _response.Data = new Error("ID must be numerical"); ;
                return _response;
            }
            try
            {
                var user = _ctx.Users.Where(r => r.ID == Convert.ToInt32(ID)).FirstOrDefault();
                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.Data = new Error("user not found");
                    return _response;
                }
                _response.IsSuccess = true;
                _response.Data = user;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Data = ex.ToString();
                return _response;
            }

            return _response;
        }

        public Response Get()
        {
            _response = new Response();
            try
            {
                var users = _ctx.Users.ToList();
                if (users == null || users.Count == 0)
                {
                    _response.IsSuccess = false;
                    _response.Data = new Error("users not found");
                    return _response;
                }
                _response.IsSuccess = true;
                _response.Data = users;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.ToString();
                return _response;
            }

            return _response;
        }

        public Response Register(RegisterModel user)
        {
            _response = new Response();
            string messages = "";
            bool isValid = _helpers.CheckMandatoryProperties(user, ref messages);
            if (!isValid)
            {
                _response.IsSuccess = false;
                _response.Data = messages;
                return _response;
            }
            try
            {
                User dbUser = null;
                string TCKN = "";

                do
                {
                    TCKN = _helpers.CreateRandomTCKN();
                    dbUser = _ctx.Users.Where(r => r.TCKN == TCKN).FirstOrDefault();
                } while (dbUser != null);


                User regUser = new User
                {
                    Address = user.Address,
                    Name = user.Name,
                    Surname = user.Surname,
                    Birthday = user.Birthday,
                    TCKN = TCKN,
                    CreateTime = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                };

                _ctx.Users.Add(regUser);
                _ctx.SaveChanges();
                _response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.ToString();
                return _response;
            }


            return _response;
        }

        public Response Update(int id,UpdateModel userParam)
        {
            _response = new Response();
            string messages = "";
            var user = _ctx.Users.Find(id);

            if (user == null)
            {
                _response.IsSuccess = false;
                _response.Data = new Error("User not found"); ;
                return _response;
            }
            bool isValid = _helpers.CheckMandatoryProperties(userParam, ref messages);
            if (!isValid)
            {
                _response.IsSuccess = false;
                _response.Data = new Error(messages);
                return _response;
            }
            try
            {
                user.Address = userParam.Address;
                user.Birthday = userParam.Birthday;
                user.Name = userParam.Name;
                user.Surname = userParam.Surname;
                user.LastModifiedDate = DateTime.Now;

                _ctx.Users.Update(user);
                _ctx.SaveChanges();
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Data = ex.ToString();
                return _response;
            }

            return _response;
        }
    }
}

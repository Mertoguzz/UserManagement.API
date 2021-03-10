using UserManagementAPI.Models;

namespace UserManagementAPI.Service
{
    public interface IUserService
    {
        Response Register(RegisterModel user);

        Response Update(int id,UpdateModel user);

        Response GetByTCKN(string TCKN);

        Response GetByID(string ID);

        Response Get();

        Response Delete(int TCKN);


    }
}

using PatikaWeek14Homework1.User.Dtos;
using PatikaWeek14Homework1.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaWeek14Homework1.User
{
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto dtoUser);//unit of work kullanılacağı için async

        ServiceMessage<UserInfoDto> LoginUser(LoginUserDto dtoUser);

    }
}

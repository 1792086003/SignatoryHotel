using System.ComponentModel.DataAnnotations;

namespace Lanxess.CN.SignatoryHotel.BussinessEntity
{
    /// <summary>
    /// 登录视图模型
    /// </summary>
    public class LoginViewModel
    {
        //必填，用户名
        [Required]
        public string UserName { get; set; }
        //必填，密码
        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}

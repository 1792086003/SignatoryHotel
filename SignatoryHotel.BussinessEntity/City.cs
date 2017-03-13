using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanxess.CN.SignatoryHotel.BussinessEntity
{
    /// <summary>
    /// 城市实体类
    /// </summary>
    public class City
    {
        //主键
        public int CityID { get; set; }
        //必填，城市名
        [Required]
        [Display(Name = "City")]
        [MaxLength(20, ErrorMessage = "Must less than 20 characters")]
        public string CityName { get; set; }
        //城市所属省份
        public virtual Province Province { get; set; }
        //外键
        public virtual int ProvinceID { get; set; }
    }
}

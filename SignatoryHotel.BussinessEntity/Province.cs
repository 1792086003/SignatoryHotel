using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lanxess.CN.SignatoryHotel.BussinessEntity
{
    /// <summary>
    /// 省份实体类
    /// </summary>
    public class Province
    {
        //主键
        public int ProvinceID { get; set; }
        //必填，省份名
        [Required]
        [Display(Name = "Province")]
        [MaxLength(20, ErrorMessage = "Must less than 20 characters")]
        public string ProvinceName { get; set; }
        //每省有多个城市
        public virtual List<City> Cities { get; set; }
    }
}

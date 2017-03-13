using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Lanxess.CN.SignatoryHotel.BussinessEntity
{
    /// <summary>
    /// 酒店实体类
    /// </summary>
    public class Hotel
    {
        //主键
        public virtual int HotelID { get; set; }
        //必填字段，酒店名
        [Display(Name ="Hotel Name")]
        [Required]
        [MaxLength(60,ErrorMessage ="Must less than 60 characters")]
        public virtual string Name { get; set; }
        //可不填，酒店中文名
        [Display(Name = "Hotel CN Name")]
        [MaxLength(60, ErrorMessage = "Must less than 60 characters")]
        public virtual string CNName { get; set; }
        //可不填，星级
        [Range(1,6,ErrorMessage ="Must between 1 to 6")]
        public virtual int Star { get; set; }
        //必填字段，酒店地址
        [Required]
        [MaxLength(250, ErrorMessage = "Must less than 250 characters")]
        public virtual string Address { get; set; }
        //可不填，中文酒店地址
        [MaxLength(250, ErrorMessage = "Must less than 250 characters")]
        public virtual string AddressCN { get; set; }
        //必填字段，所在城市
        [Required]
        [Display(Name = "City")]
        public virtual int CityID { get; set; }
        public virtual City City { get; set; }
        //必填字段，所在省份
        [Required]
        [Display(Name = "Province")]
        public virtual int ProvinceID { get; set; }
        public virtual Province Province { get; set; }
        //可不填，邮政编码
        [MaxLength(8, ErrorMessage = "Must less than 8 characters")]
        public virtual string Zip { get; set; }
        //必填字段，联系电话
        [Required]
        [Display(Name = "Telephone")]
        [DataType(DataType.PhoneNumber)]
        public virtual string Telephone1 { get; set; }
        //可不填，备用联系电话
        [DataType(DataType.PhoneNumber)]
        public virtual string Telephone2 { get; set; }
        //可不填，传真
        [DataType(DataType.PhoneNumber)]
        public virtual string Fax1 { get; set; }
        //可不填，备用传真
        [DataType(DataType.PhoneNumber)]
        public virtual string Fax2 { get; set; }
        //可不填，电子邮箱
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }
        //一个酒店对应多个合同
        public virtual List<Contract> Contracts { get; set; }
        //一个酒店有多种房间
        public virtual List<Room> Rooms { get; set; }
    }
}

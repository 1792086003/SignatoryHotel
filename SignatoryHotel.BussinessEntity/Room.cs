using System.ComponentModel.DataAnnotations;

namespace Lanxess.CN.SignatoryHotel.BussinessEntity
{
    /// <summary>
    /// 酒店房间实体类
    /// </summary>
    public class Room
    {
        //主键
        public virtual int RoomID { get; set; }
        //必填，房间种类名
        [Required]
        [MaxLength(20, ErrorMessage = "Must less than 20 characters")]
        public virtual string Classification { get; set; }
        //必填，参考价格
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:C}")]
        public virtual decimal Price { get; set; }
        //可不填，与房间种类有关的信息
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "Must less than 500 characters")]
        public virtual string Remark { get; set; }
        //拥有该房间种类的酒店
        public virtual Hotel Hotel { get; set; }
        //外键
        public virtual int HotelID { get; set; }
    }
}

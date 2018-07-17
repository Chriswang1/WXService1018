using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WXService
{
    public enum StatusEnum
    {
        success,
        fail
    }
    public enum msgEnum
    {
        会员中间表插入成功,
        二维码插入成功,
        模板消息插入成功,
        会员中间表插入失败,
        二维码插入失败,
        模板消息插入失败,
        会员中间表和二维码中间表插入成功,
        会员中间表和二维码中间表插入失败,
        会员修改成功,
        会员修改失败
    }
}
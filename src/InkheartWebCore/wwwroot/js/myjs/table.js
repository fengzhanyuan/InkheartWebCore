/**
 * 表格填充插件
 * @version 1.1.2
 * @author mss
 * @url http://maxiaoxiang.com/plugin/pagination.html
 * @E-mail 251445460@qq.com
 *
 * @调用方法
 * $(selector).pagination();
 * 
 * @更新日志
 * 2016-07-25：修复click重复事件
 */
;(function($,window,document,undefined){
    var defaults = {
        Header: [],			//表头文本
        data: [{}],				//表格体文本
        Cls: '',				//TableClass
        trCls: '',			//TrClass
        tdCls: '',			//tdClass
        callback: function () { }	//回调
    };

    var Pagination = function(element,options){
        //全局变量
        var opts = options,//配置
			current,//当前页
			$document = $(document),
			$obj = $(element);//容器

        /**
		 * 设置总页数
		 * @param int page 页码
		 * @return opts.pageCount 总页数配置
		 */
        this.setTotalPage = function(page){
            return opts.pageCount = page;
        };



    };


})(jQuery, window, document);